using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MySolution.Models
{
    public class DataEntities : DbContext
    {
        public DataEntities() : base("name=Database") { }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Counselor> Counselor { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<GuestInterested> GuestInterested { get; set; }
        public virtual DbSet<UserInterested> UserInterested { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<Township> Township { get; set; }
        public virtual DbSet<HouseType> HouseType { get; set; }

    }
}