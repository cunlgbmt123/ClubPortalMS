using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Security.Claims;

namespace ClubPortalMS.Models
{
    public class ForgotPasswordView
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Nhập Email của bạn:")]
        public string Email { get; set; }
        public Guid ActivationCode { get; set; }
    }
    public class ResetPasswordView
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class GoogleLoginViewModel
    {
        public string emailaddress { get; set; }
        public string name { get; set; }
        public string givenname { get; set; }
        public string surname { get; set; }
        public string nameidentifier { get; set; }

        internal static GoogleLoginViewModel GetLoginInfo(ClaimsIdentity identity)
        {
            if (identity.Claims.Count() == 0 || identity.Claims.FirstOrDefault
            (x => x.Type == ClaimTypes.Email) == null)
            {
                return null;
            }
            return new GoogleLoginViewModel
            {
                emailaddress = identity.Claims.FirstOrDefault
              (x => x.Type == ClaimTypes.Email).Value,
                name = identity.Claims.FirstOrDefault
              (x => x.Type == ClaimTypes.Email).Value,
                givenname = identity.Claims.FirstOrDefault
              (x => x.Type == ClaimTypes.GivenName).Value,
                surname = identity.Claims.FirstOrDefault
              (x => x.Type == ClaimTypes.Surname).Value,
                nameidentifier = identity.Claims.FirstOrDefault
              (x => x.Type == ClaimTypes.NameIdentifier).Value,
            };
        }
    }
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
    public class UserLoginView
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
    public class UserRegisterView
    {
        [Required]
        [Display(Name = "Tên tài khoản")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Tên")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Họ")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public Guid ActivationCode { get; set; }
    }
}