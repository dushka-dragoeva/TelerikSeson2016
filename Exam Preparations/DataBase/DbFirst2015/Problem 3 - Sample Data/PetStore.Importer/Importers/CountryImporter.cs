using PetStore.Data;
using PetStore.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.IO;

using PetStore.Importer.Utilities;

namespace PetStore.Importer.Importers
{
    public class CountryImporter : IImporter
    {
        private const int NumbersOfCountries = 20;

        private IRepository<Country> countries;
        private IUnitOfWork unitOfWork;
        private TextWriter writer;

        public CountryImporter(IRepository<Country> countries, IUnitOfWork unitOfWork, TextWriter writer)
        {
            this.countries = countries;
            this.unitOfWork = unitOfWork;
            this.writer = writer;
        }

        public string message
        {
            get
            {
                return "Importing countries";
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
            var uniqueCountries = new HashSet<string>();
            for (int i = 0; i < NumbersOfCountries; i++)
            {
                var newCountry = RandomGenerator.GenerateString(5, 50);
                uniqueCountries.Add(newCountry);
            }

            var addedCountries = 0;

            using (this.unitOfWork)
            {
                while (uniqueCountries.Count() <= NumbersOfCountries)
                {
                    foreach (var country in uniqueCountries)
                    {
                        this.countries.Add(new Country
                        {
                            Name = country
                        });

                        addedCountries++;

                        if (addedCountries % 10 == 0)
                        {
                            writer.Write(addedCountries);
                        }

                        if (addedCountries % 100 == 0)
                        {
                            this.unitOfWork.Commit();
                        }
                    }
                }

                this.unitOfWork.Commit();
            }
        }
    }
}
