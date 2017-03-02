using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServicesRutDb.Models
{
    public class Connection
    {

        public SqlConnection connectionDB;

        public Connection()
        {
            // Modificado para realizar el procedimiento de Vendamas
            connectionDB = new SqlConnection(ConfigurationManager.ConnectionStrings["Rut_DB"].ToString());
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);

        }

        public void OpenConnection()
        {
            try
            {
                if (connectionDB.State == ConnectionState.Broken || connectionDB.State == ConnectionState.Closed)
                    connectionDB.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Error al abrir la conexión", e);
            }
        }

        public void CloseConnection()
        {
            try
            {
                //    if (connectionDB.State == ConnectionState.Open)
                //    {
                connectionDB.Close();
                connectionDB.Dispose();
                //}

            }
            catch (Exception e)
            {
                throw new Exception("Error al cerrar la conexión", e);
            }
        }

    }
}