using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace BaseDatos
{
	
 class Menu
	{
 		protected consultas consultas = new consultas();
 	
		
			public void conectar()
		{
			Console.WriteLine("------------------------  INICIO DE SESION  -----------------------------\n\n");
			Console.Write("\tIngresa el usuario: \n\t\t\t\t");
			string usr = Console.ReadLine();
			Console.Write("\n\n\tIngresa tu contrasena: \n\t\t\t\t");
			string pass = Console.ReadLine();
			if (usr == "root" && pass == ""){
				this.menu();
			}
				
			else{
				Console.WriteLine("\n\n\t\tUsuario: ["+usr + "] y Contaseña: ["+ pass+"] INVALIDOS!! \n\n\t\t\tINTENTA DE NUEVO...");
				Console.ReadKey();
				Console.Clear();
				this.conectar();
				
			}
			
		}
		
		public void menu()
		{
			string opcion;
			do 
			{
				Console.Clear();
				Console.WriteLine(" ------------------------   REGISTROS DE EMPRESAS  --------------------------");
				Console.Write("\n\t1. Agregar Empresa \n\t2. Editar Info. Empresa \n\t3. Eliminar Datos \n\t4. Consultas \n\t5. Salir\n\n\t");
				opcion = Console.ReadLine();
				if (opcion != "5")
				{
					opcionesDelMenu(opcion);
					Console.ReadKey();
					Console.Clear();
					
				}
		}
			while (opcion != "5");
			this.salir();
		}
		
		private void opcionesDelMenu(string opcion)
		{
			switch(opcion)
			{
				case "1":
					agregar();
					break;
					
				case "2":
					editar();
					break;
					
				case "3":
					eliminar();
					break;
					
				case "4":
					mostrar();
					break;
					
				case "5":
					this.salir();
					break;
				default:
					Console.WriteLine("\n\tError!!");
					break;
					
			}
				
		}
			private void mostrar()
			{
				this.consultas.mostrarDatos();
			}
			private void agregar()
			{
			Console.Clear();
			Console.WriteLine("----------------------------  AGREGAR EMPRESA  -------------------------------\n\n");
			string consulta = "INSERT INTO empresa VALUES('',";

            Console.Write("\t\tNombre: ");
            consulta += "'" + Console.ReadLine() + "', ";
            Console.Write("\t\tDireccion: ");
            consulta += "'" + Console.ReadLine() + "', ";
            Console.Write("\t\tTelefono: ");
            consulta += "'" + Console.ReadLine() + "', ";
            Console.Write("\t\temail: ");
            consulta += "'" + Console.ReadLine() + "' )";
            
            this.consultas.ejecutarConsulta(consulta);
		}
			private void editar()
			{
				Console.Clear();
				Console.WriteLine("-------------------  EDITAR INFORMACION DE LA EMPRESA  ----------------------\n\n");
				this.consultas.mostrarDatos();
				Console.WriteLine("\n\nEscribe el Id que deseas editar!! [s] Salir ");
				string entradaUsuario = Console.ReadLine();
				if (entradaUsuario == "s" || entradaUsuario == "S")
					return;
				else
				{
					Console.WriteLine("Seguro que lo quieres editar?? " + entradaUsuario + " [S] CONTINUA!!");
					string corroboracion = Console.ReadLine();
					
					if (corroboracion == "s" || corroboracion == "S")
					{
						int entradaDeUsuario;
						if (Int32.TryParse(entradaUsuario, out entradaDeUsuario))
						{
							if (this.consultas.verificarExistencia(entradaDeUsuario))
							{
								string valores = "";
								Console.WriteLine("\t\tEditando id: " + entradaDeUsuario);
								Console.Write("\tNombre: \n\t");
								valores += "nombre ='" + Console.ReadLine() + "', ";
								Console.Write("\tDireccion: \n\t");
                            	valores += "direccion='" + Console.ReadLine() + "', ";
                            	Console.Write("\tTelefono: \n\t");
                            	valores += "telefono='" + Console.ReadLine() + "', ";
                            	Console.Write("\temail: \n\t");
                            	valores += "email='" + Console.ReadLine() + "'";
                            	
                            	this.consultas.ejecutarConsulta("UPDATE empresa SET " + valores + "WHERE id= " + entradaDeUsuario);
                            	
							}
							else
								Console.WriteLine("\t\tID nos es valido");
						}
						else
							Console.WriteLine("\n\tVerifique Id");
					}
				}
			}
			private void eliminar()
			{
				Console.Clear();
				Console.WriteLine("------------------------  ELIMINAR DATOS  --------------------------\n\n");
				this.consultas.mostrarDatos();
				Console.WriteLine("\n\tPor favor escriba el Id que deseas eliminar!! [S] salir");
				string entradaUsuario = Console.ReadLine();
				
				if (entradaUsuario == "s" || entradaUsuario == "S")
					return;
				else
				{
					Console.WriteLine("\n\tRealmente quieres ELIMINAR!! " + entradaUsuario + " [C] CONTINUAR!!");
					string corroboracion = Console.ReadLine();
					
					if (corroboracion == "c" || corroboracion == "C")
					{
						int entradaDeUsuario;
						if (Int32.TryParse(entradaUsuario, out entradaDeUsuario))
						{
							if (this.consultas.verificarExistencia(entradaDeUsuario))
								this.consultas.ejecutarConsulta("DELETE FROM empresa WHERE id= " + entradaDeUsuario);
							else
								Console.WriteLine("\n\tID no existe o es incorrecto");
							
						}
						else 
							Console.WriteLine("\n\tVerifique el ID!!");
						
					}
				}
			}
			
			private void salir()
			{
				Console.Clear();
				Console.WriteLine("\n\n -----------------------  HASTA PRONTO!! °L° --------------------------");
				
			}
	}
}
