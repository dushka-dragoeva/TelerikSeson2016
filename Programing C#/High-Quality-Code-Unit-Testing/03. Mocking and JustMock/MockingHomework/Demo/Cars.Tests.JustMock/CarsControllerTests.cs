namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Cars.Contracts;
    using Cars.Tests.JustMock.Mocks;
    using Cars.Controllers;
    using Cars.Models;
    using System.Linq;
    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            //: this(new JustMockCarsRepository())
            : this(new MoqCarsRepository())
        {
        }

        private CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DetailsShouldThrowArgumentNullExpectionIfCarIsNotFound()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(-1));
        }

        [TestMethod]
        public void DetailsShouldReturnCarIfCarIsFound()
        {
            var model = (Car)this.GetModel(() => this.controller.Details(3));
        }

        [TestMethod]
        public void SearchCarShouldReturnNewCollectionWhenTheConditionIsNullOrEmpty()
        {
            string condition = String.Empty;
            int expectedCarsCount = 4;
            int actual;

            var cars = (ICollection<Car>)this.GetModel(() => this.controller.Search(condition));
            actual = cars.Count;

            Assert.AreEqual(expectedCarsCount, actual);
        }

        [TestMethod]
        public void SearchCarShouldReturnCarWhenTheConditionIsMet()
        {
            string condition = "Condition";
            int expectedCarsCount = 2;
            int actual;

            var cars = (ICollection<Car>)this.GetModel(() => this.controller.Search(condition));
            actual = cars.Count;

            Assert.AreEqual(expectedCarsCount, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortCarShouldThrowArgumentExceptionWhenTheParameterIsNotValid()
        {
            string parameter = String.Empty;
            var cars = (ICollection<Car>)this.GetModel(() => this.controller.Sort(parameter));
        }

        [TestMethod]
        public void SortShouldReturnSortedCarsByMakeWhenTheParameterIsMake()
        {
            string parameter = "make";
            var cars = (ICollection<Car>)this.GetModel(() => this.controller.Sort(parameter));
            var expected = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };

            var resultFromSorting = (ICollection<Car>)this.GetModel(() => this.controller.Sort(parameter));
            var actual = resultFromSorting.ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SortShouldReturnSortedCarsByYearWhenTheParameterIsYear()
        {
            string parameter = "year";
            var cars = (ICollection<Car>)this.GetModel(() => this.controller.Sort(parameter));
            var expected = new List<Car>
            {
                new Car { Id = 1, Make = "Audi", Model = "A5", Year = 2005 },
                new Car { Id = 3, Make = "BMW", Model = "330d", Year = 2007 },
                new Car { Id = 2, Make = "BMW", Model = "325i", Year = 2008 },
                new Car { Id = 4, Make = "Opel", Model = "Astra", Year = 2010 },
            };

            var resultFromSorting = (ICollection<Car>)this.GetModel(() => this.controller.Sort(parameter));
            var actual = resultFromSorting.ToList();

            CollectionAssert.AreEqual(expected, actual);
        }

        private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
