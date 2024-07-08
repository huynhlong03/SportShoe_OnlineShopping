using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportShoes.Helpers;
using SportShoes.Models;
using SportShoes.Models.ViewModel;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace SportShoes.Controllers
{
    public class CartController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<ApplicationUser> _usersManager;
        private readonly PaypalClient _paypalClient;

        public CartController(DataContext context, UserManager<ApplicationUser> userManager, PaypalClient paypalClient)
        {
            _dataContext = context;
            _usersManager = userManager;
            _paypalClient = paypalClient;
        }


        public List<CartItem> Cart => HttpContext.Session.Get<List<CartItem>>(MySetting.CART_KEY) ?? new List<CartItem>();
        public IActionResult Index()
        {
            return View(Cart);
        }
        //public IActionResult AddToCart(int id, int quantity = 1)
        //{
        //    var cart = Cart;
        //    var item = cart.SingleOrDefault(p => p.ProductID == id); // Sửa thành ColorSizeID
        //    if (item == null)
        //    {
        //        //     var product = _dataContext.Products.Include(p => p.ProductColors).ThenInclude(pc => pc.Color).Include(p => p.ProductColors)
        //        //.ThenInclude(pc => pc.ColorSizes).ThenInclude(pc => pc.Size).FirstOrDefault(p => p.ProductID == id);

        //        var product = _dataContext.ColorSizes.Include(p => p.ProductColor).ThenInclude(pc => pc.Product).Include(p => p.Size).Include(p => p.ProductColor).ThenInclude(pc => pc.Color).FirstOrDefault(p => p.ColorSizeID == id);


        //        if (product == null)
        //        {
        //            TempData["Message"] = $"Không tìm thấy sản phẩm mã {id}";
        //            return Redirect("/404");
        //        }

        //        item = new CartItem
        //        {
        //            ColorSizeID = product.ColorSizeID,
        //            ProductID = product.ProductColor.Product.ProductID,


        //            ProductName = product.ProductColor.Product.ProductName,
        //            Price = product.ProductColor.Product.Price,
        //            Images = product.ProductColor.Images ?? string.Empty,
        //            Quantity = quantity
        //        };
        //        cart.Add(item);

        //    }
        //    else
        //    {
        //        item.Quantity += quantity;
        //    }
        //    HttpContext.Session.Set(CART_KEY, cart);
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult AddToCart(int productColorId, int sizeId, int quantity = 1)
        {
            // Tìm colorsizeid dựa trên productColorId và sizeId
            var colorSize = _dataContext.ColorSizes.Include(p => p.ProductColor).ThenInclude(pc => pc.Product).Include(p => p.Size).Include(p => p.ProductColor).ThenInclude(pc => pc.Color).FirstOrDefault(cs => cs.ProductColorID == productColorId && cs.SizeID == sizeId);

            if (colorSize == null)
            {
                // Trả về thông báo lỗi nếu không tìm thấy colorsizeid
                TempData["Message"] = "Không tìm thấy sản phẩm.";
                return Redirect("/404"); // Chuyển hướng đến trang NotFound trong controller Error (nếu có)
            }

            // Tạo hoặc cập nhật giỏ hàng
            var cart = Cart;

            var existingItem = cart.FirstOrDefault(item => item.ProductColorId == productColorId && item.SizeID == sizeId);
            if (existingItem != null)
            {
                // Nếu sản phẩm đã tồn tại trong giỏ hàng, tăng số lượng
                existingItem.Quantity += quantity;
            }
            else
            {
                // Nếu sản phẩm chưa có trong giỏ hàng, thêm vào giỏ hàng với số lượng là 1
                var cartItem = new CartItem
                {
                    ColorSizeID = colorSize.ColorSizeID,
                    // ProductID = colorSize.ProductColor.Product.ProductID,
                    ProductColorId = productColorId,
                    SizeID = sizeId,
                    SizeName = colorSize.Size.SizeName,
                    ColorName = colorSize.ProductColor.Color.ColorName,
                    ProductName = colorSize.ProductColor.Product.ProductName,
                    Price = colorSize.ProductColor.Product.Price,
                    Images = colorSize.ProductColor.Images ?? string.Empty,
                    Quantity = quantity
                    // Các thông tin khác về sản phẩm có thể được truy vấn từ CSDL ở đây
                };
                cart.Add(cartItem);
            }

            // Lưu giỏ hàng vào session
            HttpContext.Session.Set(MySetting.CART_KEY, cart);

            // Chuyển hướng đến trang giỏ hàng
            return Redirect("/Cart/Index");

        }

        public IActionResult ReduceQuantity(int colorSizeID)
        {
            int s = 0;
            var cart = Cart;
            var item = cart.SingleOrDefault(p => p.ColorSizeID == colorSizeID);

            if (item != null)
            {
                if (item.Quantity > 1)
                {
                    s = --item.Quantity;
                }
                //else
                //{
                //    listCart.Remove(product);
                //}    
            }
            HttpContext.Session.Set(MySetting.CART_KEY, cart);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult IncreaseQuantity(int colorSizeID)
        {
            int s = 0;
            var cart = Cart;
            var item = cart.SingleOrDefault(p => p.ColorSizeID == colorSizeID);
            ColorSize colorSize = _dataContext.ColorSizes.SingleOrDefault(a => a.ColorSizeID == colorSizeID);
            if (colorSize != null)
            {
                if (item.Quantity >= 1 && item.Quantity < colorSize.Quantity)
                {
                    s = ++item.Quantity;
                }
                //else
                //{
                //    listCart.Remove(product);
                //}
            }
            HttpContext.Session.Set(MySetting.CART_KEY, cart);
            return RedirectToAction("Index", "Cart");
        }

        public IActionResult RemoveCart(int colorSizeID)
        {
            var cart = Cart;
            var item = cart.SingleOrDefault(p => p.ColorSizeID == colorSizeID);
            if (item != null)
            {
                cart.Remove(item);
                HttpContext.Session.Set(MySetting.CART_KEY, cart);
            }
            return RedirectToAction("Index", "Cart");
        }

        [Authorize]
        public IActionResult Checkout()
        {
            if (Cart.Count() == 0)
            {
                return Redirect("/");
            }
            var vouchers = _dataContext.Vouchers.Include(cs => cs.Orders).ToList();
            ViewBag.Vouchers = vouchers;
            ViewBag.PaypalClientdId = _paypalClient.ClientId;
            return View(Cart);
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutVM model)
        {
            var vouchers = _dataContext.Vouchers.Include(cs => cs.Orders).ToList();
            ViewBag.Vouchers = vouchers;
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);



                var order = new Order
                {
                    AspNetUserId = userId,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    City = model.CityText,
                    Ward = model.WardText,
                    District = model.DistrictText,
                    VoucherID = 1,
                    PaymentStatus = model.paymentMethod,
                    OrderDate = DateTime.Now,
                    DeliveryDate = null,
                    DeliveryStatusID = 1,
                    Notes = model.Notes
                };
                // _dataContext.Database.BeginTransaction();
                try
                {
                    // _dataContext.Database.CommitTransaction();
                    _dataContext.Add(order);
                    _dataContext.SaveChanges();

                    var orderDetail = new List<OrderDetail>();
                    foreach (var item in Cart)
                    {
                        orderDetail.Add(new OrderDetail
                        {
                            OrderID = order.OrderID,
                            Quantity = item.Quantity,
                            Price = item.Price,
                            ColorSizeID = item.ColorSizeID,
                        });
                    }
                    _dataContext.AddRange(orderDetail);
                    _dataContext.SaveChanges();

                    HttpContext.Session.Set<List<CartItem>>(MySetting.CART_KEY, new List<CartItem>());

                    return View("CheckoutSuccess");
                }
                catch
                {
                    _dataContext.Database.RollbackTransaction();
                }

            }

            return View(Cart);

        }


        public IActionResult CheckoutSuccess()
        {

            return View();
        }

        #region Paypal payment
        [Authorize]
        [HttpPost("/Cart/create-paypal-order")]
        public async Task<IActionResult> CreatePaypalOrder(CancellationToken cancellationToken)
        {
            // Thông tin đơn hàng gửi qua Paypal
            var tongTien = Cart.Sum(p => p.Total).ToString();
            var donViTienTe = "USD";
            var maDonHangThamChieu = "DH" + DateTime.Now.Ticks.ToString();

            try
            {
                var response = await _paypalClient.CreateOrder(tongTien, donViTienTe, maDonHangThamChieu);

                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new { ex.GetBaseException().Message };
                return BadRequest(error);
            }
        }

        [Authorize]
        [HttpPost("/Cart/capture-paypal-order")]
        public async Task<IActionResult> CapturePaypalOrder(string orderID, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _paypalClient.CaptureOrder(orderID);

                // Lưu database đơn hàng của mình
                _dataContext.SaveChanges();

                return Ok(response);
            }
            catch (Exception ex)
            {
                var error = new { ex.GetBaseException().Message };
                return BadRequest(error);
            }
        }

        #endregion

    }
}
