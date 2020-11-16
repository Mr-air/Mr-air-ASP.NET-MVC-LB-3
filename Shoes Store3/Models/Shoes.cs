using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shoes_Store3.Models
{
    public class Shoes
    {
        public int Id { get; set; }
        public string Model_Name { get; set; }
        public int Size { get; set; }
        public int Price { get; set; }
        public int? FirmaId { get; set; } 
        public Firmas Firma { get; set; }
    }
}