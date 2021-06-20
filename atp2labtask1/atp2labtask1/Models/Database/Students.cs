using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace atp2labtask1.Models.Database
{
    public class Students
    {
        SqlConnection conn;

        public Students(SqlConnection conn)
        {
            this.conn = conn;
        }
        public void Insert(Student S)
        {
            string query = "Insert into Students values(@name,@dob,@cgpa,@credit,@deptid)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", S.Name);
            cmd.Parameters.AddWithValue("@dob", S.Dob);
            cmd.Parameters.AddWithValue("@cgpa", S.Cgpa);
            cmd.Parameters.AddWithValue("@credit", S.Credit);
            cmd.Parameters.AddWithValue("@deptid", S.DeptId);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();
            string query = "select * from Students";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                Student S = new Student()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Dob = reader.GetDateTime(reader.GetOrdinal("Dob")),
                    Credit = reader.GetInt32(reader.GetOrdinal("Credit")),
                    Cgpa = reader.GetDouble(reader.GetOrdinal("Cgpa")),
                    DeptId = reader.GetInt32(reader.GetOrdinal("DeptId")),
                };
                students.Add(S);
            }
            conn.Close();
            return students;
        }

        public Student Get(int id)
        {
            Student S = null;
            string query = $"select * from Students Where Id={id}";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                S = new Student()
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Dob = reader.GetDateTime(reader.GetOrdinal("Dob")),
                    Credit = reader.GetInt32(reader.GetOrdinal("Credit")),
                    Cgpa = reader.GetDouble(reader.GetOrdinal("Cgpa")),
                    DeptId = reader.GetInt32(reader.GetOrdinal("DeptId")),
                };
            }
            conn.Close();
            return S;
        }

        public void Update(Student S)
        {
            string query = $"Update Students Set Name='{S.Name}',Dob='{S.Dob}', Credit={S.Credit}, Cgpa={S.Cgpa}, DeptId={S.DeptId} where Id={S.Id}";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Delete(int id)
        {
            string query = $"Delete from Students WHERE Id = {id}";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}