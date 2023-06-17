namespace BL.DTO
{
    public class ClientDTO
    {
        #region properties
        public int Code { get; set; }
        //public string Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public Gender Gender { get; set; }

        //public DateTime? BornDate { get; set; }
        public double Weight { get; set; }

        public double Height { get; set; }

        public int Age { get; set; }
        //public int FitnessLevel { get; set; }

        //public Route Route { get; set; }
        //public int Route { get; set; }

        //public DateTime StartDate { get; set; }
        public ActivityLevel ActivityLevel { get; internal set; }
        public string? Menu { get; set; }
        public List<MealDTO>? Meals { get; set; }


        //public int Duration { get; set; }

        //public double[] Progress { get; set; }

        //public Dictionary<string, int> Foods { get; set; }
        #endregion

    }
}
