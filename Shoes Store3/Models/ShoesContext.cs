using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Shoes_Store3.Models
{
    public class ShoesContext: DbContext
    {
            public DbSet<Shoes> Shoes { get; set; }
            public DbSet<Firmas> Firmas { get; set; }  
    }
}