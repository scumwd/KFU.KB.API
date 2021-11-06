using System;
using System.Collections.Generic;
using KFU.KB.DAL.Author.BuisnessLogic;
using Microsoft.AspNetCore.Mvc;


namespace KFU.KB.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : Controller
    {
        [HttpGet]
        public List<DAL.Models.Author> GetAllItems() => DBConnect.GetAll();

        [HttpGet]
        public List<DAL.Models.Author> GetFilterAuthor(int age, string name) => DBConnect.GetFilter(age, name);

        [HttpGet("{id:Guid}")]
        public DAL.Models.Author GetItemId(Guid id) => DBConnect.GetItemId(id);

        [HttpPost]
        public string CreateItem([FromBody] BAC.Models.AuthorBAC authorBac) => DBConnect.Create(authorBac);

        [HttpPut("{id:guid}")]
        public string Update([FromBody] BAC.Models.AuthorBAC authorBac, Guid id) =>
            DBConnect.UpdateAuthor(authorBac, id);

        [HttpDelete("{id:guid}")]
        public string RemoveItem(Guid id) => DBConnect.RemoveAuthor(id);
=======

    }
}
