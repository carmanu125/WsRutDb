using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServicesRutDb.Models
{
    public class DataBase
    {


        public int ExecuteSQL(string sql)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Rut_DB"].ToString());
            int res = 0;
            try
            {

                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);

                 res = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();

            }

            return res;
        }

        public DataTable ConsultSQL(string sql)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Rut_DB"].ToString());
            DataTable dt = new DataTable();
            try
            {
                con.Open();


                SqlCommand cmd = new SqlCommand(sql, con);

                SqlDataReader reader =
                      cmd.ExecuteReader();
                

                dt.Load(reader);
            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();

            }

            return dt;
        }

        public int ConsultInt(string sql)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Rut_DB"].ToString());
            int value = 0;
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);

                value = (int)
                      cmd.ExecuteScalar();

            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }

            return value;
        }

        public string ConsultString(string sql)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Rut_DB"].ToString());
            string value = "";
            try
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(sql, con);

                value = (string)
                      cmd.ExecuteScalar();

            }
            catch (Exception)
            {

            }
            finally
            {
                con.Close();
            }

            return value;
        }

    }
}