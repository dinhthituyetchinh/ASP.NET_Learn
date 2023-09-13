using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DinhThiTuyetChinh_Exercise2.Models;
using System.Data.SqlClient;
namespace DinhThiTuyetChinh_Exercise2.Services
{
    public class KhoaService
    {
        public static string conStr = "Data Source = TUYETCHINH\\SQLSERVER1; Initial Catalog = QLSV; Integrated Security = true";

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
                    string selectStr = "SELECT COUNT(*) FROM KHOA WHERE ='" + ma + "'";
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
            catch(Exception ex)
            {
                return false;
            }           
        }
        public static List<KhoaModel> excuteSQL()
        {
          List<KhoaModel> khoaList = new List<KhoaModel>();

            using(SqlConnection conn = new SqlConnection(conStr))
            {
                if(conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
                string selectStr = "SELECT * FROM KHOA";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = selectStr;
                cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    string idKhoa = rdr["MAKHOA"].ToString();
                    string nameKhoa = rdr["TENKHOA"].ToString();
                    KhoaModel model = new KhoaModel();
                    model.Id = idKhoa;
                    model.Name = nameKhoa;
                    khoaList.Add(model); 
                }
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return khoaList;
        }
    }
}