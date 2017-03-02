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
                return result;
            }
            catch (Exception ex)
            {
                //ManejoError.Muestra(ex.Message)
                return 0;
            }


        }
        /*
        public SqlDataReader ConsultRow(string storeProcedureName, Parameters Parameters)
        {
            try
            {
                SqlDataReader result = null;
                objCommand.Connection = objConnection.connectionDB;
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = storeProcedureName;

                if (objTran != null)
                {
                    objCommand.Transaction = objTran;
                }

                int numparams = 0;
                if (Parameters != null)
                {
                    numparams = Parameters.Count;
                }
                for (int i = 1; i <= numparams; i++)
                {
                    objParameter = Parameters.Item(i);
                    objCommand.Parameters.Add(objParameter.name, objParameter.type, objParameter.size).Value = objParameter.value;

                }

                //objCommand.Parameters.Add("@option", SqlDbType.VarChar).Value = Option;
                //objCommand.Parameters.Add("@error_Code", SqlDbType.Int).Direction = ParameterDirection.Output;
                objConnection.OpenConnection();

                try
                {


                    result = objCommand.ExecuteReader();
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
            catch (Exception ex)
            {
                //ManejoError.Muestra(ex.Message)
                return null;
            }


        }*/
    }
}