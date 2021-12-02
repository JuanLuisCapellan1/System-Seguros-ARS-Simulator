using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using MySqlConnector;
using System.Configuration;

namespace CapaDatos
{
    public class CD_Productos
    {
        private CD_Conexion conexion = new CD_Conexion();


        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();


        public void CreateNewUser(string nombre, string email, string password, string phone, DateTime created_at)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "InsertUsers";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@password", password);
            comando.Parameters.AddWithValue("@phone", phone);
            comando.Parameters.AddWithValue("@created_at", created_at);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public DataTable ShowData()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ShowAllClients"; // nombre del procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure; //tipo de comando procedimiento almacenado sql
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void CreateNewClient(string nombre, string email, string cedula, string phone, string direction, DateTime created_at)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "CreateNewClient";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@no_cedula", cedula);
            comando.Parameters.AddWithValue("@phone", phone);
            comando.Parameters.AddWithValue("@direction", direction);
            comando.Parameters.AddWithValue("@created_at", created_at);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void EditarClient(string nombre, string email, string cedula, string phone, string direction, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "UpdateClients";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@no_cedula", cedula);
            comando.Parameters.AddWithValue("@phone", phone);
            comando.Parameters.AddWithValue("@direction", direction);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void DeleteClient(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "DeleteCLients";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idClient", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public void CreateNewEncuesta(string question, string answer, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "CreateNewEncuesta";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Question", question);
            comando.Parameters.AddWithValue("@Answer", answer);
            comando.Parameters.AddWithValue("@idClient", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexion.CerrarConexion();
        }

        public DataTable ShowDataClientEncuesta()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "ShowClientsEncuesta"; // nombre del procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure; //tipo de comando procedimiento almacenado sql
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

    }

}