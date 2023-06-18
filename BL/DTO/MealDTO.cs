using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class MealDTO
    {
        public int Code { get; set; }
        public string EnName { get; set; }
        public string HeName { get; set; }
        public double Calories { get; set; }
        public List<int> Categories { get; set; } = null!;
    }
}
