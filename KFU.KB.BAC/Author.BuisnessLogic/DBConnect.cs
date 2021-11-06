using System;
using System.Collections.Generic;
using KFU.KB.BAC.Models;
using KFU.KB.DAL.CreateRequest.RequestToAuthor;

namespace KFU.KB.DAL.Author.BuisnessLogic
{
    public class DBConnect
    {
        public static List<Models.Author> GetAll() => CreateRequest.RequestToAuthor.GetAll.GetAllAuthors();

        public static List<Models.Author> GetFilter(int age, string name) => GetWhithFilter.GetFilter(age,name);


        public static Models.Author GetItemId(Guid id) => GetById.GetItemId(id,OtherHelp.Chek(id));

        public static string Create(AuthorBAC authorBac) => CreateNew.Create(DBHelper.ParseAuthor(authorBac, Guid.NewGuid()));

        public static string UpdateAuthor(AuthorBAC authorBac, Guid id) =>
            UpdateExist.Update(DBHelper.ParseAuthor(authorBac,id), OtherHelp.Chek(id));

        public static string RemoveAuthor(Guid id) => RemoveById.Remove(id, OtherHelp.Chek(id));

    }
}