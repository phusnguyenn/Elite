using Elite.Common;
using Elite.Models.Models;
using Elite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MySolution.Controllers
{
    public class ProductController : Controller
    {
        private EliteDbContext db = new EliteDbContext();
        private const int ITEM_PER_PAGE = 8;
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

   
        [HttpGet]
        public ActionResult Product(int? page)
        {
            int pageNo = 0;
            int totalProduct = db.Products.Count();
            pageNo = page == null ? 1 : int.Parse(page.ToString());
            int inEachPageProductEndAt = pageNo * ITEM_PER_PAGE;
            int inEachPageProductStartsFrom = inEachPageProductEndAt - ITEM_PER_PAGE;

            var products = db.Products.OrderBy(h => h.CreationTime)
                .Skip(inEachPageProductStartsFrom)
                .Take(ITEM_PER_PAGE).ToList();

            Pager<Product> pager = new Pager<Product>(products.AsQueryable(), pageNo, ITEM_PER_PAGE, totalProduct);
            return View(pager);
        }

        [HttpGet]
        public ActionResult Category(int id)
        {
            var category = db.Categories.FirstOrDefault(s => s.Id == id);
            if (category == null)
            {
                TempData["ErrorCode"] = 404;
                return RedirectToAction("Error", "Home");
            }
            var qproducts = from cat in db.Categories.Where(s => s.Id == id && !s.IsDeleted)
                            join pro in db.Products on cat.Id equals pro.CategoryId into listProduct
                            select new CategoryViewModel
                            {
                                Id = cat.Id,
                                CategoryName = cat.CategoryName,
                                MainImage = cat.MainImage,
                                Description = cat.Description,
                                Products = listProduct.Take(10),
                                NewProducts = listProduct.OrderByDescending(s => s.CreationTime).Take(3)
                            };
            var products = qproducts.ToList().FirstOrDefault();
            return View("~/Views/Product/Category.cshtml", products);
        }

        [HttpGet]
        public ActionResult HouseTypeProduct(int id)
        {
            Category category = db.Categories.SingleOrDefault(t => t.Id == id);
            if (category != null)
            {
                return View("~/Views/Product/HouseTypeProduct.cshtml", category);
            }
            else
            {
                TempData["ErrorCode"] = 404;
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult ProductDetail(long id)
        {
            var product = db.Products.FirstOrDefault(s => !s.IsDeleted && s.Id == id);

            if (product == null)
            {
                TempData["ErrorCode"] = 404;
                return RedirectToAction("Error", "Home");
            }
            return View("~/Views/Product/ProductDetail.cshtml", product);
        }

        [HttpGet]
        public ActionResult Search(string query)
        {
            List<Product> products = new List<Product>();
            if (query != null)
            {
                products = db.Products.Where(s => !s.IsDeleted && s.ProductName.Contains(query.TrimStart())).ToList();
            }
            return View("~/Views/Product/Product.cshtml", products);
        }

        //Pagging
        //public ActionResult TownshipProduct(int id, int? page)
        //{
        //    Township township = db.Township.SingleOrDefault(t => t.TownshipId == id);
        //    if (township != null)
        //    {
        //        int pageNo = 0;
        //        int totalProduct = db.House.Where(h => h.TownShipId == id && h.Deleted != true).Count();
        //        pageNo = page == null ? 1 : int.Parse(page.ToString());
        //        int productPerPage = 8;
        //        int inEachPageProductEndAt = pageNo * productPerPage;
        //        int inEachPageProductStartsFrom = inEachPageProductEndAt - productPerPage;

        //        var listHouse = db.House.Where(h => h.TownShipId == id && h.Deleted != true).OrderBy(h => h.DateCreated)
        //            .Skip(inEachPageProductStartsFrom)
        //            .Take(productPerPage).ToList();

        //        Pager<House> pager = new Pager<House>(listHouse.AsQueryable(), pageNo, productPerPage, totalProduct);
        //        township.House = pager;

        //        return View(township);
        //        //return View("~/Views/Product/TownshipProduct.cshtml", township);
        //    }
        //    else
        //    {
        //        TempData["ErrorCode"] = 404;
        //        return RedirectToAction("Error", "Home");
        //    }
        //}
    }
}