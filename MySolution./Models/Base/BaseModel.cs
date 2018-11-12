using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite.Base
{
    public class BaseModel : IBaseModel
    {

        public long Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public long? CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
        public long? DeleteUserId { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
