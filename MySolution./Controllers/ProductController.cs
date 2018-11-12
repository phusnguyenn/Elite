using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySolution.Models;
using MySolution.ViewModels;

namespace MySolution.Controllers
{
    public class ProductController : Controller
    {
        DataEntities db = new DataEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Product()
        {
            ICollection<House> listHouse = db.House.OrderBy(h => h.DateCreated).ToList();
            return View(listHouse);
            //    Township townShip = db.Township.SingleOrDefault(x => x.TownshipId == 1);
            //    if (townShip != null)
            //    {
            //        return View(townShip);
            //    }
            //    else
            //    {
            //        TempData["ErrorCode"] = 404;
            //        return RedirectToAction("Error", "Product");
            //    }
        }
        [HttpGet]
        public ActionResult TownshipProduct(int id)
        {
            Township township = db.Township.SingleOrDefault(t => t.TownshipId == id);
            if (township != null)
            {
                return View("~/Views/Product/TownshipProduct.cshtml", township);
            }
            else
            {
                TempData["ErrorCode"] = 404;
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        public ActionResult HouseTypeProduct(int id)
        {
            HouseType houseType = db.HouseType.SingleOrDefault(t => t.HouseTypeId == id);
            if (houseType != null)
            {
                return View("~/Views/Product/HouseTypeProduct.cshtml", houseType);
            }
            else
            {
                TempData["ErrorCode"] = 404;
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult ProductDetail(int id)
        {
            House house = db.House.SingleOrDefault(h => h.HouseId == id);
            if (house != null)
            {
                return View(house);
            }
            else
            {
                TempData["ErrorCode"] = 404;
                return RedirectToAction("Error", "Home");
            }
        }
    }
}