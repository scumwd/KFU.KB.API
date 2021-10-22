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
    public class BooksController : Controller
    {
        private static string connectionString = @"Host=localhost;port=5432;Database=kb.api";
        private static NpgsqlConnection connection = new NpgsqlConnection(connectionString);

        public List<Book> GetAllItems()
        {
            List<Book> listreult = new List<Book>();
            try
            {
                connection.Open();
                Console.WriteLine("Подключение открыто");
                var cmd = new NpgsqlCommand();
                cmd.CommandText = ("SELECT * FROM books");
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var book = new Book();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        typeof(Book).GetProperty(reader.GetName(i)).SetValue(book, reader.GetValue(i));
                    }
                    listreult.Add(book);
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

        public Book GetItem(int id)
        {
            var book = new Book();
            try
            {
                connection.Open();
                Console.WriteLine("Подключение открыто");
                var cmd = new NpgsqlCommand();
                cmd.CommandText = ($"SELECT * FROM books where bookid={id}");

                var reader = cmd.ExecuteReader();
                reader.Read();
                for (int i = 0; i < reader.FieldCount; i++)
                    typeof(Book).GetProperty(reader.GetName(i)).SetValue(book, reader.GetValue(i));

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
            return book;
        }

        [HttpPost]
        public void CreateItem([FromBody] Book book)
        {
            string sqlExpression = $"INSERT INTO authors (authorid,authorname,authordate,authorbook) VALUES ({book.BookId},{book.BookName},{book.BookDate},{book.BookAuthor})";
            try
            {
                connection.Open();
                Console.WriteLine("Поделючение отерыто...");
                var cmd = new NpgsqlCommand(sqlExpression, connection);
                int number = cmd.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);
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

        [HttpDelete]
        public void RemoveItem(int id)
        {
            string sqlExpression = $"DELETE FROM books WHERE bookid={id}";
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