using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook
{
    class Address
    {
        public string name;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public int zipCode;
        public double mobilenum;
        public string MailId;

        public Address(string name, string lastName, string address, string city, string state, int zipCode, double mobileNum, string MailId)
        {
            this.name = name;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            this.state = state;
            this.mobilenum = mobileNum;
            this.MailId = MailId;
        }
    }
}
