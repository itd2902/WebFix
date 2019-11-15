using AutoMapper;
using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Areas.Admin.Models.ViewModels;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        EcommerceDbContext db = new EcommerceDbContext();
        // GET: User
        public ActionResult GetUser()
        {
            User user = (User)Session["username"];
            if(user!=null)
            {
                var userInfo = db.Users.Where(x => x.Id == user.Id).FirstOrDefault();
                var userViewModel = Mapper.Map<UserViewModel>(userInfo);
                if(userInfo.Gender==null)
                {
                    userViewModel.Gender = "male";
                }
                else
                {
                    if (userInfo.Gender.Value)
                    {
                        userViewModel.Gender = "male";
                    }
                    else
                    {
                        userViewModel.Gender = "female";
                    }
                }
                ViewBag.Notify = null;
                return View(userViewModel);
            }
            return RedirectToAction("Login", "Home");
        }
        [HttpPost]
        public ActionResult GetUser(UserViewModel userViewModel)
        {
            var user = db.Users.Where(x => x.Id == userViewModel.Id).FirstOrDefault();
            try
            {
                if(user!=null)
                {

                    if(userViewModel.Gender.Equals("male"))
                    {
                        user.Gender = true;
                    }
                    else
                    {
                        user.Gender = false;
                    }
                    user.FirstName = userViewModel.FirstName;
                    user.LastName = userViewModel.LastName;
                    user.PhoneNumber = userViewModel.PhoneNumber;
                    user.Address = userViewModel.Address;
                    user.Email = userViewModel.Email;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
            ViewBag.Notify = "Cập nhật thông tin thành công.";
            return View(userViewModel);
        }
        public ActionResult ChangePassword()
        {
            User user = (User)Session["username"];
            if(user==null)
            {
                return RedirectToAction("Login","Home");
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            User user = (User)Session["username"];
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            var userId = db.Users.Where(x => x.Id == model.Id).FirstOrDefault();
            if(userId.Password==model.Password)
            {
                userId.Password = model.Password;
                db.Entry(userId).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Success = "Mật khẩu đã được thay đổi";
                model.Password = "";
                model.NewPassword = "";
                return View(model);
            }
            ViewBag.Error = "Mật khẩu cũ không chính xác";
            return View(model);
        }
        
    }
}