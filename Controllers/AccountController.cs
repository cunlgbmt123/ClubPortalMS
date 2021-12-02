using ClubPortalMS.CustomAuthentication;
using ClubPortalMS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ClubPortalMS.Controllers
{
    
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return LogOut();
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginView loginView, string ReturnUrl = "")
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(loginView.UserName, loginView.Password))
                {
                    var user = (CustomMembershipUser)Membership.GetUser(loginView.UserName, false);
                    if (user != null)
                    {
                        Session["UserName"] = user.UserName;
                        Session["UserId"] = user.ID;
                        CustomSerializeModel userModel = new CustomSerializeModel()
                        {
                            ID = user.ID,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            RoleName = user.DBUserRoles.Select(r => r.RoleID.ToString()).ToList()
                        };
                        using (ApplicationDbContext db = new ApplicationDbContext())
                        {
                            userModel.RoleName = (from u in db.DBRoles 
                                                  where userModel.RoleName.Contains(u.ID.ToString()) 
                                                  select u.Name).ToList();

                        }
                     

                        string userData = JsonConvert.SerializeObject(userModel);
                        FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket
                            (
                            1, loginView.UserName, DateTime.Now, DateTime.Now.AddMinutes(15), false, userData
                            );

                        string enTicket = FormsAuthentication.Encrypt(authTicket);
                        HttpCookie faCookie = new HttpCookie("Cookie1", enTicket);
                        Response.Cookies.Add(faCookie);
                        
                    }

                    if (Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index","Dashboard", new { area = "Admin" });
                    }
                }
            }
            ModelState.AddModelError("", "Something Wrong : Username or Password invalid");
            return View(loginView);
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserRegisterView registrationView)
        {
            bool statusRegistration = false;
            string messageRegistration = string.Empty;

            if (ModelState.IsValid)
            {
                // Email Verification
                string userName = Membership.GetUserNameByEmail(registrationView.Email);
                if (!string.IsNullOrEmpty(userName))
                {   
                    
                    ModelState.AddModelError("Warning Email", "Sorry: Email already Exists");
                    return View(registrationView);
                }

                //Save User Data
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    //string passWord = registrationView.Password + "A48BF46E-1V4F-58B4-2208-CQH7-U19JC5K2K3NV";
                    //string pw = Processing.EncodePasswordToBase64(passWord);
                    //string salt = pw.Substring(1, 10);
                    //string H_Password = pw.Replace(salt, "");
                    registrationView.ActivationCode = Guid.NewGuid();
                    var user = new DBUser()
                    {
                        Username = registrationView.UserName,
                        FirstName = registrationView.FirstName,
                        LastName = registrationView.LastName,
                        Email = registrationView.Email,
                        HashedPassword = registrationView.Password,
                        IsLocked = false,
                        EmailConfirmation = false,
                        ActivationCode = registrationView.ActivationCode,
                    };
                    dbContext.DBUser.Add(user);
                    dbContext.SaveChanges();
                    var getIDUser = new ThanhVien()
                    {
                        User_ID = user.ID,
                        Ten = registrationView.FirstName,
                        Ho = registrationView.LastName,
                    };
                    dbContext.ThanhVien.Add(getIDUser);
                    dbContext.SaveChanges();
                }

                //Verification Email
                VerificationEmail(registrationView.Email, registrationView.ActivationCode.ToString());
                messageRegistration = "Your account has been created successfully. ^_^";
                statusRegistration = true;
            }
            else
            {
                messageRegistration = "Something Wrong!";
            }
            ViewBag.Message = messageRegistration;
            ViewBag.Status = statusRegistration;

            return View(registrationView);
        }

        [HttpGet]
        public ActionResult ActivationAccount(string id)
        {
            bool statusAccount = false;
            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                var userAccount = dbContext.DBUser.Where(u => u.ActivationCode.ToString().Equals(id)).FirstOrDefault();

                if (userAccount != null)
                {
                    userAccount.EmailConfirmation = true;
                    dbContext.SaveChanges();
                    statusAccount = true;
                }
                else
                {
                    ViewBag.Message = "Something Wrong !!";
                }

            }
            ViewBag.Status = statusAccount;
            return View();
        }

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }

        [NonAction]
        public void VerificationEmail(string email, string activationCode)
        {

            var url = string.Format("/Account/ActivationAccount/{0}", activationCode);
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, url);

            var fromEmail = new MailAddress("tuanbui2091@gmail.com", "Activation Account - AKKA");
            var toEmail = new MailAddress(email);

            var fromEmailPassword = "25251325Cc";
            string subject = "Activation Account !";

            string body = "<br/> Please click on the following link in order to activate your account" + "<br/><a href='" + link + "'> Activation Account ! </a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true

            })

                smtp.Send(message);

        }

        [HttpGet]
        public ActionResult ForgotPassWord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassWord(ForgotPasswordView forgotPasswordViewModel)
        {
            bool statusRegistration = false;
            string messageRegistration = string.Empty;
            if (ModelState.IsValid)
            {
                // Email Verification
              
                    var userName = Membership.GetUserNameByEmail(forgotPasswordViewModel.Email);
                    if (!string.IsNullOrEmpty(userName))
                    {
                    using (ApplicationDbContext dbContext = new ApplicationDbContext())
                    {
                        var userAccount = dbContext.DBUser.Where(u => u.Email.ToString().Equals(forgotPasswordViewModel.Email)).FirstOrDefault();
                        if (userAccount != null)
                        {
                            
                            ResetPasswordEmail(userAccount.Email, userAccount.ActivationCode.ToString());
                            RedirectToAction("ForgotPasswordEmail");
                            statusRegistration = true;
                        }
                    }
                    }
                    else
                    {
                        ModelState.AddModelError("Warning Email", "Xin lỗi Email bạn nhập không tồn tại");
                        return View(forgotPasswordViewModel);
                     }
            }
            else
            {
                messageRegistration = "Something Wrong!";
            }
            ViewBag.Message = messageRegistration;
            ViewBag.Status = statusRegistration;

            return View(forgotPasswordViewModel);
        }
        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(string id,ResetPasswordView resetPasswordView)
        {
            //bool statusAccount = false;
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    var userAccount = dbContext.DBUser.Where(u => u.ActivationCode.ToString().Equals(id)).FirstOrDefault();

                    if (userAccount != null)
                    {
                        //statusAccount = true;
                        userAccount.HashedPassword = resetPasswordView.Password;
                        dbContext.SaveChanges();
                        RedirectToAction("ForgotPasswordConfirmation");
                    }
                    else
                    {
                        ViewBag.Message = "Something Wrong !!";
                    }

                }
            }
            else
            {
                ViewBag.Message = "Bị lỗi!!";
            }
            //ViewBag.Status = statusAccount;
            return View(resetPasswordView);
        }
        public void ResetPasswordEmail(string email, string activationCode)
        {

            var url = string.Format("/Account/ResetPassword/{0}", activationCode);
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, url);

            var fromEmail = new MailAddress("tuanbui2091@gmail.com", "Đặt lại mật khẩu");
            var toEmail = new MailAddress(email);

            var fromEmailPassword = "25251325Cc";
            string subject = "Đặt lại mật khẩu!";

            string body = "<br/> Please click on the following link in order to reset password for your account" + "<br/><a href='" + link + "'> Activation Account ! </a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true

            })

                smtp.Send(message);

        }

    }
}