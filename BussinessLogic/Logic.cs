using Models;
using FluentiAPi.Entities;
using FluentiAPi;
using System.Xml.Linq;

namespace BussinessLogic
{
    public class Logic : ILogic
    {
        IRepo _repo;
        public Logic(IRepo repo)
        {
            _repo = repo;
        }
        public category AddCategory(category category)
        {
            return Mapper.cmap(_repo.AddCategory(Mapper.cmap(category)));
        }

        public product AddProduct(product product)
        {
            return Mapper.pmap(_repo.AddProduct(Mapper.pmap(product
                )));
        }

        public category DeleteCategory(string name)
        {
            var cat=_repo.DeleteCategoryByName(name);
            return Mapper.cmap(cat);
        }

        public product DeletePrductById(Guid guid)
        {
            var pro=_repo.DeleteProById(guid);
            return Mapper.pmap(pro);
        }

        public IEnumerable<category> GetAllCatagories()
        {
            return Mapper.cmap(_repo.getAllCategories());
        }

        public IEnumerable<catpro> GetAllDetails()
        {
            return _repo.GetAllDetails();
        }
       

       

        public IEnumerable<product> GetAllProducts()
        {
            return Mapper.pmap(_repo.getAllProducts());
                
        }

        public IEnumerable<catpro> GetByBrand(string name)
        {
            var pro = _repo.GetAllDetails().Where(x => x.Brand == name).ToList();
            return pro;
        }

        public IEnumerable<catpro> GetByCategoryName(string name1)
        {
            var pro=_repo.GetAllDetails().Where(x=>x.Name == name1).ToList();
            return pro;
                
        }

        public IEnumerable<catpro> GetproByName(string name)
        { 
            var pro=_repo.GetAllDetails().Where(x=>x.prod_name == name).ToList();
            return pro;
        }

        public category UpdateCategory(int id, category c)
        {
            var cat=(from data in _repo.getAllCategories()
                     where data.CategoryId == id
                     select data).FirstOrDefault
                     ();
            if (cat != null)
            {
                cat.CategoryName = c.category_name;
                cat = _repo.UpdateCategory(cat);
            }
            return Mapper.cmap(cat);
        }

        public product UpdateProduct(Guid id, product p)
        {
            var  pro=(from data in _repo.getAllProducts()
                      where data .ProductId == id   
                      select data).FirstOrDefault();
            if(pro != null)
            { 
                
                pro.ProdName = p.prod_name;
                pro.ProdPrice = p.prod_price;
                pro.ProdBrand = p.prod_brand;
                pro.ProdPrice = p.prod_price;
                pro.ProdDescription = p.prod_description;
                pro.CategoryId = p.category_id;
                pro=_repo.UpdateProduct(pro);
            }
            return Mapper.pmap(pro);
        }
    }
}
