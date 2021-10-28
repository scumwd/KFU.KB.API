using System;
using Npgsql;

namespace KFU.KB.API.Controllers
{
    public class CheckExist
    {
        private string connectionString = @"Host=localhost;port=5432;Database=kb.api";

        public bool Chek(Guid id)
        {
            using var con = new NpgsqlConnection(connectionString);
            bool result = false;
            try
            {
                con.Open();
                Console.WriteLine("Cheking");
                string sql = "select * FROM authors where authorid=@id;";
                using var cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    result = true;
                }
                else result = false;

            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                Console.WriteLine("Cheking done");
            }

            return result;
        }
    }
}