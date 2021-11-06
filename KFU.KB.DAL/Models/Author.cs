using System;

namespace KFU.KB.DAL.Models
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorSurName { get; set; }
        public DateTime AuthorBirthday { get; set; }
        public DateTime AuthorDeathday { get; set; }
        public  int Age { get; set; }
    }
}