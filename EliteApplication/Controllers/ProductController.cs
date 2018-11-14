using Elite.Models.Models;
using Elite.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MySolution.Controllers
{
    public class ProductController : Controller
    {
        private EliteDbContext db = new EliteDbContext();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Product()
        {
            ICollection<Product> listHouse = db.Products.OrderBy(h => h.CreationTime).ToList();
            return View(listHouse);
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

        public ActionResult Search(string query)
        {
            var products = db.Products.Where(x => !x.IsDeleted && x.ProductName.Contains(query.TrimStart()));
            return View("~/Views/Product/Product.cshtml", products);
        }
    }
}