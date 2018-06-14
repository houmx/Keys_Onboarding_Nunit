using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys_Onboarding.Database
{
    class DBUtils
    {
        private  SqlConnection conn;

        public DBUtils()
        {

            string connString = @"Data Source=20.188.232.226;Initial Catalog=Keys;Persist Security Info=True;User ID=KeyAppUser;Password=MVPStudioKeysUser!23";
            conn = new SqlConnection(connString);
        }
        
        public void DeleteOperation(string sqlQuery)
        {

        }
        public DataTable SelectOperation(string sqlQuery)
        {
            DataTable dt = new DataTable();

            try
            {
                //connect to database
                conn.Open();
                SqlDataAdapter adp = new SqlDataAdapter(sqlQuery, conn);
                //store query result into dataset object
                adp.Fill(dt);
                //close connection
                conn.Close();
            }
            catch (Exception e)
            {
                Console.Write("getting data from database error: " + e.Message);
                return new DataTable();
            }

            return dt;
        }
    }

}
