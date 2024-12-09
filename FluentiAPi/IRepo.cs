using FluentiAPi.Entities;
namespace FluentiAPi
{
    public interface IRepo
    {
        Product AddProduct(Product product);
        Category AddCategory(Category category);
        Category UpdateCategory(Category category);
        Product UpdateProduct(Product p);

        List<Product> getAllProducts();
        List<Category> getAllCategories();

        List<catpro> GetAllDetails();
        Product DeleteProById(Guid id);
        Category DeleteCategoryByName(string name);



    }
}
