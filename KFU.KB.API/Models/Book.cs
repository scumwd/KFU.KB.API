using System;

namespace KFU.KB.API
{
    public class Book
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
        public string BookTitle { get; set; }
        public int BookDate { get; set; }
        public int BookCountOfPage { get; set; }
    }
}
