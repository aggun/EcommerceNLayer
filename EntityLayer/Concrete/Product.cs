using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public bool Status { get; set; }
        public string? ProductDescription { get; set; }
        public int BrandId { get; set; }
        public List<Comment>? CommentList { get; set; }
        public List<ProductFeature>? ProductFeatureList { get; set; }
        public List<ProductCategory>? ProductCategorList { get; set; }
        public Product()
        {
            ProductCategorList= new List<ProductCategory>();
            ProductFeatureList= new List<ProductFeature>();
            Status = true;
        }

    }
}
