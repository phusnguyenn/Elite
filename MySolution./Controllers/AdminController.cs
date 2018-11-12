using MySolution.Models;
using MySolution.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace MySolution.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DataEntities db = new DataEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Image image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmddssfff") + extension;
            image.LinkImage = "~/Images/" + fileName;
            fileName = Path.Combine(HostingEnvironment.MapPath("~/Images/"), fileName);
            image.ImageFile.SaveAs(fileName);
            image.HouseId = 7;
            using (DataEntities db = new DataEntities())
            {
                db.Image.Add(image);
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public ActionResult View(int id)
        {
            ImageViewModel imageViewModel = new ImageViewModel();
            using (db)
            {
                Image image = db.Image.SingleOrDefault(i => i.ImageId == imageViewModel.Image.ImageId);
                //Common.Converter.SaveImagePath(imageViewModel);
            }
            return View("~/View/Admin/View.cshtml",imageViewModel);
        }
    }
}