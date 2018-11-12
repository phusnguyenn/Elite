using MySolution.Models;
using MySolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace MySolution.Controllers
{
    public class HomeController : Controller
    {
        DataEntities db = new DataEntities();
        //GET: Home
        public ActionResult Index()
        {
            ProductListViewModels productListViewModels = new ProductListViewModels();
            productListViewModels.ListTabOne = db.House.Where(h => h.TownShipId == 1 && h.Deleted != true).Take(8).ToList();
            productListViewModels.ListTabTwo = db.House.Where(h => h.TownShipId == 2 && h.Deleted != true).Take(8).ToList();
            productListViewModels.ListTabThree = db.House.Where(h => h.TownShipId == 4 && h.Deleted != true).Take(8).ToList();
            productListViewModels.ListTabFour = db.House.Where(h => h.TownShipId == 3 && h.Deleted != true).Take(8).ToList();
            return View(productListViewModels);
        }
        public ActionResult BannerPartial()
        {
            return PartialView();
        }
        public ActionResult Headerpartial()
        {
            HeaderViewModel headerViewModel = new HeaderViewModel();
            headerViewModel.HouseTypes = db.HouseType.ToList();
            headerViewModel.Townships = db.Township.ToList();
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