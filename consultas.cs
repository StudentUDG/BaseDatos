using System;
using MySql.Data.MySqlClient;

namespace BaseDatos
{
	
	class consultas : conexion
	{
		public void mostrarDatos()
		{
			int id;
			string nombre, direccion, telefono, email;
			Console.Clear();
			Console.WriteLine("----------------------------  CONSULTAS  -------------------------------\n\n");
			this.abrirConexion();
			MySqlCommand comandoConsulta = new MySqlCommand ("SELECT * FROM empresa", miConexion);
			MySqlDataReader datosConsulta = comandoConsulta.ExecuteReader();
			
			if (!datosConsulta.HasRows)
				Console.WriteLine("Base de Datos vacia!!");
			else 
				while (datosConsulta.Read())
			{
				id = Convert.ToInt32(datosConsulta["id"]);
				nombre = datosConsulta["nombre"].ToString();
				direccion = datosConsulta["direccion"].ToString();
				telefono = datosConsulta["telefono"].ToString();
				email = datosConsulta["email"].ToString();
				
				Console.WriteLine("\n\tId: " + id + "\n\tNombre: " + nombre + "\n\tDireccion: " + direccion + "\n\tTelefono: " + telefono + "\n\tEmail: " + email);
				Console.WriteLine("\n    ____________________________________\n");
			}
			this.cerrarConexion();
		}
		
		public void ejecutarConsulta(string consulta)
		{
			this.abrirConexion();
			MySqlCommand comandoConsulta = new MySqlCommand(consulta, miConexion);
			comandoConsulta.ExecuteNonQuery();
			this.cerrarConexion();
			Console.WriteLine("\n\t\tAcción Realizada!!");
		}
		
		public bool verificarExistencia(int id)
		{
			this.abrirConexion();
			MySqlCommand comandoConsulta = new MySqlCommand("SELECT id FROM empresa WHERE id = " + id, miConexion);
			MySqlDataReader datosConsulta = comandoConsulta.ExecuteReader();
			bool tieneDatos = datosConsulta.HasRows;
			this.cerrarConexion();
			if (tieneDatos)
				return true;
			else
				return false;
		}
		
	}
}
