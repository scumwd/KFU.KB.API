using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Npgsql;


namespace KFU.KB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : Controller
    {
        private static string connectionString = @"Host=localhost;port=5432;Database=kb.api";
        private static NpgsqlConnection connection = new (connectionString);

       /* [HttpGet]
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

        [HttpGet]
        public Book GetItem(Guid id)
        {
            var book = new Book();
            try
            {
                connection.Open();
                Console.WriteLine("Подключение открыто");
                var cmd = new NpgsqlCommand();
                cmd.CommandText = ($"SELECT * FROM books where bookid='{id}'");

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
            string sqlExpression = $"INSERT INTO books (bookid,booktitle,bookdate,BookCountOfPage) VALUES ({book.BookId},{book.BookTitle},{book.BookDate},{book.BookCountOfPage})";
            try
            {
                connection.Open();
                Console.WriteLine("Поделючение отерыто...");
                var cmd = new NpgsqlCommand(sqlExpression, connection);
                int number = cmd.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);
                Update(book);
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
        public void Update(Book item) => 
            CreateItem(item);

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
        }*/
    }
}