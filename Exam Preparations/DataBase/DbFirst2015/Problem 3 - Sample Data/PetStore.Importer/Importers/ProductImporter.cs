using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStore.Data.Common;
using PetStore.Data;
using PetStore.Importer.Utilities;

namespace PetStore.Importer.Importers
{
   public class ProductImporter : IImporter
    {
        private const int NumbersOfProducts = 2000;

        private IRepository<Produt> products;
        private IUnitOfWork unitOfWork;
        private TextWriter writer;

        public ProductImporter(IRepository<Produt> products, IUnitOfWork unitOfWork, TextWriter writer)
        {
            this.products = products;
            this.unitOfWork = unitOfWork;
            this.writer = writer;
        }

        public string message
        {
            get
            {
                return "Importing products";
            }
        }

        public int Order
        {
            get
            {
                return 4;
            }
        }

        public void Import()
        {
            var addedProducts = 0;

            using (this.unitOfWork)
            {
                for (int i = 0; i < NumbersOfProducts; i++)
                {
                    var name = RandomGenerator.GenerateString(5, 25);

                    var price = ((decimal)RandomGenerator.GenerateIntenger(1000, 100000)) / 100;
                    this.products.Add(new Produt
                    {
                        Name = name,
                        Price = price,
                        CategoryId = RandomGenerator.GenerateIntenger(1, 50)
                    });

                    addedProducts++;

                    if (addedProducts % 100 == 0)
                    {
                        writer.Write(addedProducts/100);
                    }
                }

                this.unitOfWork.Commit();
            }
        }
    }
}
