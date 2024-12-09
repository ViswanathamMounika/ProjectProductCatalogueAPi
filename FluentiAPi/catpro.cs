using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentiAPi
{
    public class catpro
    {
       public string Name { get; set; }
        public Guid prod_id { get; set; }
        public string prod_name{ get; set; }
        public string prod_desc { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }
        public int category_id { get; set; }
    }
}
