using Northwind.Tasks.Utilities;
using System.Collections.Generic;

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
        private string contactTitle;
        private string address;
        private string city;
        private string region;
        private string postalCode;
        private string country;
        private string contactName;
        private string phone;
        private string fax;

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

        public string ContactName
        {
            get
            {
                return this.contactName;
            }

            set
            {
                Validator<string>.ValidateStringLenght(value, MinLenth, ContactNameMaxLenth, nameof(ContactName));
                this.contactName = value;
            }
        }


        public string ContactTitle
        {
            get
            {
                return this.contactTitle;
            }

            set
            {
                Validator<string>.ValidateStringLenght(value, MinLenth, ContactTitleMaxLenghth, nameof(ContactTitle));
                this.contactTitle = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            set
            {
                Validator<string>.ValidateStringLenght(value, MinLenth, AddressMaxLenghth, nameof(Address));
                this.address = value;
            }
        }


        public string City
        {
            get
            {
                return this.city;
            }

            set
            {
                Validator<string>.ValidateStringLenght(value, MinLenth, CityMaxLenghth, nameof(City));
                this.city = value;
            }
        }

        public string Region
        {
            get
            {
                return this.region;
            }

            set
            {
                Validator<string>.ValidateStringLenght(value, MinLenth, RegionMaxLenghth, nameof(Region));
                this.region = value;
            }
        }

        public string PostalCode
        {
            get
            {
                return this.postalCode;
            }

            set
            {
                Validator<string>.ValidateStringLenght(value, MinLenth, PostalCodeMaxLenghth, nameof(PostalCode));
                this.postalCode = value;
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }

            set
            {
                Validator<string>.ValidateStringLenght(value, MinLenth, CountryMaxLenghth, nameof(Country));
                this.country = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }

            set
            {
                Validator<string>.ValidateStringLenght(value, MinLenth, PhoneMaxLenghth, nameof(Phone));
                this.phone = value;
            }
        }

        public string Fax
        {
            get
            {
                return this.fax;
            }
            set
            {
                Validator<string>.ValidateStringLenght(value, MinLenth, FaxMaxLenghth, nameof(Fax));
                this.fax = value;
            }
        }
    }
}

