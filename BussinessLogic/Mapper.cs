using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentiAPi.Entities;

namespace BussinessLogic
{
    public class Mapper
    {
        public static Models.category cmap(Category c)
        {
            return new Models.category
            {
                category_id = c.CategoryId,
                category_name = c.CategoryName
            };
        }
        public static Category cmap(Models.category c)

        {
            return new Category()
            {
                CategoryId = c.category_id,
                CategoryName = c.category_name
            };
        }
        public static Models.product pmap(Product p)
        {
            return new Models.product
            {
                prod_id = p.ProductId,
                prod_brand = p.ProdBrand,
                prod_description = p.ProdDescription,
                prod_price = (float)p.ProdPrice,
                category_id = (int)p.CategoryId,
                prod_name = p.ProdName,

            };
        }
        public static Product pmap(Models.product p)
        {
            return new Product()
            {
                ProductId = p.prod_id,
                ProdName = p.prod_name,
                ProdBrand = p.prod_brand,
                ProdDescription = p.prod_description,
                ProdPrice = (float)p.prod_price,
                CategoryId = p.category_id
            };
        }
        public static IEnumerable<Models.category> cmap(IEnumerable<Category> c)
        {
            return c.Select(cmap);
        }
        public static IEnumerable<Models.product> pmap(IEnumerable<Product> p)
        {
            return p.Select(pmap);
        }


    }
}
