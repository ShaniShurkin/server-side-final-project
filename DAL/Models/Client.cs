namespace DAL.Models
{
    public class Client
    {
        #region properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ObjectId { get; set; }
        [BsonElement("id")]
        public string Id { get; set; }
        public string Code { get; set; }
        [BsonElement("firstName")]
        public string FirstName { get; set; } = null!;
        [BsonElement("lastName")]
        public string LastName { get; set; } = null!;
        [BsonElement("emailAddress")]
        public string EmailAddress { get; set; } = null!;
        [BsonElement("gender")]
        public string? Gender { get; set; }
        [BsonElement("bornDate")]
        public DateTime? BornDate { get; set; }
        [BsonElement("height")]
        public double Height { get; set; }
        [BsonElement("weight")]
        public double Weight { get; set; }
        [BsonElement("fitnessLevel")]
        public int FitnessLevel { get; set; }
        [BsonElement("route")]
        //public Route route { get; set; }
        public int Route { get; set; }
        [BsonElement("startDate")]
        public DateTime StartDate { get; set; }
        [BsonElement("duration")]
        public int Duration { get; set; }
        [BsonElement("progress")]
        public double[] Progress { get; set; }
        [BsonElement("food")]
        public Dictionary<string, int> Foods { get; set; }
        #endregion

        public Client(string id,string firstName, string lastName, string emailAddress,
           DateTime bornDate, double height, double weight,
          /* Route route = Route.health,*/ int fitnessLevel = 50, int duration = 4)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
            this.BornDate = bornDate;
            this.Height = height;
            this.Weight = weight;
            this.Route = 3;
            this.StartDate = DateTime.Now;
            this.FitnessLevel = fitnessLevel;
            this.Duration = duration;
            


        }
    }
}
