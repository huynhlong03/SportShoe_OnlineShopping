using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Protocol;
using SportShoes.Models;
using SportShoes.Models.ViewModel;

namespace SportShoes.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _dataContext;
        public ProductController(DataContext context)
        {
            _dataContext = context;
        }

        public IActionResult Index()
        {
            // Thực hiện truy vấn để lấy danh sách sản phẩm kết hợp với màu sắc
            // var products = _dataContext.Products.Include(p => p.ProductColors).ToList();
            // var Color = _dataContext.Colors.Include(t => t.ProductColors);
            var products = _dataContext.Products.Include(p => p.ProductColors).ThenInclude(pc => pc.Color).Include(p => p.ProductColors)
            .ThenInclude(pc => pc.ColorSizes).ToList();



            return View(products);
        }
        [HttpGet]
        public IActionResult GetProductColorImage(int productId, int colorId)
        {
            // Tìm các images tương ứng với colorId được chọn
            var images = _dataContext.ProductColors
                                .Where(pc => pc.ColorID == colorId && pc.ProductID == productId)
                                .Select(pc => pc.Images)
                                .FirstOrDefault();
            var imagePath = !string.IsNullOrEmpty(images) ? $"product-img/{images}" : null;

            // Trả về đường dẫn của images
            return Json(imagePath);
        }


        public IActionResult ProductDetail(int id)
        {
            //var productDetail = _dataContext.Products.Include(p => p.ProductColors).ThenInclude(pc => pc.Color).Include(p => p.ProductColors)
            //.ThenInclude(pc => pc.ColorSizes).FirstOrDefault(p => p.ProductID == id);
            var productDetail = _dataContext.Products.Include(p => p.ProductColors).ThenInclude(pc => pc.Color).Include(p => p.ProductColors)
           .ThenInclude(pc => pc.ColorSizes).ThenInclude(pc => pc.Size).FirstOrDefault(p => p.ProductID == id);
            if (productDetail == null)
                return NotFound();



            return View(productDetail);
        }
        [HttpGet]
        public IActionResult GetImagesByColorId(int productColorId, int colorId)
        {
            // Tìm kiếm ảnh và các sub_ảnh dựa trên colorId
            var images = _dataContext.ProductColors
                .Where(pc => pc.ProductColorID == productColorId && pc.ColorID == colorId)
                .Select(pc => new
                {
                    mainImage = $"/product-img/{pc.Images}",
                    subImage1 = $"/product-img/{pc.Sub_Images1}",
                    subImage2 = $"/product-img/{pc.Sub_Images2}",
                    subImage3 = $"/product-img/{pc.Sub_Images3}",
                    subImage4 = $"/product-img/{pc.Sub_Images4}",
                    productColorID = productColorId,
                    sizes = pc.ColorSizes.Select(cs => new { sizeName = cs.Size.SizeName, sizeID = cs.Size.SizeID, quantity = cs.Quantity }).ToList()
                })
                .FirstOrDefault();

            if (images == null)
            {
                // Xử lý trường hợp không tìm thấy ảnh, có thể trả về ảnh mặc định hoặc thông báo lỗi
                return NotFound(); // Trả về mã lỗi 404 Not Found
            }


            return Json(images); // Trả về dữ liệu ảnh dưới dạng JSON
        }
        [HttpGet]
        public IActionResult GetQuantityByColorSizeId(int colorSizeId)
        {
            // Tìm kiếm quantity từ sizeId trong bảng ColorSize
            var quantity = _dataContext.ColorSizes
                .Where(cs => cs.ColorSizeID == colorSizeId)
                .Select(cs => cs.Quantity)
                .FirstOrDefault();

            if (quantity == null)
            {
                // Trường hợp không tìm thấy quantity, trả về 0 hoặc giá trị mặc định khác
                return Json(new { quantity = 0 });
            }

            // Trả về quantity dưới dạng JSON
            return Json(new { quantity = quantity });
        }
        [HttpGet]
        public IActionResult GetQuantityBySizeId(int productColorId, int sizeId)
        {
            try
            {
                // Tìm kiếm quantity từ sizeId
                var quantity = _dataContext.ColorSizes.FirstOrDefault(cs => cs.Size.SizeID == sizeId && cs.ProductColor.ProductColorID == productColorId)?.Quantity;

                if (quantity.HasValue)
                {
                    // Nếu tìm thấy quantity, trả về dữ liệu dưới dạng JSON
                    return Json(new { quantity = quantity.Value });
                }
                else
                {
                    // Nếu không tìm thấy quantity, trả về mã lỗi 404 Not Found
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // Xử lý nếu có lỗi xảy ra
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
