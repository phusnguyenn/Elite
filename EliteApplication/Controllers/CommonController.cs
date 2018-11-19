using Elite.Common;
using Elite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Elite.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        public ActionResult Index()
        {
            return View("~/Views/Common/View.cshtml");
        }

        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            var imgViewModel = new ImageViewModel
            {
                Image = new Models.Models.Image(),
                ImageFile = file
            };
            var fileInfor = UploadHelper.SaveImagePath(imgViewModel);
            return View("~/Views/Common/View.cshtml" + fileInfor.FilePath);
        }
    }
}