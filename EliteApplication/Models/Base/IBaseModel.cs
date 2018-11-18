using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite.Models.Base
{
    public interface IBaseModel
    {
        bool IsDeleted { get; set; }
        long? CreatorUserId { get; set; }
        DateTime CreationTime { get; set; }
        long? DeleteUserId { get; set; }
        DateTime? DeletedTime { get; set; }
    }
}
