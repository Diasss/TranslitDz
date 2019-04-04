using NickBuhro.Translit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw
{
    class Program
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static SqlConnection conn = new SqlConnection(connStr);
        public static SqlCommand cmd = null;

        static void Main(string[] args)
        {

        }

        public static void CreateEmail()
        {
            SqlDataReader rdr = null;
            try
            {
                conn.Open();
                cmd = new SqlCommand("select * from Students", conn);
                rdr = cmd.ExecuteReader();
                foreach (SqlDataReader r in rdr)
                {
                    foreach (var r1 in (SqlDataReader)r["FName"])
                    {
                        string tempfName = Transliteration.CyrillicToLatin((String)r1, Language.Russian).Substring(0, 1);
                        
                    }

                }
            }
            catch (Exception e)
            {

            }
        
        }
    }
}

