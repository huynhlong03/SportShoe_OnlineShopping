using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Users:IdentityUser
    {
       

        public int Id { get; set; }
        [Required]
        
        public string Name { get; set; }
        public Users(string name)
        {
            Name = name;
        }
    }

}
