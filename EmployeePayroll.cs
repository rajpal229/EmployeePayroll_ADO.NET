﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace EmployeePayroll_ADO.NET
{
    public class EmployeePayroll
    {
        
        public static void GetAllEmployee()
        {
            SqlConnection connection = new SqlConnection(@"Data Source=I-CHANGE-THE-NA\SQLEXPRESS;Initial catalog=Employee_Payroll;Integrated Security=true");
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Select * from Employee_payroll";
                cmd.Connection = connection;
                connection.Open();
                Console.WriteLine("Connection Open!");
                SqlDataReader sdr = cmd.ExecuteReader();
                while(sdr.Read())
                {
                    int id = (int)sdr["Id"];
                    Console.Write(id+ " ");
                    string Name = (string)sdr["Name"];
                    Console.Write(Name+ " ");
                    long Salary = (long)sdr["Salary"];
                    Console.Write(Salary + " ");
                    DateTime Startdate = (DateTime)sdr["Startdate"];
                    Console.Write(Startdate.ToShortDateString() + " ");
                    string Gender = (string)sdr["Gender"];
                    Console.Write(Gender + " ");
                    long phone;
                    if (DBNull.Value.Equals(sdr["phone"]))
                    {
                        phone = 0;
                        Console.Write("Null ");
                    }
                    else
                    {
                        phone = (long)sdr["phone"];
                        Console.Write(phone + " ");
                    }
                        string Emp_Address = (string)sdr["Emp_Address"];
                    Console.Write(Emp_Address + " ");
                    string Department = (string)sdr["Department"];
                    Console.WriteLine(Department);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
