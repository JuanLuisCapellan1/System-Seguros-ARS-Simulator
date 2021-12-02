using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;


namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();

        public void InsertarPRod(string name, string email, string password, string phone, DateTime created_at)
        {
            objetoCD.CreateNewUser(name, email, password, phone, created_at);
        }

        public DataTable MostrarClient()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ShowData();
            return tabla;
        }

        public void InsertarClientPRod(string name, string email, string cedula, string phone, string direction, DateTime created_at)
        {
            objetoCD.CreateNewClient(name, email, cedula, phone, direction, created_at);
        }

        public void EditarClient(string name, string email, string cedula, string phone, string direction, string id)
        {
            objetoCD.EditarClient(name, email, cedula, phone, direction, Convert.ToInt32(id));
        }
        public void EliminarClient(string id)
        {
            objetoCD.DeleteClient(Convert.ToInt32(id));
        }

        public void InsertEncuestaClient(string question, string answer, string id)
        {
            objetoCD.CreateNewEncuesta(question, answer, Convert.ToInt32(id));
        }

        public DataTable MostrarCompleteData()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.ShowDataClientEncuesta();
            return tabla;
        }

    }
}