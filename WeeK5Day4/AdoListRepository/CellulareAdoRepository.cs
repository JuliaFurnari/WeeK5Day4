using System;
using WeeK5Day4.Interface;
using WeeK5Day4.Entity;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WeeK5Day4.AdoListRepository
{
    class CellulareAdoRepository : ICellulariRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                       "Initial Catalog = NegozioElettronica;" +
                                       "Integrated Security = true;";

        const string _tipo = "Cellulare";
        public void Delete(Cellulare cellulare)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Prodotto where Id = @id";
                command.Parameters.AddWithValue("@id", cellulare.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Cellulare> Fetch()
        {
            List<Cellulare> cellulari = new List<Cellulare>();
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
                    var memoria = (float)reader["MemoriaGB"];
                    var id = (int)reader["Id"];

                    Cellulare cellulare = new Cellulare(marca, modello, quantità, memoria, id);
                    cellulari.Add(cellulare);
                }
            }
            return cellulari;
        }

        public void Insert(Cellulare cellulare)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                
                command.CommandText = "insert into Prodotto values (@marca, @modello, @quantità, @memoria, @sistema, @touch, @pollici, @tipo)";
                command.Parameters.AddWithValue("@marca", cellulare.Marca);
                command.Parameters.AddWithValue("@modello", cellulare.Modello);
                command.Parameters.AddWithValue("@quantità", cellulare.QuantitàInMagazzino);
                command.Parameters.AddWithValue("@memoria", cellulare.MemoriaGB);
                command.Parameters.AddWithValue("@sistema", DBNull.Value);
                command.Parameters.AddWithValue("@touch", DBNull.Value);
                command.Parameters.AddWithValue("@pollici", DBNull.Value);
                command.Parameters.AddWithValue("@tipo", _tipo);

                command.ExecuteNonQuery();
            }
        }

        public void Update(Cellulare t)
        {
            throw new NotImplementedException();
        }
    }
}
