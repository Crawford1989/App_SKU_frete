using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;



namespace WinFormsApp1
{
    public class DatabaseConnection
    {
        private readonly string connectionString = "Host=xxx;Port=5433;Database=xxx;Username=xxx;Password=xxx;";

        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void ExecuteQuery(string query)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        List<string> codigosAuxiliares = new List<string>();
                        while (reader.Read())
                        {
                            string codigoAuxiliar = reader.GetString(0);
                            codigosAuxiliares.Add(codigoAuxiliar);
                        }

                    }
                }
            }
        }
    }

}