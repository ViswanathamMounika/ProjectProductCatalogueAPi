using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using FluentiAPi;
using FluentiAPi.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BussinessLogic
{
    public interface ILogic
    {
      category AddCategory(
        category category);
        product AddProduct( product product);
        Models.category UpdateCategory(int id, Models.category c);
        product UpdateProduct(Guid id, product p);
        IEnumerable<product> GetAllProducts();
        IEnumerable<catpro> GetproByName(string name);
        IEnumerable<catpro> GetAllDetails();
        IEnumerable<catpro> GetByBrand(string name);
        IEnumerable<catpro> GetByCategoryName(string name);
        product DeletePrductById(Guid guid);
        category DeleteCategory(string name);
        IEnumerable<category> GetAllCatagories();



    }
}
