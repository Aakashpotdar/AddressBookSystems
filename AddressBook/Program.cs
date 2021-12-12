using System;

namespace AddressBook
{
    class Program
    {
        class AddressPrompt
        {
            AddressBookOprations book;
            public AddressPrompt()
            {
                book = new AddressBookOprations();
            }
            static void Main(string[] args)
            {
                string selection = "";
                AddressPrompt prompt = new AddressPrompt();

                prompt.displayMenu();
                while (!selection.ToUpper().Equals("Q"))
                {
                    Console.WriteLine("Selection: ");
                    selection = Console.ReadLine();
                    prompt.performAction(selection);
                }
            }
            void displayMenu()
            {
                Console.WriteLine("O - to add Csv data");
                Console.WriteLine("A - Add an Data");
                Console.WriteLine("E - Edit an Data");
                Console.WriteLine("D - Delete an Data");
                Console.WriteLine("S - Search an city name");
                Console.WriteLine("C - Search an names using city name");
                Console.WriteLine("N - Search number of data with City name");
                Console.WriteLine("F - Sort the data");
                Console.WriteLine("W - Sort the data by city name");
                Console.WriteLine("M - Write data in Json File");
                Console.WriteLine("T - Read data from DataBase");
                Console.WriteLine("U - Read data from DataBase by name");
                Console.WriteLine("Q - Quit");
            }
            void performAction(string selection)
            {
                string name = "";
                string lastName = "";
                string address = "";
                string city = "";
                string state = "";
                int zipCode;
                double mobileNum;
                string MailId = "";
                switch (selection.ToUpper())
                {
                    case "A":
                        Console.WriteLine("Enter First Name:,Last Name:,adress:,city:,state:,zip cod:,mobile number:,Mail Id: ");

                        name = Console.ReadLine();
                        lastName = Console.ReadLine();
                        address = Console.ReadLine();
                        city = Console.ReadLine();
                        state = Console.ReadLine();
                        zipCode = int.Parse(Console.ReadLine());
                        mobileNum = double.Parse(Console.ReadLine());
                        MailId = Console.ReadLine();
                        if (book.add(name, lastName, address, city, state, zipCode, mobileNum, MailId))
                        {
                            Console.WriteLine("Address successfully added!");
                        }
                        else
                        {
                            Console.WriteLine("An address is already on file for {0}.", name);
                        }
                        break;
                    case "D":
                        Console.WriteLine("Enter Name to Delete: ");
                        name = Console.ReadLine();
                        if (book.remove(name))
                        {
                            Console.WriteLine("Address successfully removed");
                        }
                        else
                        {
                            Console.WriteLine("Address for {0} could not be found.", name);
                        }
                        break;
                    case "E":
                        Console.WriteLine("Enter Name to Edit: ");
                        name = Console.ReadLine();
                        Address addr = book.find(name);
                        if (addr == null)
                        {
                            Console.WriteLine("Address for {0} count not be found.", name);
                        }
                        else
                        {
                            Console.WriteLine("Enter new Address,city,state,zip code,mobile number,mail id");
                            addr.address = Console.ReadLine();
                            addr.city = Console.ReadLine();
                            addr.state = Console.ReadLine();
                            addr.zipCode = int.Parse(Console.ReadLine());
                            addr.mobilenum = double.Parse(Console.ReadLine());
                            addr.MailId = Console.ReadLine();
                            Console.WriteLine("Data updated for {0}", name);
                        }
                        break;
                    case "S":
                        Console.WriteLine("enter City name");
                        string CityName = Console.ReadLine();
                        book.SearchCity(CityName);
                        break;
                    case "C":
                        Console.WriteLine("enter City name");
                        CityName = Console.ReadLine();
                        book.SearchNameByCityName(CityName);
                        break;
                    case "N":
                        Console.WriteLine("enter City name");
                        CityName = Console.ReadLine();
                        book.SearchNumberOfAddressByCity(CityName);
                        break;
                    case "F":
                        
                        book.SortData();
                        break;
                    case "W":

                        book.SortingByCityName();
                        break;
                    case "O":

                        book.addingCsvData();
                        break;
                    case "M":

                        book.WritingDataToJsonFile();
                        break;
                    case "T":
                        OprationsOnDataBase obj = new OprationsOnDataBase();
                        string query = "Select First_Name,Last_Name,city,state,zip,phone_number,email,Type from AddressBook";
                        obj.GetAllEmpoyee(query);
                        break;
                    case "U":
                        OprationsOnDataBase obj1 = new OprationsOnDataBase();
                        Console.WriteLine("enter name");
                        string Firstname = Console.ReadLine();
                        query = "Select * from AddressBook where First_Name="+"'"+Firstname+"'";
                        obj1.GetAllEmpoyee(query);
                        break;
                }

            }
        }
    }
}
