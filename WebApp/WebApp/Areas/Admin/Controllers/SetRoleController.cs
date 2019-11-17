

using AutoMapper;
using Domain;
using Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApp.Areas.Admin.Models.ViewDto;
using WebApp.Areas.Admin.Models.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class SetRoleController : Controller
    {
        private EcommerceDbContext db = new EcommerceDbContext();
        
        // GET: Admin/SetRole
        //vừa hiển thị dữ liệu người dùng vừa cấp quyền cho người dùng
        public ActionResult Index()
        {
            var lstUser = db.Users.ToList();
            if(lstUser==null)
            {
                return HttpNotFound();
            }
            var lstUserViewModel = Mapper.Map<IEnumerable<UserViewModel>>(lstUser);

            return View(lstUserViewModel);
        }
        
        //hàm chỉnh sửa quyền cho nhân viên
        public ActionResult EditRole(int? Id)
        {
            if(Id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = db.Users.Find(Id);
            
            if(user==null)
            {
                return HttpNotFound();
            }
            var userViewModel = Mapper.Map<UserViewModel>(user);
            ViewBag.RoleId = new SelectList(db.Roles.ToList(), "Id", "Name",user.RoleId);
            ViewBag.LstUser = db.Users.ToList();
            
            return View(userViewModel);
        }
        [HttpPost]
        public ActionResult EditRole(UserViewModel userViewModel)
        {
            if(userViewModel == null)
            {
                return HttpNotFound();
            }
            var user = db.Users.FirstOrDefault(m => m.Id == userViewModel.Id);
            if(user == null)
            {
                return HttpNotFound();
            }
            user.RoleId = userViewModel.RoleId;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }


        //public JsonResult LoadData()
        //{
        //    var user = db.Users.ToList();
        //    var userViewModel = Mapper.Map<IEnumerable<UserViewModel>>(user);
        //    var lstRole = db.Roles.ToList();

        //    foreach(var item in lstRole)
        //    {
        //        foreach(var i in userViewModel)
        //        {
        //            foreach(var j in i.Roles)
        //            {
        //                j.Name = item.Name;
        //            }
        //        }
        //    }
        //    return Json(new
        //    {
        //        data = userViewModel,
        //        status = true
        //    }, JsonRequestBehavior.AllowGet);
        //}
    }
}