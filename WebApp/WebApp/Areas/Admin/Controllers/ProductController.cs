using AutoMapper;
using Domain;
using Domain.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.Areas.Admin.Models.ViewModels;

namespace WebApp.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        EcommerceDbContext db = new EcommerceDbContext();
        [Authorize(Roles= "admin,manager,employee")]
        public ActionResult GetProductPagsing(int? page)
        {
            var product = db.Products.OrderByDescending(o => o.CreatedDate).ToList();

            var productViewModel = Mapper.Map<IEnumerable<ProductViewModel>>(product);
            var pageSize = 5;
            var pageNumber = page ?? 1;
            return View(productViewModel.ToPagedList(pageNumber, pageSize));
        }
        // GET: Products/Details/5
        [Authorize(Roles = "admin,manager,employee")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var productViewModel = Mapper.Map<ProductViewModel>(product);

            return View(productViewModel);
        }

        // GET: Products/Create
        [Authorize(Roles = "admin,manager,employee")]
        public ActionResult Create()
        {
            var categories = db.Categories.ToList();
            var suppliers = db.Suppliers.ToList();
            var manufacturers = db.Manufacturers.ToList();

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");

            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name");//select("thể loại","giá trị option","Giá trị sẽ được hiển thị")

            ViewBag.ManufacturerId = new SelectList(manufacturers, "Id", "Name");

            return View();
        }

        // POST: Products/Create
        [Authorize(Roles = "admin,manager,employee")]
        [HttpPost]
        public ActionResult SaveData(HttpPostedFileBase file,ProductViewModel productViewModel)
        {
            if (file!=null)
            {
                var product = Mapper.Map<Product>(productViewModel);
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                fileName = fileName + extension;

                file.SaveAs(Path.Combine(Server.MapPath("~/AppFile/Images/"), fileName));
                product.UrlImage = "http://localhost:55666/AppFile/Images/" + fileName;
                db.Entry(product).State = EntityState.Added;
                db.SaveChanges();

                return RedirectToAction("GetProductPagsing");

            }
            return View();
        }
        // GET: Products/Edit/5
        [Authorize(Roles = "admin,manager,employee")]
        public ActionResult Edit(int? id)
        {
            var categories = db.Categories.ToList();
            var suppliers = db.Suppliers.ToList();
            var manufacturers = db.Manufacturers.ToList();

            var product = db.Products.Find(id);

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name",product.CategoryId);

            ViewBag.SupplierId = new SelectList(suppliers, "Id", "Name",product.SupplierId);//select("thể loại","giá trị option","Giá trị sẽ được hiển thị",tham số)

            ViewBag.ManufacturerId = new SelectList(manufacturers, "Id", "Name",product.ManufacturerId);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            if (product == null)
            {
                return HttpNotFound();
            }

            Session["img"] = product.UrlImage;

            var productViewModel = Mapper.Map<ProductViewModel>(product);

            return View(productViewModel);
        }

        // POST: Products/Edit/5
        [Authorize(Roles = "admin,manager,employee")]
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase file,ProductViewModel productViewModel)
        {
            var product = db.Products.Find(productViewModel.Id);
            if (file!=null)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                fileName = fileName + extension;

                file.SaveAs(Path.Combine(Server.MapPath("~/AppFile/Images/"), fileName));
                
                Mapper.Map(productViewModel, product);
                product.UrlImage = "http://localhost:55666/AppFile/Images/" + fileName;
                product.UpdatedBy = ((User)Session["UserName"]).UserName;
                product.UpdatedDate = DateTime.Now;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("GetProductPagsing");
            }
            else
            {
                
                Mapper.Map(productViewModel, product);
                product.UrlImage = Session["img"].ToString();
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("GetProductPagsing");
            }
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "admin,manager,employee")]
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            var productViewModel = Mapper.Map<ProductViewModel>(product);

            return View(productViewModel);
        }

        // POST: Products/Delete/5
        [Authorize(Roles = "admin,manager,employee")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var product = db.Products.Find(id);
                if (product == null)
                {
                    return HttpNotFound();
                }
                db.Entry(product).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("GetProductPagsing");
            }

            return View();
        }
    }
}