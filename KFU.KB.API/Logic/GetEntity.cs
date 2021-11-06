using System;
using KFU.KB.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace KFU.KB.API.Logic
{

    public class GetEntity: Controller
    {
        private string connectionString = @"Host=localhost;port=5432;Database=kb.api";
        
        public Author GetAuthor(AuthorAPI authorApi)
        {
            Author author = new Author();
            author.AuthorId = Guid.NewGuid();
            author.AuthorFirstName = authorApi.Firstname;
            author.AuthorLastName = authorApi.Lastname;
            author.AuthorSurName = authorApi.Surname;
            author.AuthorBirthday = authorApi.BirthDate;
            author.AuthorDeathday = authorApi.DeathDate;
            int result = 0;
            if ((author.AuthorBirthday.Month < author.AuthorDeathday.Month) || (author.AuthorBirthday.Month == author.AuthorDeathday.Month && author.AuthorBirthday.Day<=author.AuthorDeathday.Day))
                result = (author.AuthorDeathday.Year - author.AuthorBirthday.Year);
            if (author.AuthorBirthday.Month == author.AuthorDeathday.Month && author.AuthorBirthday.Day > author.AuthorDeathday.Day || (author.AuthorBirthday.Month > author.AuthorDeathday.Month))
                result = (author.AuthorDeathday.Year - author.AuthorBirthday.Year) - 1;
            author.Age = result;
            return author;
        }
        

        public void GetBook([FromForm] string book)
        {
            Parse.ParseToBook(book);
        }
    }
}