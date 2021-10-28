using System;
using KFU.KB.BAC.Models;


namespace KFU.KB.DAL.Author.BuisnessLogic
{
    public class DBHelper
    {
        public static Models.Author ParseAuthor(AuthorBAC authorBac, Guid id)
        {
            Models.Author author = new Models.Author();
            author.AuthorId = id;
            author.AuthorFirstName = authorBac.Firstname;
            author.AuthorLastName = authorBac.Lastname;
            author.AuthorSurName = authorBac.Surname;
            author.AuthorBirthday = authorBac.BirthDate;
            author.AuthorDeathday = authorBac.DeathDate;
            int result = 0;
            if ((author.AuthorBirthday.Month < author.AuthorDeathday.Month) || (author.AuthorBirthday.Month == author.AuthorDeathday.Month && author.AuthorBirthday.Day<=author.AuthorDeathday.Day))
                result = (author.AuthorDeathday.Year - author.AuthorBirthday.Year);
            if (author.AuthorBirthday.Month == author.AuthorDeathday.Month && author.AuthorBirthday.Day > author.AuthorDeathday.Day || (author.AuthorBirthday.Month > author.AuthorDeathday.Month))
                result = (author.AuthorDeathday.Year - author.AuthorBirthday.Year) - 1;
            author.Age = result;
            return author;
        }
    }
}
        
        