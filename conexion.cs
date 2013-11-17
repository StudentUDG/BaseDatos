using System;
using MySql.Data.MySqlClient;

namespace BaseDatos
{
	
	
	 class conexion
	{
		protected MySqlConnection miConexion;
        public conexion()
        {
        }

        protected void abrirConexion()
        {
            string connectionString =
                "Server=localhost;" +
                "Database=fabrica;" +
                "User ID= root;" +
                "Password=;" +
                "Pooling=false;";
            this.miConexion = new MySqlConnection(connectionString);
            this.miConexion.Open();
        }

        protected void cerrarConexion()
        {
            this.miConexion.Close();
            this.miConexion = null;
        }
    }
}


