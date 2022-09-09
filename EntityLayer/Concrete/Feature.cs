using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }
        public string? FeatureName { get; set; }
        public string? FeatureValu { get; set; }
        public bool IsDiscounted { get; set; }
        public int? DicountRate { get; set; }
        public string? NameFalue { get; set; }
        public int BrandId { get; set; }
       
        public List<ProductFeature>? ProductFeatureList { get; set; }
        public Feature()
        {
            IsDiscounted = false;
        }

    }
}
