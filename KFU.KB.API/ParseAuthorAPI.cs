using System;

namespace KFU.KB.API
{
    public class ParseAuthorAPI
    {
        public Author ParseAuthor(AuthorAPI authorApi)
        {
            Author a = new Author();
            a.AuthorId = Guid.NewGuid();
            a.AuthorFirstName = authorApi.Firstname;
            a.AuthorLastName = authorApi.Lastname;
            a.AuthorSurName = authorApi.Surname;
            a.AuthorBirthday = new DateTime();
            a.AuthorDeathday = new DateTime();
            int result = 0;
            if ((a.AuthorBirthday.Month < a.AuthorDeathday.Month) || (a.AuthorBirthday.Month == a.AuthorDeathday.Month && a.AuthorBirthday.Day<=a.AuthorDeathday.Day))
                result = (a.AuthorDeathday.Year - a.AuthorBirthday.Year);
            if (a.AuthorBirthday.Month == a.AuthorDeathday.Month && a.AuthorBirthday.Day > a.AuthorDeathday.Day || (a.AuthorBirthday.Month > a.AuthorDeathday.Month))
                result = (a.AuthorDeathday.Year - a.AuthorBirthday.Year) - 1;
            a.Age = result;
            return a;
        }
    }
}