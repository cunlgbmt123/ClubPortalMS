﻿using ClubPortalMS.CustomAuthentication;
using ClubPortalMS.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError("", "Something Wrong : Username or Password invalid ^_^ ");
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
                    var user = new DBUser()
                    {
                        Username = registrationView.UserName,
                        FirstName = registrationView.FirstName,
                        LastName = registrationView.LastName,
                        Email = registrationView.Email,
                        HashedPassword = registrationView.Password,
                        IsLocked = false,
                        EmailConfirmation = false,
                };

                    dbContext.DBUser.Add(user);
                    dbContext.SaveChanges();
                }

                //Verification Email
               // VerificationEmail(registrationView.Email, registrationView.ActivationCode.ToString());
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

        //[HttpGet]
        //public ActionResult ActivationAccount(string id)
        //{
        //    bool statusAccount = false;
        //    using (ApplicationDbContext dbContext = new Models.ApplicationDbContext())
        //    {
        //        var userAccount = dbContext.Users.Where(u => u.ActivationCode.ToString().Equals(id)).FirstOrDefault();

        //        if (userAccount != null)
        //        {
        //            userAccount.IsActive = true;
        //            dbContext.SaveChanges();
        //            statusAccount = true;
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Something Wrong !!";
        //        }

        //    }
        //    ViewBag.Status = statusAccount;
        //    return View();
        //}

        public ActionResult LogOut()
        {
            HttpCookie cookie = new HttpCookie("Cookie1", "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account", null);
        }

        //[NonAction]
        //public void VerificationEmail(string email, string activationCode)
        //{
        //    var url = string.Format("/Account/ActivationAccount/{0}", activationCode);
        //    var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, url);

        //    var fromEmail = new MailAddress("mehdi.rami2012@gmail.com", "Activation Account - AKKA");
        //    var toEmail = new MailAddress(email);

        //    var fromEmailPassword = "******************";
        //    string subject = "Activation Account !";

        //    string body = "<br/> Please click on the following link in order to activate your account" + "<br/><a href='" + link + "'> Activation Account ! </a>";

        //    var smtp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
        //    };

        //    using (var message = new MailMessage(fromEmail, toEmail)
        //    {
        //        Subject = subject,
        //        Body = body,
        //        IsBodyHtml = true

        //    })

        //        smtp.Send(message);

        //}
    }
}