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
        public int EnName { get; set; }
        public int HeName { get; set; }
        public double Calories { get; set; }
        public List<int> Categories { get; set; } = null!;
    }
}
