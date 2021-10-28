using System;
using KFU.KB.DAL.Models;
using Npgsql;

namespace KFU.KB.DAL.CreateRequest.RequestToAuthor
{
    public class UpdateExist
    {
        public static string Update(Author author, bool exist)
        {
            string result;
            
            using var con = new NpgsqlConnection(Connection.connectionString);
            try
            {
                con.Open();
                Console.WriteLine("Подключение открыто");
                if (exist)
                {
                    string upd = "update authors SET authorfirstname=@first,authorlastname=@last,authorsurname=@sur,authorbirthday=@birth,authordeathday=@death,authorage=@age WHERE authorid=@id";
                    using var cmdupd = new NpgsqlCommand(upd, con);
                    cmdupd.Parameters.AddWithValue("@id",author.AuthorId);
                    cmdupd.Parameters.AddWithValue("@first", author.AuthorFirstName);
                    cmdupd.Parameters.AddWithValue("@last", author.AuthorLastName);
                    cmdupd.Parameters.AddWithValue("@sur", author.AuthorSurName);
                    cmdupd.Parameters.AddWithValue("@birth",author.AuthorBirthday);
                    cmdupd.Parameters.AddWithValue("@death", author.AuthorDeathday);
                    cmdupd.Parameters.AddWithValue("@age", author.Age);
                    cmdupd.ExecuteNonQuery();
                    result = "Done";
                }
                else result= "Данного поля не существует";
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