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
    public class CategoryImporter : IImporter
    {
        private const int NumbersOfCategories = 50;

        private IRepository<Category> categories;
        private IUnitOfWork unitOfWork;
        private TextWriter writer;

        public CategoryImporter(IRepository<Category> categories, IUnitOfWork unitOfWork, TextWriter writer)
        {
            this.categories = categories;
            this.unitOfWork = unitOfWork;
            this.writer = writer;
        }

        public string message
        {
            get
            {
                return "Importing categories";
            }
        }

        public int Order
        {
            get
            {
                return 1;
            }
        }

        public void Import()
        {
            var addedCategories = 0;

            using (this.unitOfWork)
            {
                for (int i = 0; i < NumbersOfCategories; i++)
                {
                    var name = RandomGenerator.GenerateString(5, 20);

                    this.categories.Add(new Category
                    {
                        Name = name,
                    });

                    addedCategories++;

                    if (addedCategories % 10 == 0)
                    {
                        writer.Write(addedCategories);
                    }
                }

                this.unitOfWork.Commit();
            }
        }
    }
}
