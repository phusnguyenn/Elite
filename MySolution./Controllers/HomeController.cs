using MySolution.Models;
using MySolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Elite.Models.Models;

namespace MySolution.Controllers
{
    public class HomeController : Controller
    {
        private EliteDbContext db = new EliteDbContext();
        private const int ITEMS_PER_PAGE = 8;

        //GET: Home
        public ActionResult Index()
        {
            ProductListViewModels productListViewModels = new ProductListViewModels();
            productListViewModels.ListTabOne = db.Categories.Take(ITEMS_PER_PAGE).ToList();
            productListViewModels.ListTabTwo = db.Categories.Take(ITEMS_PER_PAGE).ToList();
            productListViewModels.ListTabThree = db.Categories.Take(ITEMS_PER_PAGE).ToList();
            productListViewModels.ListTabFour = db.Categories.Take(ITEMS_PER_PAGE).ToList();
            return View(productListViewModels);
        }
        public ActionResult BannerPartial()
        {
            return PartialView();
        }
        public ActionResult Headerpartial()
        {
            HeaderViewModel headerViewModel = new HeaderViewModel();
            headerViewModel.MenCategories = db.Categories.ToList();
            headerViewModel.WomenCategories = db.Categories.ToList();
            return PartialView(headerViewModel);
        }
        public ActionResult FooterPartial()
        {
            return PartialView();
        }
        public ActionResult Error(object errorCode)
        {
            errorCode = TempData["ErrorCode"];
            if (errorCode == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (errorCode.ToString() == "404")
                {
                    return View();
                }
                else return RedirectToAction("Index", "Home");
            }
        }
    }
}