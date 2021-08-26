using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeeK5Day4.Interface;
using System.Data.SqlClient;
using WeeK5Day4.Entity;
using System.Threading.Tasks;

namespace WeeK5Day4.AdoListRepository
{
    class TvAdoRepository : ITvRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                      "Initial Catalog = NegozioElettronica;" +
                                      "Integrated Security = true;";

        const string _tipo = "Tv";
        public void Delete(Tv tv)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Prodotto where Id = @id";
                command.Parameters.AddWithValue("@id", tv.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Tv> Fetch()
        {
            List<Tv> televisori = new List<Tv>();
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
                    var pollici = (int)reader["Pollici"];
                    var id = (int)reader["Id"];

                    Tv tv = new Tv(marca, modello, quantità, pollici, id);
                    televisori.Add(tv);
                }
            }
            return televisori;
        }

        public void Insert(Tv t)
        {
            throw new NotImplementedException();
        }

        public void Update(Tv t)
        {
            throw new NotImplementedException();
        }
    }
}
