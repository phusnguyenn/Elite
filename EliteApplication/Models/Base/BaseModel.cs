using Elite.Models.Base;
using System;

namespace Elite.Base
{
    public class BaseModel : IBaseModel, IEntity
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public long? CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
        public long? DeleteUserId { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
