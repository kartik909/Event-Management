using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventMngt.Models
{
    public class DBContext: DbContext
    {
        public DbSet<Events> Events { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<EventUser> EventUser { get; set; }

    }
}