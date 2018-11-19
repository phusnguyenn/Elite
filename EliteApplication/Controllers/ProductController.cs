using Elite.Common;
using Elite.Models.Models;
using Elite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Elite.Controllers
{
    public class ProductController : Controller
    {
        private EliteDbContext db = new EliteDbContext();
        private static PagingResult paging = new PagingResult();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Product(int? page)
        {
            //var paging = new PagingResult();
            var products = db.Products.OrderBy(h => h.CreationTime).ToList();
            var pager = paging.GetPaging(products, page);
            return View(pager);
        }

        [HttpGet]
        public ActionResult Category(int id, int? page)
        {
            var category = db.Categories.FirstOrDefault(s => s.Id == id);
            if (category == null)
            {
                TempData["ErrorCode"] = 404;
                return RedirectToAction("Error", "Home");
            }
            var products = db.Products.Where(s => s.CategoryId == id && !s.IsDeleted).OrderByDescending(s=>s.CreationTime);
            var categoryViewModel = new CategoryViewModel
            {
                Id = id,
                CategoryName = category.CategoryName,
                MainImage = category.MainImage,
                Description = category.Description,
                NewProducts = products.Take(3),
                Products = paging.GetPaging(products,page)
            };
            return View("~/Views/Product/Category.cshtml", categoryViewModel);
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
        public ActionResult Search(string query, int? page)
        {
            List<Product> products = new List<Product>();
            if (query != null)
            {
                products = db.Products.Where(s => !s.IsDeleted && s.ProductName.Contains(query.TrimStart())).ToList();
            }
            var pager = paging.GetPaging(products, page);
            return View("~/Views/Product/Product.cshtml", pager);
        }

    }
}