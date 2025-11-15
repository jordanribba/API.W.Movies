using API.W.Movies.DAL.Models;

namespace API.W.Movies.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<ICollection<Category>> GetCategoriesAsync(); //Me retorna UNA LISTA DE CATEGORIAS
        Task<Category> GetCategoryAsync(int id); //retorna UNA CATEGORIA POR ID
        Task<bool> CategoryExistsByIdAsync(int id); //dice si existe una categoria por ID
        Task<bool> CategoryExistsByNameAsync(string name); //dice si existe una categoria por Nombre
        Task<bool> CreateCategoryAsync(Category category); //crea una categoria
        Task<bool> UpdateCategoryAsync(Category category); //crea una categoria --puedo actualizar el nombre y la fecha de actualizacion
        Task<bool> DeleteCategoryAsync(int id); //elimina una categoria
    }
}
