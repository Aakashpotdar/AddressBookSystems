using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AddressBook
{
    class AddressBookOprations
    {
        List<Address> addresses;

        public AddressBookOprations()
        {
            addresses = new List<Address>();
        }

        public bool add(string name, string lastName, string address, string city, string state, int zipCode, double mobileNum, string mailId)
        {
            Address addr = new Address(name, lastName, address, city, state, zipCode, mobileNum, mailId);
            Address result = find(name);

            if (result == null)
            {
                addresses.Add(addr);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool remove(string name)
        {
            Address addr = find(name);

            if (addr != null)
            {
                addresses.Remove(addr);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void list(Action<Address> action)
        {
            addresses.ForEach(action);
        }
        public Address find(string name)
        {
            Address addr = addresses.Find((a) => a.name == name);
            return addr;
        }
        public void SearchCity(string CityName)
        {
            bool AddressByCity = addresses.Any(a => (a.city == CityName));
            if (AddressByCity == true)
            {
                Console.WriteLine("the City is present");
            }
            else
            {
                Console.WriteLine("the City is not present");
            }
        }
    }
}
