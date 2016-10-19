using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhoneBook.ConsoleApplication.Contracts;
using PhoneBook.ConsoleApplication.Models;


namespace PhoneBook.Tests.PhonebookRepository
{
    /// <summary>
    /// Summary description for AddPhone_Should
    /// </summary>
    [TestClass]
    public class AddPhone_Should
    {
        public AddPhone_Should()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void AddSinglePhonebookEntry_WhenValidNameAnddPhoneNumberArePassed()
        {
            var repo = new PhoneBook.ConsoleApplication.Models.PhonebookRepository();

            var actual=  repo.AddPhone("Niki", new string[] { "+359899777235" });

            Assert.IsTrue(actual);
            Assert.AreEqual(1, repo.Entries.Count);
            Assert.AreEqual(1, repo.Entries[0].PhoneNumbers.Count);

        }
    }
}
