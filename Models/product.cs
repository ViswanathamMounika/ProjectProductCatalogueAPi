using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class product
    {
        public product() { }
        public Guid prod_id { get; set; }
        public string prod_name {  get; set; }
        public string prod_description { get; set; }
            public string prod_brand { get; set; }
        public float prod_price { get; set; }
        public int category_id {  get; set; }
        
    }
}
