using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Demo.Models
{
    public class Apple
    {
        public string Barcode { get; set; } = null!;
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public double? PruchasePrice { get; set; }
        public double? SellingPrice { get; set; }
    }
}
