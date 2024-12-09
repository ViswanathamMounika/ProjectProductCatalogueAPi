using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentiAPi.Entities;
using Microsoft.EntityFrameworkCore;


namespace FluentiAPi
{
    public class EfRepo: IRepo
    {
        private readonly HackathonContext _hccontext;
        public EfRepo(HackathonContext hccontext)
        {
            _hccontext = hccontext;
        }
        public Category AddCategory(Category category)
        {
            _hccontext.Add(category);
            _hccontext.SaveChanges();
            return category;

        }
        public Product AddProduct(Product product)
        {
            _hccontext.Add(product);
            _hccontext.SaveChanges();
            return product;
        }
        public List<Category> getAllCategories()
        {
            return _hccontext.Categories.ToList();
        }
        public List<Product> getAllProducts()
        {
            return _hccontext.ProductsManagements.ToList();
        }
        public List<catpro> GetAllDetails()
        {
            var cdetails = _hccontext.Categories;
            var pdetails = _hccontext.ProductsManagements;
            var alldetails = (from c in cdetails
                              join p in pdetails on c.CategoryId equals p.CategoryId
                              select new catpro()
                              {
                                  prod_name = p.ProdName,
                                  prod_desc = p.ProdDescription,
                                  Price = (float)p.ProdPrice,
                                  Brand = p.ProdBrand,
                                  prod_id = p.ProductId,
                                  category_id = c.CategoryId,
                                  Name = c.CategoryName,


                              });
            return alldetails.ToList();

        }
        public Category UpdateCategory(Category category)
        {
            _hccontext.Update(category);
            _hccontext.SaveChanges();
            return category;
        }
        public Product UpdateProduct(Product product)
        {
            _hccontext.Update(product);
            _hccontext.SaveChanges();
            return product;
        }
       
        public Category DeleteCategoryByName(string name)
        {
            var p = _hccontext.Categories.Where(d => d.CategoryName == name).FirstOrDefault();


            var c = _hccontext.ProductsManagements.Where(x => x.CategoryId == p.CategoryId).FirstOrDefault();
            if (c != null)
            {

                _hccontext.ProductsManagements.Remove(c);
            }
            _hccontext.Categories.Remove(p);
            _hccontext.SaveChanges();
            return p;
            
        }

        public Product DeleteProById(Guid id)
        {
            var p = _hccontext.ProductsManagements.Where(d => d.ProductId == id).FirstOrDefault();
            _hccontext.ProductsManagements.Remove(p);
            _hccontext.SaveChanges();
            return p;
        }
        }
}
