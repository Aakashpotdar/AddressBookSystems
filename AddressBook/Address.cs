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
        public int code;
        public double mobilenum;
        public string MailId;

        public Address(string name, string lastName, string address, string city, string state, int zipCode, double mobileNum, string mailId)
        {
            this.name = name;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.code = zipCode;
            this.state = state;
            this.code = zipCode;
            this.mobilenum = mobileNum;
            this.MailId = mailId;
        }
    }
}
