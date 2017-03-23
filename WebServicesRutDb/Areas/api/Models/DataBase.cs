using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServicesRutDb.Models
{
    public class DataBase
    {
        Connection objConnection;
        SqlCommand objCommand = new SqlCommand();
        SqlTransaction objTran;
        //Parameter objParameter;

        public DataBase()
        {
             objConnection = new Connection();
        }

        public DataTable ConsultSQL(string sql)
        {
            try
            {
                objCommand.Connection = objConnection.connectionDB;
                objCommand.CommandText = sql;
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();

                if (objTran != null)
                {
                    objCommand.Transaction = objTran;
                }

                //objCommand.Parameters.Add("@option", SqlDbType.VarChar).Value = Option;
                //objCommand.Parameters.Add("@error_Code", SqlDbType.Int).Direction = ParameterDirection.Output;
                objConnection.OpenConnection();

                try
                {
                    da.SelectCommand = objCommand;
                    da.Fill(ds);
                    dt = ds.Tables[0];
                    //return dt;
                }
                catch (Exception ex)
                {
                    objConnection.CloseConnection();
                    return null;
                }
                finally
                {
                    DataTable dterror;

                    if (ds.Tables.Count > 1)
                    {
                        dterror = ds.Tables[1];
                        DataRow row = dterror.Rows[0];
                        int error = Convert.ToInt32(row["error_code"]);
                        if (error > 0)
                        {
                            dt = dterror;
                        }
                    }
                    objConnection.CloseConnection();
                    objCommand.Dispose();
                }
                return dt;


            }
            catch (Exception ex)
            {
                //ManejoError.Muestra(ex.Message)
                return null;
            }


        }

        public int ExecuteSQL(string sql)
        {
            try
            {
                int result = 0;
                objCommand.Connection = objConnection.connectionDB;
                objCommand.CommandText = sql;

                if (objTran != null)
                {
                    objCommand.Transaction = objTran;
                }

                //objCommand.Parameters.Add("@option", SqlDbType.VarChar).Value = Option;
                //objCommand.Parameters.Add("@error_Code", SqlDbType.Int).Direction = ParameterDirection.Output;
                objConnection.OpenConnection();

                try
                {
                    result = objCommand.ExecuteNonQuery();
                    objConnection.CloseConnection();
                    //return dt;
                }
                catch (Exception ex)
                {
                    objConnection.CloseConnection();
                    return 0;
                }
                finally
                {
                    
                    objConnection.CloseConnection();
                    objCommand.Dispose();
                }
                return result;
            }
            catch (Exception ex)
            {
                //ManejoError.Muestra(ex.Message)
                return 0;
            }


        }
       
        public string ConsultString(string sql)
        {
            objCommand.Connection = objConnection.connectionDB;
            objCommand.CommandText = sql;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string result = "";

            if (objTran != null)
            {
                objCommand.Transaction = objTran;
            }

            //objCommand.Parameters.Add("@option", SqlDbType.VarChar).Value = Option;
            //objCommand.Parameters.Add("@error_Code", SqlDbType.Int).Direction = ParameterDirection.Output;
            objConnection.OpenConnection();

            try
            {


                result = (String) objCommand.ExecuteScalar();
                //objConnection.CloseConnection();
                //return dt;
            }
            catch (Exception ex)
            {
                objConnection.CloseConnection();
                return result;
            }
            return result;
        }

        public int ConsultInt(string sql)
        {
            objCommand.Connection = objConnection.connectionDB;
            objCommand.CommandText = sql;
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            int result = 0;

            if (objTran != null)
            {
                objCommand.Transaction = objTran;
            }

            //objCommand.Parameters.Add("@option", SqlDbType.VarChar).Value = Option;
            //objCommand.Parameters.Add("@error_Code", SqlDbType.Int).Direction = ParameterDirection.Output;
            objConnection.OpenConnection();

            try
            {


                result = (int)objCommand.ExecuteScalar();
                //objConnection.CloseConnection();
                //return dt;
            }
            catch (Exception ex)
            {
                objConnection.CloseConnection();
                return result;
            }
            return result;
        }
    }
}