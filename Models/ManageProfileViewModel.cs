using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubPortalMS.Models
{
    
        public class ManagePofileModelView
        {
            public bool HasPassword { get; set; }
            //public IList<UserLoginInfo> Logins { get; set; }
            public string Email { get; set; }
            // public bool BrowserRemembered { get; set; }
        }
        public class ChangePasswordModel
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Current password")]
            public string OldPassword { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }
        public class ChangeEmailModel
        {
            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Current password")]
            public string OldPassword { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Nhập Email mới:")]
            public string NewEmail { get; set; }
            public Guid ActivationCode { get; set; }
        }
    
}