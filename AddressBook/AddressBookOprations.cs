using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using Newtonsoft.Json;
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
            OprationsOnDataBase addToDB = new OprationsOnDataBase();
           
            string path = @"C:/Users/AKASH/source/repos/AddressBook/AddressBook/InfoData.csv";
            using(var reader=new StreamReader(path))
            using(var csv=new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var record = csv.GetRecords<Address>().ToList();
                foreach(Address i in record)
                {
                    
                    addresses.Add(i);
                    Console.Write(" "+i.name);
                    Console.Write(" " + i.lastName);
                    Console.Write(" " + i.address);
                    Console.Write(" " + i.city);
                    Console.Write(" " + i.state);
                    Console.Write(" " + i.zipCode);
                    Console.Write(" " + i.mobilenum);
                    Console.Write(" " + i.MailId);
                    Console.WriteLine();
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
            Console.WriteLine("Sorted data");
            foreach (var i in addresses.OrderBy(e => e.name))
            {
                Console.WriteLine(i.name+" "+ i.lastName + " " + i.city + " " +i.mobilenum);
            }
        }

        public void SortingByCityName()
        {
            Console.WriteLine("The data is sorted by city name");
            foreach (var per in addresses.OrderBy(e=>e.city))
            {
                Console.WriteLine(per.city + " "+per.name + " " + per.lastName + " " + per.mobilenum);
            }
        }
        public void WritingDataToJsonFile()
        {
            string path = @"C:/Users/AKASH/source/repos/AddressBook/AddressBook/Data.Json";
            JsonSerializer read = new JsonSerializer();
            using (StreamWriter wrt = new StreamWriter(path))
            using (JsonWriter w = new JsonTextWriter(wrt))
            {
                read.Serialize(w, addresses);
            }
        }
    }
}
