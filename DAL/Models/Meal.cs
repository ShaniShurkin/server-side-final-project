namespace DAL.Models
{
    public class Meal
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjectId { get; set; }

        [BsonElement("code")]
        public int Code { get; set; }
        [BsonElement("enName")]
        public int EnName { get; set; }

        [BsonElement("heName")]
        public int HeName { get; set; }
        [BsonElement("calories")]
        public double Calories { get; set; }
        [BsonElement("categories")]
        public List<int> Categories { get; set; } = null!;
    }
}
