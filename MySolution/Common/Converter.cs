using MySolution.Models;
using MySolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace MySolution.Common
{
    public class Converter
    {
        /// <summary>
        /// Save an image to database
        /// </summary>
        /// <param name="image"></param>
        public static void SaveImagePath(ImageViewModel image)
        {
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmddssfff") + extension;
            image.LinkImage = "~/Images/" + fileName;
            fileName = Path.Combine(HostingEnvironment.MapPath("~/Images/"), fileName);
            image.ImageFile.SaveAs(fileName);
            using (DataEntities db = new DataEntities())
            {
                db.Image.Add(image);
                db.SaveChanges();
            }
        }

        public static string GetImagePath(int imageId)
        {
            ImageViewModel imageViewModel = new ImageViewModel();
            using (DataEntities db = new DataEntities())
            {
                Models.Image image = db.Image.SingleOrDefault(i => i.ImageId == imageId);
                return image.LinkImage;
            }
        }
    }
}