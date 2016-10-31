using Northwind.Tasks.Utilities;

namespace Northwind.Tasks.ViewModels
{
    public class CustomerView
    {
        private const int CompanyNameMaxLenth = 40;
        private const int ContactNameMaxLenth = 30;
        private const int ContactTitleMaxLenghth = 30;
        private const int AddressMaxLenghth = 60;
        private const int CityMaxLenghth = 15;
        private const int RegionMaxLenghth = 15;
        private const int PostalCodeMaxLenghth = 10;
        private const int CountryMaxLenghth = 15;
        private const int PhoneMaxLenghth = 24;
        private const int FaxMaxLenghth = 24;
        private const int MinLenth = 0;

        private string customerID;
        private string companyName;

        public string CustomerID
        {
            get
            {
                return this.customerID;
            }

            set
            {
                Validator<string>.ValidateNull(value, nameof(CustomerID));
               Validator<string>.ValidateStringLenght(value, Constants.IdLenght, Constants.IdLenght, nameof(CustomerID));
                this.customerID = value;
            }
        }

        public string CompanyName
        {
            get
            {
                return this.companyName;
            }

            set
            {
                Validator<string>.ValidateNull(value, nameof(companyName));
                 Validator<string>.ValidateStringLenght(value, MinLenth, CompanyNameMaxLenth, nameof(CompanyName));
                this.companyName = value;
            }
        }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Fax { get; set; }


    }
}

