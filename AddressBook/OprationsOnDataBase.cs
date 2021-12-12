using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBook
{
    public class OprationsOnDataBase
    {
        public static string ConnectionLink = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AddressBook;Integrated Security=True";
        SqlConnection connection = new SqlConnection(ConnectionLink);

        public void GetAllEmpoyee(string query)
        {
            try
            {
                AddressDetails employeeModel = new AddressDetails();
                using (this.connection)
                {
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
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
                    this.connection.Close();
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

        public void AddDataToDB(Addresses a)
        {
            try
            {
                using (this.connection) 
                {
                    SqlCommand com = new SqlCommand("ApAddAddress", this.connection);
                    com.CommandType = System.Data.CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@First_Name", a.First_Name);
                    com.Parameters.AddWithValue("@Last_Name", a.Last_Name);
                    com.Parameters.AddWithValue("@city", a.city);
                    com.Parameters.AddWithValue("@state", a.state);
                    com.Parameters.AddWithValue("@zip", a.zip);
                    com.Parameters.AddWithValue("@phone_Number", a.phoneNumber);
                    com.Parameters.AddWithValue("@email", a.email);
                    com.Parameters.AddWithValue("@Type", a.Type);

                    this.connection.Open();
                    var result = com.ExecuteNonQuery();
                    this.connection.Close();

                    
                }
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                this.connection.Close();
            }

        }
    }
}
