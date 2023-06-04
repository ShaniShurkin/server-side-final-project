using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    internal class Category
    {   
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("code")]
        public int Code { get; set; }

        [BsonElement("hebrewName")]
        public string HebrewName { get; set; }

        [BsonElement("englishName")]
        public string EnglishName { get; set; }
    }
}
