using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DemoXuLyDuLieu.Models;

namespace DemoXuLyDuLieu.Services
{
    public class SubjectService
    {
        public static string conStr = "Data Source = TUYETCHINH\\SQLSERVER1; Initial Catalog = QLSV; Integrated Security = true";
        public static List<Subject> ExcuteSQL()
        {
            List<Subject> subjectList = new List<Subject>();

            using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = conStr;
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    string selectStr = "SELECT * FROM MONHOC";
                    SqlCommand cmd = new SqlCommand(selectStr, connection);
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string mhId = rdr["MAMH"].ToString();
                        string mhName = rdr["TENMH"].ToString();
                        Subject subject = new Subject(mhId, mhName);
                    subjectList.Add(subject);
                    }
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }   
            return subjectList;
        }

        public static bool checkPrimary(string ma)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    string selectStr = "SELECT COUNT(*) FROM KHOA WHERE MAKHOA='" + ma + "'";
                    SqlCommand cmd = new SqlCommand(selectStr, conn);
                    int count = (int)cmd.ExecuteScalar();
                    
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        conn.Close();
                    }
                    if (count >= 1)
                        return false;
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void addSql(string id, string name)
        {
                using (SqlConnection connection = new SqlConnection())
                {
                    connection.ConnectionString = conStr;
                    if (connection.State == System.Data.ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    string selectStr = $"INSERT INTO MONHOC VALUES('{id}', N'{name}')";
                    SqlCommand cmd = new SqlCommand(selectStr, connection);
                    cmd.ExecuteNonQuery();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

           
        }

        public static void deleteSql(string id)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = conStr;
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                string selectStr = $"DELETE MONHOC WHERE MAMH = '{id}'";
                SqlCommand cmd = new SqlCommand(selectStr, connection);
                cmd.ExecuteNonQuery();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public static Subject find(string id)
        {
            List<Subject> subjectList = new List<Subject>();

            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = conStr;
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                string selectStr = "SELECT * FROM MONHOC WHERE MAMH ='"+id+"'";
                SqlCommand cmd = new SqlCommand(selectStr, connection);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    string mhId = rdr["MAMH"].ToString();
                    string mhName = rdr["TENMH"].ToString();
                    Subject subject = new Subject(mhId, mhName);
                    subjectList.Add(subject);
                }
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return subjectList[0];
        }

        public static void updateSql(string id, string name)
        {
            int c = id.Count();
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = conStr;
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                string selectStr = $"UPDATE MONHOC SET TENMH = '{name}' WHERE MAMH = '{id.Trim()}'";
                SqlCommand cmd = new SqlCommand(selectStr, connection);
                cmd.ExecuteNonQuery();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

    }
}