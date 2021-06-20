using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace atp2labtask1.Models.Database
{
    public class Database
    {
        public Students Students { get; set; } 
        public Database()
        {
            string connString = @"Server=DESKTOP-VKE7MU9;Database=StudentManagement;Integrated Security=true;";
            SqlConnection conn = new SqlConnection(connString);

            Students = new Students(conn);

        }
    }
}