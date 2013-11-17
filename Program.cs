using System;
using MySql.Data.MySqlClient;

namespace BaseDatos
{
	class Program 
	{
		public static void Main(string[] args)
		{
			Menu menu = new Menu();
			menu.conectar();
			menu.menu();
			Console.ReadKey();
		}
	}
}