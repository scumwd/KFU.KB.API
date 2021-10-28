using System;
using System.Collections.Generic;
using KFU.KB.DAL.Models;
using Npgsql;

namespace KFU.KB.DAL.CreateRequest.RequestToAuthor
{
    public class GetWhithFilter
    {
        public static List<Author> GetFilter(int age, string name)
        {
            List<Author> listreult = new List<Author>();
            using var con = new NpgsqlConnection(Connection.connectionString);
            try
            {
                con.Open();
                Console.WriteLine("Подключение открыто");
                string sql = "SELECT * FROM authors where authorfirstname=@first and authorage=@age ";
                using var cmd = new NpgsqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@first", name);
                // cmd.Parameters.AddWithValue("@last", "");
                // cmd.Parameters.AddWithValue("@sur", "");
                // cmd.Parameters.AddWithValue("@birth",author.AuthorBirthday);
                //cmd.Parameters.AddWithValue("@death", author.AuthorDeathday);
                //cmd.Parameters.AddWithValue("@id", author.AuthorId);
                using NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Author authorap = new Author();
                    authorap.AuthorId = (Guid) rdr.GetValue(0);
                    authorap.AuthorFirstName = (string) rdr.GetValue(1);
                    authorap.AuthorLastName = (string) rdr.GetValue(2);
                    authorap.AuthorSurName = (string) rdr.GetValue(3);
                    authorap.AuthorBirthday = rdr.GetDateTime(4);
                    authorap.AuthorDeathday = rdr.GetDateTime(5);
                    listreult.Add(authorap);
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