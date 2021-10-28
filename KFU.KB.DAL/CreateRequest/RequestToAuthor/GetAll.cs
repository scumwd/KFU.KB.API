using System;
using System.Collections.Generic;
using KFU.KB.DAL.Models;


using Npgsql;

namespace KFU.KB.DAL.CreateRequest.RequestToAuthor
{
    public class GetAll
    {
        private static string connectionString = @"Host=localhost;port=5432;Database=kb.api";
        public static List<Author> GetAllAuthors()
        {
            List<Author> listreult = new List<Author>();
            using var con = new NpgsqlConnection(Connection.connectionString);
            try
            {
                con.Open();
                Console.WriteLine("Подключение открыто");
                string sql = "SELECT * FROM authors";
                using var cmd = new NpgsqlCommand(sql, con);
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var author = new Author();
                    author.AuthorId = (Guid) rdr.GetValue(0);
                    author.AuthorFirstName = (string) rdr.GetValue(1);
                    author.AuthorLastName = (string) rdr.GetValue(2);
                    author.AuthorSurName = (string) rdr.GetValue(3);
                    author.AuthorBirthday = rdr.GetDateTime(4);
                    author.AuthorDeathday = rdr.GetDateTime(5);
                    author.Age = (int) rdr.GetValue(6);
                    listreult.Add(author);
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
            return listreult;
        }
    }
}