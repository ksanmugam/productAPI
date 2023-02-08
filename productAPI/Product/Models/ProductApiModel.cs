using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace productAPI.Models
{
    public class ProductApiModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
