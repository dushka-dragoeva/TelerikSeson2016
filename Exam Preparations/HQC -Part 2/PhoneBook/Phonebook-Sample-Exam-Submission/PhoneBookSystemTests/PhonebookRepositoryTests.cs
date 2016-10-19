using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneBookSystem;

namespace PhoneBookSystemTests
{
    [TestClass]
    public class PhonebookRepositoryTests
    {
        [TestMethod]
        public void TestAddPhoneOnce()
        {
            string name = "Kalina";
            string[] item = new string[] { "+359899777235", "+359899777235" };
            PhonebookRepository phoneBookRepository = new PhonebookRepository();
            phoneBookRepository.AddPhone(name, item);

            Assert.AreEqual(phoneBookRepository.Count, 1);
        }

        [TestMethod]
        public void TestAddPhoneOnesSameName()
        {
            string name = "Kalina";
            string[] item = new string[] { "+359899777235", "+359899777235" };
            string name2 = "kalina";
            string[] item2 = new string[] { "+359899777235", "+359899777235" };
            PhonebookRepository phoneBookRepository = new PhonebookRepository();
            phoneBookRepository.AddPhone(name, item);
            phoneBookRepository.AddPhone(name2, item2);

            Assert.AreEqual(phoneBookRepository.Count, 1);
        }

        [TestMethod]
        public void TestAddPhoneMultiple()
        {
            string name = "Kalina";
            string[] item = new string[] { "+359899777235", "+359899777235" };
            string name2 = "Kalin";
            string[] item2 = new string[] { "+359899777235", "+359899777235" };
            PhonebookRepository phoneBookRepository = new PhonebookRepository();
            phoneBookRepository.AddPhone(name, item);
            phoneBookRepository.AddPhone(name2, item2);

            Assert.AreEqual(phoneBookRepository.Count, 2);
        }

        [TestMethod]
        public void TestChangePhoneOnece()
        {
            string name = "Kalina";
            string[] item = new string[] { "+359899777235", "+359899777235" };
            PhonebookRepository phoneBookRepository = new PhonebookRepository();
            phoneBookRepository.AddPhone(name, item);
            int result = phoneBookRepository.ChangePhone("+359899777235", "+359899777444");


            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void TestChangePhoneMultiple()
        {
            string name = "Kalina";
            string[] item = new string[] { "+359899777235", "+359899777235" };
            string name2 = "Kalin";
            string[] item2 = new string[] { "+359899777235", "+359899777235" };
            PhonebookRepository phoneBookRepository = new PhonebookRepository();
            phoneBookRepository.AddPhone(name, item);
            phoneBookRepository.AddPhone(name2, item2);

            int result = phoneBookRepository.ChangePhone("+359899777235", "+359899777444");


            Assert.AreEqual(result, 2);
        }

        [TestMethod]
        public void TestListEntries()
        {
            StringBuilder output = new StringBuilder();
            string name = "Kalina";
            string[] item = new string[] { "+359899777135", "+359899777235" };
            PhonebookRepository phoneBookRepository = new PhonebookRepository();
            phoneBookRepository.AddPhone(name, item);
            IEnumerable<PhoneBookContactOutput> entries = phoneBookRepository.ListEntries(0, 1);

            foreach (var entry in entries)
            {
                output.AppendLine(entry.ToString());
            }

            string result = output.ToString().Trim();
            string expected = "[Kalina: +359899777135, +359899777235]";

            Assert.AreEqual(result, expected);
        }
    }
}