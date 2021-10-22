using System;

namespace KFU.KB.API.Logic
{
    public class Parse
    {
        public static void ParseToAuthor(string author)
        {   
            var array = author.Split(new string[] {" ", ", ", "."}, StringSplitOptions.RemoveEmptyEntries);
            CreateEntity.CreateEntityAuthor(array);
        }
        
        public static void ParseToBook(string book)
        {
            var array = book.Split(new string[] {" ", ", ", "."}, StringSplitOptions.RemoveEmptyEntries);
            CreateEntity.CreateEntityBook(array);
        }
    }
}