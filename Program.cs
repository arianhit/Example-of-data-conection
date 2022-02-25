using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;

namespace Performance
{
    class Program
    {
        static void Main(string[] args)
        {
            //we need an sql connection variable
            SqlConnection con;
            //we need the database address as an string
            string str;

            string courseName;
            int courseTotalHours;
            int courseId;
            try
            {
                //database address
                str= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= G:\My Drive\University Sheffieeld Hallam\Y1\Software Project\Performance\Performance\ERDTabales.mdf ;Integrated Security=True";
                
                //creating connection with the database address
                con = new SqlConnection(str);

                //open connection
                con.Open();
                //writing a massage that databas is connected
                Console.WriteLine("Database Connected");

                Console.WriteLine("\n Enter Your Course id");
                courseId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n Enter Your Course name");
                courseName = Console.ReadLine();
                Console.WriteLine("\n Enter Your Course total hours");
                courseTotalHours = Convert.ToInt32(Console.ReadLine());
                string queryInsert = "INSERT INTO Course (Course_Id,Course_Name,Course_Total_Hours) VALUES (" + courseId + ",'" + courseName + "'," + courseTotalHours + ") ";

                SqlCommand ins = new SqlCommand(queryInsert, con);
                ins.ExecuteNonQuery();

                Console.WriteLine("\n Data Stored Into Database");

                string queryRead = "SELECT * FROM Course";
                SqlCommand read = new SqlCommand(queryRead, con);
                SqlDataReader dtreader = read.ExecuteReader();
                while (dtreader.Read())
                {
                    Console.WriteLine("\n Course name :" + dtreader.GetValue(1).ToString());
                    Console.WriteLine("\n Course Total hours :" + dtreader.GetValue(2).ToString());
                }
            } //catch for any error from sql
            catch (SqlException x)
            {
                Console.WriteLine(x.Message);
            }
            Console.ReadLine();
        }
    }
}
