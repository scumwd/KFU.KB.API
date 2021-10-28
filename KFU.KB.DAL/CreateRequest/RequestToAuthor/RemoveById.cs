using System;
using Npgsql;

namespace KFU.KB.DAL.CreateRequest.RequestToAuthor
{
    public class RemoveById
    {
        public static string Remove(Guid id,bool exist)
        {
            string result;
            using var con = new NpgsqlConnection(Connection.connectionString);
            try
            {
                con.Open();
                Console.WriteLine("Подключение открыто");
                if (exist)
                {
                    string del = "delete FROM authors where authorid=@id;";
                    using var cmd = new NpgsqlCommand(del, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    result = "Done.";
                }
                else result = "Error.";
                return result;
            }
            catch (NpgsqlException ex)
            {
                return ex.Message;
            }
            finally
            {
                con.Close();
                Console.WriteLine("Подключение закрыто...");
            }
        
        }
    }
}