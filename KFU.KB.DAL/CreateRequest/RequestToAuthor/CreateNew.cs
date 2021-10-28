using System;
using KFU.KB.DAL.Models;
using Npgsql;

namespace KFU.KB.DAL.CreateRequest.RequestToAuthor
{
    public class CreateNew
    {
        public static string Create(Author author)
        {   
            using var con = new NpgsqlConnection(Connection.connectionString);
            try
            {
                con.Open();
                Console.WriteLine("Поделючение отерыто...");
                string sql = "insert into authors values (@id,@first,@last,@sur,@birht,@death,@age)";
                using var cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@id",author.AuthorId);
                cmd.Parameters.AddWithValue("@first", author.AuthorFirstName);
                cmd.Parameters.AddWithValue("@last", author.AuthorLastName);
                cmd.Parameters.AddWithValue("@sur", author.AuthorSurName);
                cmd.Parameters.AddWithValue("@birht",author.AuthorBirthday);
                cmd.Parameters.AddWithValue("@death", author.AuthorDeathday);
                cmd.Parameters.AddWithValue("@age", author.Age);
                cmd.ExecuteNonQuery();
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
            return "Done";
        }
    }
}