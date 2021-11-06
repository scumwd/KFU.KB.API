using System;
using System.Text.Json.Serialization;
using KFU.KB.API.Logic;

namespace KFU.KB.API
{
    
        public class AuthorAPI
        {
            public Guid id { get; set; }
            public string Surname { get; set; }
            public string Lastname {get;set;}
            public string Firstname { get; set; }
          //  [JsonConverter(typeof(ConvertToDateTime.StringToDateTimeConverter))]
            public DateTime BirthDate { get; set; }
            //[JsonConverter(typeof(ConvertToDateTime.StringToDateTimeConverter))]
            public DateTime DeathDate { get; set; }
        }
    
}