using Elite.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Elite.Models.Models
{
    public class Image : IEntity
    {
        public long Id { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }
        public long? ProductId { get; set; }

        public ImageType Type { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}