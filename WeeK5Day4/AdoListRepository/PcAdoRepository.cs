using System;
using WeeK5Day4.Interface;
using WeeK5Day4.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeK5Day4.AdoListRepository
{
    class PcAdoRepository : IPcRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                     "Initial Catalog = NegozioElettronica;" +
                                     "Integrated Security = true;";

        const string _tipo = "Pc";
        public void Delete(Pc pc)
        {       
          
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "delete from Prodotto where Id = @id";
                    command.Parameters.AddWithValue("@id", pc.Id);

                    command.ExecuteNonQuery();
                }
        }
        

        public List<Pc> Fetch()
        {
            List<Pc> computers = new List<Pc>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Prodotto where TipoProdotto = @tipo";
                command.Parameters.AddWithValue("@tipo", _tipo);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var marca = (string)reader["Marca"];
                    var modello = (string)reader["Modello"];
                    var quantità = (int)reader["QuantitàInMagazzino"];
                    var sistema = (string)reader["SistemaOperativo"];
                    var touch = (bool)reader["TouchScreen"];
                    var id = (int)reader["Id"];

                    Pc pc = new Pc(marca, modello, quantità, sistema, touch, id);
                    computers.Add(pc);
                }
            }
            return computers;
        }

        public void Insert(Pc pc)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;


                command.CommandText = "insert into Prodotto values (@marca, @modello, @quantità, @memoria, @sistema, @touch, @pollici, @tipo)";
                command.Parameters.AddWithValue("@marca", pc.Marca);
                command.Parameters.AddWithValue("@modello", pc.Modello);
                command.Parameters.AddWithValue("@quantità", pc.QuantitàInMagazzino);
                command.Parameters.AddWithValue("@memoria", DBNull.Value);
                command.Parameters.AddWithValue("@sistema", pc.SistemaOperativo);
                command.Parameters.AddWithValue("@touch", pc.TouchScreen);
                command.Parameters.AddWithValue("@pollici", DBNull.Value);
                command.Parameters.AddWithValue("@tipo", _tipo);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Pc t)
        {
            throw new NotImplementedException();
        }
    }
}
