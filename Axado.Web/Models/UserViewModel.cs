using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axado.Web.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Username { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [StringLength(100)]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [StringLength(100)]
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}