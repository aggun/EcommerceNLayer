using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProductFeature
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
        public int FeatureId { get; set; }
        [ForeignKey("FeatureId")]
        public Feature? Feature { get; set; }
        public ProductFeature()
        {

        }
        public ProductFeature(int feat)
        {
            FeatureId = feat;

        }
    }
}
