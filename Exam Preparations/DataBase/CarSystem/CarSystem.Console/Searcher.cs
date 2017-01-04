using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

using CarSystem.Console.XmlModels;
using CarSystem.Data;
using CarSystem.Models;
using System.Data.Entity;

namespace CarSystem.Console
{
    public class Searcher
    {
        private const string Id = "Id";
        private const string Year = "Year";
        private const string Price = "Price";
        private const string Model = "Model";
        private const string Manufacturer = "Manufacturer";
        private const string Dealer = "Dealer";
        private const string City = "City";
        private const string Equal = "Equals";
        private const string GreaterThan = "GreaterThan";
        private const string LessThan = "LessThan";
        private const string Contains = "Contains";

        //private  readonly CarSystemDbContext dbContext;

        //public Searcher(CarSystemDbContext cotnext)
        //{
        //    this.dbContext = cotnext;
        //}



        public static void Search(CarSystemDbContext dbContext)
        {
            var xmlQueries = Directory
                 .GetFiles(Directory.GetCurrentDirectory() + "/XmlInput/")
                 .Where(f => f.EndsWith(".xml"))
                 .Select(f => File.ReadAllText(f))
                 .FirstOrDefault();

            var reader = new StringReader(xmlQueries);
            var result = new List<List<CarOutputXmlModel>>();
            Queries queries;
            // var queries = (Queries)new XmlSerializer(typeof(Queries)).Deserialize(reader);

            using (reader)
            {
                queries = (Queries)new XmlSerializer(typeof(Queries)).Deserialize(reader);
            }

            //  reader.Read();

            //using (reader)
            //{
            // var queries = (Queries)new XmlSerializer(typeof(Queries)).Deserialize(reader);
            foreach (var q in queries.Query)

            {
                var res = ProcessQuery(q, dbContext).ToList();
                result.Add(res);
            }


        }




        private static List<CarOutputXmlModel> ProcessQuery(QueriesQuery query, CarSystemDbContext db)
        {
            //  var db = new CarsDbContext();
            var dataQuery =
                db.Cars.Select(
                    car =>
                    new CarOutputXmlModel
                    {
                        Id = car.Id,
                        Manufacturer = car.Manufacturer.Name,
                        Model = car.Model,
                        Price = car.Price,
                        Year = car.Year,
                        TransmissionType =
                                car.Transmitiontype == Models.TransmitionType.Manual ? "manual" : "automatic",
                        Dealer =
                                new DealerXmlModel
                                {
                                    Name = car.Dealer.Name,
                                    Cities = car.Dealer.Cities.Select(city => city.Name).ToList(),
                                }
                    });

            switch (query.OrderBy)
            {
                case "Id":
                    dataQuery = dataQuery.OrderBy(x => x.Id);
                    break;
                case "Year":
                    dataQuery = dataQuery.OrderBy(x => x.Year);
                    break;
                case "Model":
                    dataQuery = dataQuery.OrderBy(x => x.Model);
                    break;
                case "Price":
                    dataQuery = dataQuery.OrderBy(x => x.Price);
                    break;
                case "Manufacturer":
                    dataQuery = dataQuery.OrderBy(x => x.Manufacturer);
                    break;
                case "Dealer":
                    dataQuery = dataQuery.OrderBy(x => x.Dealer.Name);
                    break;
            }

            foreach (var whereClause in query.WhereClauses)
            {
                if (whereClause.PropertyName == "Id")
                {
                    var constant = int.Parse(whereClause.Value);
                    switch (whereClause.Type)
                    {
                        case Equal:
                            dataQuery = dataQuery.Where(x => x.Id == constant);
                            break;
                        case GreaterThan:
                            dataQuery = dataQuery.Where(x => x.Id > constant);
                            break;
                        case LessThan:
                            dataQuery = dataQuery.Where(x => x.Id < constant);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Year")
                {
                    var constant = int.Parse(whereClause.Value);
                    switch (whereClause.Type)
                    {
                        case Equal:
                            dataQuery = dataQuery.Where(x => x.Year == constant);
                            break;
                        case GreaterThan:
                            dataQuery = dataQuery.Where(x => x.Year > constant);
                            break;
                        case LessThan:
                            dataQuery = dataQuery.Where(x => x.Year < constant);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Price")
                {
                    var constant = decimal.Parse(whereClause.Value);
                    switch (whereClause.Type)
                    {
                        case Equal:
                            dataQuery = dataQuery.Where(x => x.Price == constant);
                            break;
                        case GreaterThan:
                            dataQuery = dataQuery.Where(x => x.Price > constant);
                            break;
                        case LessThan:
                            dataQuery = dataQuery.Where(x => x.Price < constant);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Model")
                {
                    switch (whereClause.Type)
                    {
                        case Equal:
                            dataQuery = dataQuery.Where(x => x.Model == whereClause.Value);
                            break;
                        case Contains:
                            dataQuery = dataQuery.Where(x => x.Model.Contains(whereClause.Value));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Manufacturer")
                {
                    switch (whereClause.Type)
                    {
                        case Equal:
                            dataQuery = dataQuery.Where(x => x.Manufacturer == whereClause.Value);
                            break;
                        case Contains:
                            dataQuery = dataQuery.Where(x => x.Manufacturer.Contains(whereClause.Value));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "Dealer")
                {
                    switch (whereClause.Type)
                    {
                        case Equal:
                            dataQuery = dataQuery.Where(x => x.Dealer.Name == whereClause.Value);
                            break;
                        case Contains:
                            dataQuery = dataQuery.Where(x => x.Dealer.Name.Contains(whereClause.Value));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                else if (whereClause.PropertyName == "City")
                {
                    switch (whereClause.Type)
                    {
                        case Equal:
                            dataQuery = dataQuery.Where(x => x.Dealer.Cities.Contains(whereClause.Value));
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            var data = dataQuery.ToList();
            return data;

            //var serializer = new XmlSerializer(data.GetType(), new XmlRootAttribute("Cars"));
            //using (var fs = new FileStream(query.OutputFileName, FileMode.Create))
            //{
            //    serializer.Serialize(fs, data);
            //}
            //System.Console.WriteLine();
            //System.Console.WriteLine("{0} ready.", query.OutputFileName);
        }

        //private static void CreateSampleQueries()
        //{
        //    var queries = new List<Query>
        //                      {
        //                          new Query
        //                              {
        //                                  OrderBy = "Id",
        //                                  OutputFileName = "Result0.xml",
        //                                  WhereClauses = new List<WhereClause>
        //                                      {
        //                                          new WhereClause
        //                                              {
        //                                                  PropertyName = "City",
        //                                                  Type = "Equals",
        //                                                  Value = "Sofia"
        //                                              },
        //                                            new WhereClause
        //                                                {
        //                                                    PropertyName = "Year",
        //                                                    Type = "GreaterThan",
        //                                                    Value = "1999"
        //                                                }
        //                                      }
        //                              }
        //                      };

        //    var serializer = new XmlSerializer(queries.GetType(), new XmlRootAttribute("Queries"));

        //    using (var fs = new FileStream("Queries.xml", FileMode.Create))
        //    {
        //        serializer.Serialize(fs, queries);
        //    }
   // }

    //private static void CreateSampleExport()
    //{
    //    var db = new CarsDbContext();
    //    var cars =
    //        db.Cars.Where(car => car.Id <= 4)
    //            .OrderBy(car => car.Id)
    //            .Select(
    //                car =>
    //                new Car
    //                {
    //                    Id = car.Id,
    //                    Manufacturer = car.Manufacturer.Name,
    //                    Model = car.Model,
    //                    Price = car.Price,
    //                    Year = car.Year,
    //                    TransmissionType =
    //                            car.TransmissionType == Models.TransmissionType.Manual ? "manual" : "automatic",
    //                    Dealer =
    //                            new Dealer
    //                            {
    //                                Name = car.Dealer.Name,
    //                                Cities = car.Dealer.Cities.Select(city => city.Name).ToList(),
    //                            }
    //                })
    //            .ToList();

    //    var serializer = new XmlSerializer(cars.GetType(), new XmlRootAttribute("Cars"));

    //    using (var fs = new FileStream("Cars.xml", FileMode.Create))
    //    {
    //        serializer.Serialize(fs, cars);
    //    }
    //}



    ////private static List<CarOutputXmlModel> ProcessQuery(QueriesQuery query, CarSystemDbContext dbContext)
    ////{
    ////    // var dbContext = new CarSystemDbContext();
    ////    var dataQuery = dbContext.Cars.Select(
    ////            car =>
    ////            new CarOutputXmlModel
    ////            {
    ////                Id = car.Id,
    ////                Manufacturer = car.Manufacturer.Name,
    ////                Model = car.Model,
    ////                Price = car.Price,
    ////                Year = car.Year,
    ////                TransmissionType =
    ////                        car.Transmitiontype == Models.TransmitionType.Manual ? "manual" : "automatic",
    ////                Dealer =
    ////                        new DealerXmlModel()
    ////                        {
    ////                            Name = car.Dealer.Name,
    ////                            Cities = car.Dealer.Cities.Select(city => city.Name).ToList(),
    ////                        }
    ////            }); 

    ////    foreach (var whereClause in query.WhereClauses)
    ////    {
    ////        switch (whereClause.PropertyName)
    ////        {
    ////            case Id:

    ////                switch (whereClause.Type)
    ////                {
    ////                    case Equal:
    ////                        dataQuery = dataQuery.Where(x => x.Id == int.Parse(whereClause.Value));
    ////                        break;
    ////                    case LessThan:
    ////                        dataQuery = dataQuery.Where(x => x.Id < int.Parse(whereClause.Value));
    ////                        break;
    ////                    case GreaterThan:
    ////                        dataQuery = dataQuery.Where(x => x.Id > int.Parse(whereClause.Value));
    ////                        break;
    ////                    default:
    ////                        throw new ArgumentOutOfRangeException();
    ////                }

    ////                break;
    ////            case Year:
    ////                switch (whereClause.Type)
    ////                {
    ////                    case Equal:
    ////                        dataQuery = dataQuery.Where(x => x.Year == int.Parse(whereClause.Value));
    ////                        break;
    ////                    case LessThan:
    ////                        dataQuery = dataQuery.Where(x => x.Year < int.Parse(whereClause.Value));
    ////                        break;
    ////                    case GreaterThan:
    ////                        dataQuery = dataQuery.Where(x => x.Year > int.Parse(whereClause.Value));
    ////                        break;
    ////                    default:
    ////                        throw new ArgumentOutOfRangeException();
    ////                }

    ////                break;
    ////            case Price:

    ////                switch (whereClause.Type)
    ////                {
    ////                    case Equal:
    ////                        dataQuery = dataQuery.Where(x => x.Price == decimal.Parse(whereClause.Value));
    ////                        break;
    ////                    case LessThan:
    ////                        dataQuery = dataQuery.Where(x => x.Price < decimal.Parse(whereClause.Value));
    ////                        break;
    ////                    case GreaterThan:
    ////                        dataQuery = dataQuery.Where(x => x.Price > decimal.Parse(whereClause.Value));
    ////                        break;

    ////                    default:
    ////                        throw new ArgumentOutOfRangeException();
    ////                }

    ////                break;
    ////            case Model:

    ////                switch (whereClause.Type)
    ////                {
    ////                    case Equal:
    ////                        dataQuery = dataQuery.Where(x => x.Model == whereClause.Value);
    ////                        break;
    ////                    case Contains:
    ////                        dataQuery = dataQuery.Where(x => x.Model.Contains(whereClause.Value));
    ////                        break;
    ////                    default:
    ////                        throw new ArgumentOutOfRangeException();
    ////                }

    ////                break;
    ////            case Manufacturer:

    ////                switch (whereClause.Type)
    ////                {
    ////                    case Equal:
    ////                        dataQuery = dataQuery.Where(x => x.Manufacturer == whereClause.Value);
    ////                        break;
    ////                    case Contains:
    ////                        dataQuery = dataQuery.Where(x => x.Manufacturer.Contains(whereClause.Value));
    ////                        break;
    ////                    default:
    ////                        throw new ArgumentOutOfRangeException();
    ////                }

    ////                break;
    ////            case Dealer:

    ////                switch (whereClause.Type)
    ////                {
    ////                    case Equal:
    ////                        dataQuery = dataQuery.Where(x => x.Dealer.Name == whereClause.Value);
    ////                        break;
    ////                    case Contains:
    ////                        dataQuery = dataQuery.Where(x => x.Dealer.Name.Contains(whereClause.Value));
    ////                        break;
    ////                    default:
    ////                        throw new ArgumentOutOfRangeException();
    ////                }

    ////                break;

    ////            case City:

    ////                dataQuery = dataQuery.Where(x => x.Dealer.Cities.Contains(whereClause.Value));
    ////                break;

    ////            default:
    ////                throw new ArgumentOutOfRangeException();
    ////        }

    ////        switch (query.OrderBy)
    ////        {
    ////            case Id:
    ////                dataQuery = dataQuery.OrderBy(x => x.Id);
    ////                break;
    ////            case Year:
    ////                dataQuery = dataQuery.OrderBy(x => x.Year);
    ////                break;
    ////            case Model:
    ////                dataQuery = dataQuery.OrderBy(x => x.Model);
    ////                break;

    ////            case Price:
    ////                dataQuery = dataQuery.OrderBy(x => x.Price);
    ////                break;
    ////            case Manufacturer:
    ////                dataQuery = dataQuery.OrderBy(x => x.Manufacturer);
    ////                break;
    ////            case Dealer:
    ////                dataQuery = dataQuery.OrderBy(x => x.Dealer.Name);
    ////                break;

    ////            default:
    ////                throw new ArgumentOutOfRangeException();
    ////        }
    ////    }

    ////    return dataQuery.ToList();
    ////}







        private static IEnumerable<TModel> Deserialize<TModel>(string fileName, string rootElement)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("File not found!", fileName);
            }

            var serializer = new XmlSerializer(typeof(List<TModel>), new XmlRootAttribute(rootElement));
            IEnumerable<TModel> result;
            using (var fs = new FileStream(fileName, FileMode.Open))
            {
                result = (IEnumerable<TModel>)serializer.Deserialize(fs);
            }

            return result;
        }


    }
}
