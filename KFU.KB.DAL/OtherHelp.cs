using System;
using KFU.KB.DAL.CreateRequest;
using Npgsql;

namespace KFU.KB.DAL
{
    public class OtherHelp
    {
        public static bool Chek(Guid id)
        {
            using var con = new NpgsqlConnection(Connection.connectionString);
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