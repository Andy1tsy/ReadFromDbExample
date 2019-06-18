using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

namespace DBWork
{
    class Program
    {
       


        static void Main(string[] args)
        {
           
            DapperMethod();
           // EntityFrameworkMethod();
            ADONetMethod();
            Console.ReadLine();
        }
        /// <summary>
        /// this method uses SQLite native resourses for processing query SELECT
        /// </summary>
        private static void ADONetMethod()
        {
            SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source = d:\\Workers.db");
            sqlite_conn.Open();
            SQLiteCommand sqlite_cmd = sqlite_conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Worker";
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            Console.WriteLine("SQLite reder method:");
            Console.WriteLine("Workers Database");
            Console.WriteLine("Id\tName\tBossId\tSpecialityId\tIsBoss");

            while (sqlite_datareader.Read())
            {
                string myreader0 = sqlite_datareader.GetValue(0).ToString();
                string myreader1 = sqlite_datareader.GetValue(1).ToString();
                string myreader2 = sqlite_datareader.GetValue(2).ToString();
                string myreader3 = sqlite_datareader.GetValue(3).ToString();
                string myreader4 = sqlite_datareader.GetValue(4).ToString();
                Console.WriteLine($"{myreader0}\t{myreader1}\t{myreader2}\t{myreader3}\t\t{myreader4}");
            }
            SQLiteCommand sqlite_cmd2 = sqlite_conn.CreateCommand();
            sqlite_cmd2.CommandText = "SELECT * FROM Speciality";
            SQLiteDataReader sqlite_datareader2 = sqlite_cmd2.ExecuteReader();
            Console.WriteLine("Speciality Database");
            Console.WriteLine("Id\tName");
            while (sqlite_datareader2.Read())
            {
                string myreader0 = sqlite_datareader2.GetValue(0).ToString();
                string myreader1 = sqlite_datareader2.GetValue(1).ToString();
                //string myreader2 = sqlite_datareader2.GetValue(2).ToString();
                Console.WriteLine($"{myreader0}\t{myreader1}\t");
            }
            sqlite_conn.Close();
        }
        /// <summary>
        /// this method uses Dapper  resourses for processing query SELECT
        /// </summary>
        private static void DapperMethod()
        {
            using (IDbConnection connecton = new SQLiteConnection("Data Source = d:\\Workers.db"))
            {
                connecton.Open();
                var queryResult = connecton.Query<Worker>("SELECT * FROM Worker", new DynamicParameters()).ToList();
                Console.WriteLine("Dapper reder method:");
                Console.WriteLine("Workers Database");
                Console.WriteLine("Id\tName\tBossId\tSpecialityId\tIsBoss");
                foreach (var item in queryResult)
                {
                    Console.WriteLine(item.ToString()); 
                }
                var queryResult2 = connecton.Query<Speciality>("SELECT * FROM Speciality", new DynamicParameters()).ToList();
                Console.WriteLine("Speciality Database");
                Console.WriteLine("Id\tName");
                foreach (var item in queryResult2)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }

        /// <summary>
        /// method which uses EntityFramework
        /// </summary>
        private static void EntityFrameworkMethod()
        {
            using ( var workerContext = new WorkerContext())
            {
                var workers = workerContext.Workers;
                foreach (var item in workers)
                {
                    Console.WriteLine(item); 
                }
            }
            using (var specialityContext = new SpecialityContext())
            {
                var specialities = specialityContext.Specialities;
                foreach (var item in specialities)
                {
                    Console.WriteLine(item);
                }
            }
               
          

        }

      

    }
}
