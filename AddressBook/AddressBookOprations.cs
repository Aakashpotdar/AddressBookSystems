using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace AddressBook
{
    class AddressBookOprations
    {
        List<Address> addresses;
        Dictionary<string, Address> DictionaryObj = new Dictionary<string, Address>();

        public AddressBookOprations()
        {
            addresses = new List<Address>();
        }
        public void addingCsvData()
        {
            string path = @"C:/Users/AKASH/source/repos/AddressBook/AddressBook/Info.csv";
            using(var reader=new StreamReader(path))
            using(var csv=new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var record = csv.GetRecords<Address>().ToList();
                foreach(Address i in record)
                {
                    Console.Write(" "+i.name);
                    Console.Write(" " + i.lastName);
                    Console.Write(" " + i.address);
                    Console.Write(" " + i.city);
                    Console.Write(" " + i.state);
                    Console.Write(" " + i.mobilenum);
                    Console.Write(" " + i.MailId);
                }
            }

        }
        public bool add(string name, string lastName, string address, string city, string state, int zipCode, double mobileNum, string mailId)
        {
            Address addr = new Address(name, lastName, address, city, state, zipCode, mobileNum, mailId);
            Address result = find(name);

            if (result == null)
            {
                addresses.Add(addr);
                DictionaryObj.Add(city, addr);
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
        public void SearchNameByCityName(string CityName)
        {
            foreach (Address per in addresses.FindAll(e => (e.city == CityName)).ToList())
            {
                Console.WriteLine("Name: " + per.name + " City: " + per.city);
            }
        }

        public void SearchNumberOfAddressByCity(String CityName)
        {
            int count = 0;
            foreach (Address per in addresses.FindAll(e => (e.city == CityName)).ToList())
            {
                count++;
            }
            Console.WriteLine(" City: " + CityName+" number of entries is "+count);
        }
        public void SortData()
        {
            addresses.Sort();
            Console.WriteLine("Sorted data");
            foreach (Address i in addresses)
            {
                Console.WriteLine(i);
            }
        }

        public void SortingByCityName()
        {
            var list = DictionaryObj.Keys.ToList();
            list.Sort();
            Console.WriteLine("the sorted data ky city name");
            foreach (var per in list)
            {
                Console.WriteLine(per);
            }

        }
    }
}
