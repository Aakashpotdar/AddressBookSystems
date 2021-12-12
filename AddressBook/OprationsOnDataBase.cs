using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBook
{
    class OprationsOnDataBase
    {
        public void GetAllEmpoyee(string query)
        {
            string ConnectionLink = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBook;Integrated Security=True";
            SqlConnection connection = new SqlConnection(ConnectionLink);
            try
            {
                AddressDetails employeeModel = new AddressDetails();
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.First_Name = dr.GetString(0);
                            employeeModel.Last_Name = dr.GetString(1);
                            employeeModel.City = dr.GetString(2);
                            employeeModel.State = dr.GetString(3);
                            employeeModel.ZipCode = dr.GetInt32(4);
                            employeeModel.MobileNumber = dr.GetInt32(5);
                            employeeModel.EmailId = dr.GetString(6);
                            employeeModel.Type = dr.GetString(7);


                            Console.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7}", employeeModel.First_Name, employeeModel.Last_Name, employeeModel.State, employeeModel.City, employeeModel.MobileNumber, employeeModel.EmailId, employeeModel.Type, employeeModel.ZipCode);
                        }
                    }
                    else
                    {
                        Console.WriteLine("no data found");
                    }
                    dr.Close();
                    connection.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
