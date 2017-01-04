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
    public class SpiceImporter : IImporter
    {
        private const int NumbersOfSpices = 100;


        private IRepository<Spice> spices;
        private IRepository<Country> countries;
        private IUnitOfWork unitOfWork;
        private TextWriter writer;

        public SpiceImporter(IRepository<Spice> spices, IRepository<Country> countries, IUnitOfWork unitOfWork, TextWriter writer)
        {
            this.spices = spices;
            this.countries = countries;
            this.unitOfWork = unitOfWork;
            this.writer = writer;
        }

        public string message
        {
            get
            {
                return "Importing spices";
            }
        }

        public int Order
        {
            get
            {
                return 2;
            }
        }

        public void Import()
        {
            var uniqueSpecies = new HashSet<string>();
            for (int i = 0; i < NumbersOfSpices; i++)
            {
                var newSpice = RandomGenerator.GenerateString(5, 50);
                uniqueSpecies.Add(newSpice);
            }

            var countryIds = this.countries.All().Select(c => c.Id).ToList();
            var currentSpeciesIndex = 0;

            using (this.unitOfWork)
            {
                var uniqueSpeciesList = uniqueSpecies.ToList();

                while (uniqueSpecies.Count() <= 100)
                {
                    foreach (var countryId in countryIds)
                    {
                        var numberOfSpeciesPerCountry = RandomGenerator.GenerateIntenger(2, 8);

                        if (currentSpeciesIndex + 8 >= uniqueSpecies.Count)
                        {
                            numberOfSpeciesPerCountry = uniqueSpecies.Count - currentSpeciesIndex;
                        }

                        for (int i = 0; i < numberOfSpeciesPerCountry; i++)
                        {
                            this.spices.Add(new Spice
                            {
                                Name = uniqueSpeciesList[currentSpeciesIndex],
                                CountryId = countryId
                            });

                            currentSpeciesIndex++;
                        }
                    }
                }

                this.unitOfWork.Commit();
            }
        }
    }
}
