using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Elite.Models.Models;
using Elite.ViewModels;
using Elite.Models;

namespace Elite.Controllers
{
    public class HomeController : Controller
    {
        private EliteDbContext db = new EliteDbContext();
        private const int ITEMS_PER_PAGE = 8;

        //GET: Home
        public ActionResult Index()
        {
            ProductListViewModels productListViewModels = new ProductListViewModels();
            productListViewModels.ListTabOne = db.Products.Where(x => x.Gender == Gender.Male).OrderBy(x => x.CreationTime).Take(ITEMS_PER_PAGE).ToList();
            productListViewModels.ListTabTwo = db.Products.Where(x => x.Gender == Gender.Female).OrderBy(x => x.CreationTime).Take(ITEMS_PER_PAGE).ToList();
            productListViewModels.ListTabThree = db.Products.Where(x => x.CategoryId == 3).OrderBy(x => x.CreationTime).Take(ITEMS_PER_PAGE).ToList();
            productListViewModels.ListTabFour = db.Products.Where(x => x.CategoryId == 5).OrderBy(x => x.CreationTime).Take(ITEMS_PER_PAGE).ToList();
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