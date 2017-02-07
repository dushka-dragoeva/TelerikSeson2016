using System.Linq;

using NewsSystem.Data.Models;

namespace NewsSystem.Data.Services.Contracts
{
    public interface ICategoryServices
    {
        IQueryable<Category> GetAll();

        Category GetByID(int id);

        Category GetByName(string name);

        void UpdateName(int id, string name);

        void Delete(int id);

        Category Create(string name);

    }
}
