namespace DAL.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

         public string? Gender { get; set; }

        public DateTime? BornDate { get; set; }

        public double Height { get; set; }

        public double Weight { get; set; }

        public int FitnessLevel { get; set; }

        public Route Route { get; set; }

        public DateTime StartDate { get; set; }

        public int Duration { get; set; }

        public double[] Progress { get; set; }

        public Dictionary<string, int> Food { get; set; }

        public Client(string firstName, string lastName, string emailAddress,
           DateTime bornDate, double height, double weight,
           Route route = Route.health, int fitnessLevel = 50, int duration = 4)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
            this.BornDate = bornDate;
            this.Height = height;
            this.Weight = weight;
            this.Route = route;
            this.StartDate = DateTime.Now;
            this.FitnessLevel = fitnessLevel;
            this.Duration = duration;


        }
    }
}
