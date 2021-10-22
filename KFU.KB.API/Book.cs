using System;

namespace KFU.KB.API
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string BookName { get; set; }
        public string BookDate { get; set; }
        public string BookAuthor { get; set; }
    }
}
