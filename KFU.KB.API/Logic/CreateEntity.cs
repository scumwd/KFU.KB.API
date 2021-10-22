using System;
using KFU.KB.API.Controllers;

namespace KFU.KB.API.Logic
{
    public class CreateEntity
    {
        public static void CreateEntityAuthor(string[] author)
        {
            AuthorsController a = new AuthorsController();
            Author recent = new Author();
            recent.AuthorId = Guid.NewGuid();
            recent.AuthorName = author[0];
            recent.AuthorDate = author[1];
            recent.AuthorBook = author[2];
            a.CreateItem(recent);
        }
        public static void CreateEntityBook(string[] book)
        {
            BooksController b = new BooksController();
            Book recent = new Book();
            recent.BookId = Guid.NewGuid();
            recent.BookName = book[0];
            recent.BookDate = book[1];
            recent.BookAuthor = book[2];
            b.CreateItem(recent);
        }
    }
}