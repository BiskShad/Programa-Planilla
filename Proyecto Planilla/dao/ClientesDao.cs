using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Planilla.dao
{
    class ClientesDao
    {
       

        public MySqlConnection Conectar()
        {
            string servidor = "localhost";
            string usuario = "root";
            string password = "";
            string baseDeDatos = "clientes";

            string cadenaConexion = "Database=" + baseDeDatos + "; Data Source="
                + servidor + "; User Id=" + usuario + "; Password=" + password + "";

            MySqlConnection conexionDb = new MySqlConnection(cadenaConexion);
            conexionDb.Open();

            return conexionDb;

           

        }

        public List<cliente> ObtenerlistadoDeClientes()
        {
            List<cliente> lista = new List<cliente>();
            string consulta = "SELECT * FROM `cleintes`";

            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            MySqlDataReader lectura = comando.ExecuteReader();

            // consultando base de datos
            while(lectura.Read())
            {
                cliente cliente = new cliente();
                cliente.Id = lectura.GetString("id");
                cliente.Nombre = lectura.GetString("nombre");
                cliente.Apellido= lectura.GetString("apellido");
                cliente.Telefono = lectura.GetString("telefono");
                cliente.TarjetaDeCredito = lectura.GetString("tarjeta_de_credito");
                lista.Add(cliente);

            }
            comando.Connection.Close();
            return lista;
        }

        public void Eliminar(cliente cliente)
        {
            string consulta = "DELETE FROM `cleintes` WHERE `cleintes`.`id` =" + cliente.Id + ";";
            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();

            comando.Connection.Close();

           



        }

        public void Guardar(cliente cliente)
        {
            
            if (cliente.Id == "")
            {
                insert(cliente);
            }
            else
            {
                update(cliente);
            }

            
       
            

        }

        private void insert(cliente cliente)
        {

            string consulta = "INSERT INTO `cleintes` (`id`, `nombre`, `apellido`, `telefono`, `tarjeta_de_credito`) VALUES (NULL,'"
                + cliente.Nombre + "','" + cliente.Apellido + "','" + cliente.Telefono + "', '" + cliente.TarjetaDeCredito + "');";

            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();




            comando.Connection.Close();

        }
        private void update (cliente cliente)
        {

           string consulta =  "UPDATE `cleintes` SET `nombre` = '"+ cliente.Nombre + "', `apellido` = '" + cliente.Apellido + "', `telefono` =" + cliente.Telefono + ", `tarjeta_de_credito` = '"
                 + cliente.TarjetaDeCredito+ "' WHERE `cleintes`.`id` = " + cliente.Id +  ";";

            MySqlCommand comando = new MySqlCommand(consulta);
            comando.Connection = Conectar();
            comando.ExecuteNonQuery();




            comando.Connection.Close();

        }



    }

    
} 

    







