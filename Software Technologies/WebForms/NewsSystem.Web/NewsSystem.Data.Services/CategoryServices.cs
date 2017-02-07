using NewsSystem.Data.Models;
using NewsSystem.Data.Repositories;
using NewsSystem.Data.Services.Contracts;
using System;
using System.Linq;

namespace NewsSystem.Data.Services
{
    public class CategoryServices : ICategoryServices
    {
        private IRepository<Category> categories;

        public CategoryServices(IRepository<Category> categories) // Unit of work in same constructor =??
        {
            this.categories = categories;
        }

        public Category Create(string name)
        {
            var category = new Category() { Name = name };
                      
                this.categories.Add(category);
                this.categories.Add(category);
                this.categories.SaveChanges();
                return category;
        }

        public void Delete(int id)
        {
            this.categories.Delete(id);
            this.categories.SaveChanges();
        }

        public IQueryable<Category> GetAll()
        {
            return this.categories.All();
        }

        public Category GetByID(int id)
        {
            return this.categories.GetById(id);
        }

        public Category GetByName(string name)
        {
            return this.categories.GetByName(name);
        }

        public void UpdateName(int id, string newName)
        {

            Category categoryToUpdate = this.categories.GetById(id);
            categoryToUpdate.Name = newName;
            this.categories.SaveChanges();
        }
    }
}
