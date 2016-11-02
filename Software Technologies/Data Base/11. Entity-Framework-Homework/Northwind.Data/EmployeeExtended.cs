using System.Data.Linq;

namespace Northwind.Data
{
    public partial class Employee
    {
        // Task 07. By inheriting the Employee entity class create a class which allows employees 
        // to access their corresponding territories as property of type EntitySet<T>.

        public EntitySet<Territory> EntitySetTerritories
        {
            get
            {
                return this.GetTerritoryNames();
            }
        }

        private EntitySet<Territory> GetTerritoryNames()
        {
            var result = new EntitySet<Territory>();
            result.Assign(this.Territories);
            return result;
        }
    }
}
