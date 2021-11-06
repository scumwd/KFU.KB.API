using System;
using KFU.KB.DAL.Models;
using Npgsql;

namespace KFU.KB.DAL.CreateRequest.RequestToAuthor
{
    public class GetById
    {
        public static Author GetItemId(Guid id, bool exist)
        {
            Author author = new Author();
            using var con = new NpgsqlConnection(Connection.connectionString);
            try
            {
                con.Open();
                Console.WriteLine("Подключение открыто");
                if (exist)
                {
                    string sql = "SELECT * FROM authors where authorid=@id";
                    using var cmd = new NpgsqlCommand(sql, con);
                    cmd.Parameters.AddWithValue(id);
                    using NpgsqlDataReader rdr = cmd.ExecuteReader();
                    rdr.Read();
                    author.AuthorId = (Guid) rdr.GetValue(0);
                    author.AuthorFirstName = (string) rdr.GetValue(1);
                    author.AuthorLastName = (string) rdr.GetValue(2);
                    author.AuthorSurName = (string) rdr.GetValue(3);
                    author.AuthorBirthday = rdr.GetDateTime(4);
                    author.AuthorDeathday = rdr.GetDateTime(5);
                }
                
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
                Console.WriteLine("Подключение закрыто...");
            }
            return author;
        }
    }
}