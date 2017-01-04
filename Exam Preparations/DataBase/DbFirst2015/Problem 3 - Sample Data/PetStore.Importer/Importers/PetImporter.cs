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
    public class PetImporter : IImporter
    {
        private const int NumbersOfPets = 5000;

        private IRepository<Pet> pets;
        private IUnitOfWork unitOfWork;
        private TextWriter writer;

        public PetImporter(IRepository<Pet> pets, IUnitOfWork unitOfWork, TextWriter writer)
        {
            this.pets = pets;
            this.unitOfWork = unitOfWork;
            this.writer = writer;
        }

        public string message
        {
            get
            {
                return "Importing pets";
            }
        }

        public int Order
        {
            get
            {
                return 3;
            }
        }

        public void Import()
        {
            var addedPets = 0;

            using (this.unitOfWork)
            {
                for (int i = 0; i < NumbersOfPets; i++)
                {

                    var spiceId = RandomGenerator.GenerateIntenger(1, 100);
                    var birthday = RandomGenerator.RandomDateTime();
                    var price = (decimal)RandomGenerator.GenerateIntenger(100, 1300);
                    var colorId = RandomGenerator.GenerateIntenger(1, 4);
                    var breed = RandomGenerator.GenerateString(5, 30);

                    this.pets.Add(new Pet
                    {
                        SpicesId = spiceId,
                        DateAndTimeOfBirdth = birthday,
                        Price = price,
                        ColorId = colorId,
                        Breed = breed
                    });

                    addedPets++;

                    if (addedPets % 100 == 0)
                    {
                        writer.Write(addedPets / 100);
                    }

                    if (addedPets % 100 == 0)
                    {
                        this.unitOfWork.Commit();
                    }
                }

                this.unitOfWork.Commit();
            }
        }
    }
}