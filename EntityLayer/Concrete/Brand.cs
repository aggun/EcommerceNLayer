using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        //public List<Product>? ProductList { get; set; }
        public Brand()
        {
            Status = true;
            //ProductList = new List<Product>();
        }
        public Brand(string name)
        {
            Name = name;
        }

    }
}
