using FactoryMethod.Contracts;
using FactoryMethod.Enums;
using FactoryMethod.Models;

namespace FactoryMethod
{
    class Factory
    {
        public IProduct CreateProduct(ProductType type)
        {
            IProduct product = null;
            switch (type)
            {
                case ProductType.ConcreteProduct:
                    product = new ConcreteProduct();
                    break;
                case ProductType.OtherConcretProduct:
                    product = new OtherConcretProduct();
                    break;
                default:
                    break;
            }

            return product;
        }
    }
}