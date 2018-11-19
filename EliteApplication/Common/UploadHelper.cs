using Elite.Models.Models;
using Elite.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Web.Hosting;

namespace Elite.Common
{
    public class UploadHelper
    {
        /// <summary>
        /// Save an image to database
        /// </summary>
        /// <param name="image"></param>
        public static FileInfor SaveImagePath(ImageViewModel image)
        {
            var imgFolder = "~/Images/";

            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            fileName = fileName + DateTime.UtcNow.ToString("yymmddssfff") + extension;
            image.Image.FilePath = $"{ imgFolder } { fileName }";
            fileName = Path.Combine(HostingEnvironment.MapPath(imgFolder), fileName);
            image.ImageFile.SaveAs(fileName);

            return new FileInfor
            {
                FileName = fileName,
                FilePath = $"{imgFolder}{fileName}"
            };
        }

        //public static string GetImagePath(int imageId)
        //{
        //    ImageViewModel imageViewModel = new ImageViewModel();
        //    using (EliteDbContext db = new EliteDbContext())
        //    {
        //        Image image = db.Image.SingleOrDefault(i => i.Id == imageId);
        //        return image.FilePath;
        //    }
        //}
    }

    public class FileInfor
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}