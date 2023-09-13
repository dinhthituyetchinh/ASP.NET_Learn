using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using DinhThiTuyetChinh_Exercise3.Models;
using System.Data;

namespace DinhThiTuyetChinh_Exercise3.Services
{
    public class KhoaService
    {
        public static string conStr = "Data Source = TUYETCHINH\\SQLSERVER1; Initial Catalog = QLSV; Integrated Security = true";
        public static List<KhoaModel> excuteSQL()
        {
            List<KhoaModel> khoaList = new List<KhoaModel>();
            using(SqlConnection conn = new SqlConnection(conStr))
            {
                string selectStr = "SELECT * FROM KHOA";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(selectStr, conn);
                da.Fill(ds, "Khoa");
                DataTable dt = new DataTable();
                dt = ds.Tables["Khoa"];
                foreach(DataRow dr in dt.Rows)
                {
                    string ma = dr["MAKHOA"].ToString();
                    string ten = dr["TENKHOA"].ToString();
                    var khoa = new KhoaModel(ma, ten);
                    khoaList.Add(khoa);
                }
            }
            return khoaList;
        }
    }
}