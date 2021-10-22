using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KFU.KB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private static string connectionString = @"Host=localhost;port=5432;Database=kb.api";
        private static NpgsqlConnection connection = new NpgsqlConnection(connectionString);

        public List<Author> GetAllItems()
        {
            List<Author> listreult = new List<Author>();
            try
            {
                connection.Open();
                Console.WriteLine("Подключение открыто");
                var cmd = new NpgsqlCommand();
                cmd.CommandText=("SELECT * FROM authors");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var author = new Author();
                    for(int i = 0; i<reader.FieldCount; i++)
                    {
                        typeof(Author).GetProperty(reader.GetName(i)).SetValue(author,reader.GetValue(i));
                    }
                    listreult.Add(author);
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }

            return listreult;
        }

        public Author GetItem(int id)
        {
            var author = new Author();
            try
            {
                connection.Open();
                Console.WriteLine("Подключение открыто");
                var cmd = new NpgsqlCommand();
                cmd.CommandText = ($"SELECT * FROM authors where authorid={id}");
                
                var reader = cmd.ExecuteReader();
                reader.Read();
                for(int i = 0; i<reader.FieldCount;i++)
                    typeof(Author).GetProperty(reader.GetName(i)).SetValue(author, reader.GetValue(i));
                
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }
            return author;
        }

        [HttpPost]
        public void CreateItem([FromBody] Author author)
        {
            string sqlExpression = $"INSERT INTO authors (authorid,authorname,authordate,authorbook) VALUES ({author.AuthorId},{author.AuthorName},{author.AuthorDate},{author.AuthorBook})";
            try
            {
                connection.Open();
                Console.WriteLine("Поделючение отерыто...");
                var cmd = new NpgsqlCommand(sqlExpression, connection);
                int number = cmd.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);
                Update(author);
                connection.Close();

            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Подключение закрыто...");
            }
        }
        
        [HttpPut] 
        public void Update(Author item) => 
            CreateItem(item);

        [HttpDelete]
        public void RemoveItem(int id)
        {
            string sqlExpression = $"DELETE FROM authors WHERE authorid={id}";
            using (connection)
            {
                connection.Open();
                var cmd = new NpgsqlCommand(sqlExpression, connection);
                int number = cmd.ExecuteNonQuery();
                Console.WriteLine("Удалено объектов: {0}", number);
            }
        }
    }
}
