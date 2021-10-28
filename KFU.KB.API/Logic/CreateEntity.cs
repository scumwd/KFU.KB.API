using System;
using KFU.KB.API.Controllers;

namespace KFU.KB.API.Logic
{
    public class CreateEntity
    {
        public static void CreateEntityAuthor(string[] author)
        {
            /*author.AuthorId = new Guid();
            author.AuthorFirstName = firstname;
            author.AuthorLastName = lastname;
            author.AuthorSurName = surname;
            author.AuthorBirthday = birthDate;
            author.AuthorDeathday = deathDate;
            int result = 0;
            if ((birthDate.Month < deathDate.Month) || (birthDate.Month == deathDate.Month && birthDate.Day<=deathDate.Day))
                result = (deathDate.Year - birthDate.Year);
            if (birthDate.Month == deathDate.Month && birthDate.Day > deathDate.Day || (birthDate.Month > deathDate.Month))
                result = (deathDate.Year - birthDate.Year) - 1;
            author.Age = result;
            AuthorsController a = new AuthorsController();
            a.CreateItem(author);*/
        }
        public static void CreateEntityBook(string[] book)
        {
            BooksController b = new BooksController();
            Book recent = new Book();
            recent.BookId = Guid.NewGuid();
            //recent.BookName = book[0];
            //recent.BookDate = book[1];
            //recent.BookAuthor = book[2];
            b.CreateItem(recent);
        }
    }
}