using System.Collections.Generic;
using System.Linq;
using System.IO;

using Newtonsoft.Json;

using CarSystem.Console.JsonModels;
using CarSystem.Data;
using CarSystem.Models;

namespace CarSystem.Console
{
    public static class JsonImporter
    {
        public static void Import(CarSystemDbContext dbContext)
        {
            var carsToAdd = Directory
                .GetFiles(Directory.GetCurrentDirectory() + "/JsonFiles/")
                .Where(f => f.EndsWith(".json"))
                .Select(f => File.ReadAllText(f))
                .SelectMany(str => JsonConvert.DeserializeObject<IEnumerable<CarJsonModel>>(str))
                .ToList();

            var citiesToAdd = new HashSet<string>();
            var manufacturerToAdd = new HashSet<string>();
            var DealarsToAdd = new HashSet<string>();

            foreach (var car in carsToAdd)
            {
                citiesToAdd.Add(car.Dealer.City);
                manufacturerToAdd.Add(car.ManufacturerName);
                DealarsToAdd.Add(car.Dealer.Name);
            }

            foreach (var cityName in citiesToAdd)
            {
                var city = new City()
                {
                    Name = cityName
                };

                dbContext.Cities.Add(city);
            }

            foreach (var manufactureName in manufacturerToAdd)
            {
                var manufacturer = new Manufacturer()
                {
                    Name = manufactureName
                };

                dbContext.Manufacturers.Add(manufacturer);
            }

            foreach (var dealerName in DealarsToAdd)
            {
                var dealer = new Dealer()
                {
                    Name = dealerName
                };

                dbContext.Dealers.Add(dealer);
            }

            dbContext.SaveChanges();
            var counter = 0;
            foreach (var carToAdd in carsToAdd)
            {
                dbContext.Configuration.AutoDetectChangesEnabled = false;
                dbContext.Configuration.ValidateOnSaveEnabled = false;

               
                var dbCity = dbContext.Cities.Where(c => c.Name == carToAdd.Dealer.City).SingleOrDefault();
                var dbDealer = dbContext.Dealers.Where(d => d.Name == carToAdd.Dealer.Name).SingleOrDefault();

                if (!dbDealer.Cities.Any(c => c.Name == dbCity.Name))
                {
                    dbDealer.Cities.Add(dbCity);
                }

                var car = new Car
                {
                    Model = carToAdd.Model,
                    Manufacturer = dbContext.Manufacturers.Where(m => m.Name == carToAdd.ManufacturerName).SingleOrDefault(),
                    Transmitiontype = (TransmitionType)carToAdd.TransmissionType,
                    Year = carToAdd.Year,
                    Price = carToAdd.Price,
                    Dealer = dbDealer
                };


                dbContext.Cars.Add(car);
                counter++;

                if (counter % 100 == 0)
                {
                    System.Console.Write("*");
                }
            }

            dbContext.SaveChanges();
        }
    }
}
