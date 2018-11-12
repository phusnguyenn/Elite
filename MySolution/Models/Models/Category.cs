using Elite.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite.Models.Models
{
    public class Category : BaseModel
    {
        [ForeignKey(nameof(ParentId))]
        public Category ParentCategory { get; set; }
        public long? ParentId { get; set; }

        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string MainImage { get; set; }
    }
}
