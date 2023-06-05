namespace BL
{
    internal class MealsStracture
    {
        public Dictionary<string, List<string>> Meals { get; set; }
        public MealsStracture()
        {
            this.Meals = new Dictionary<string, List<string>>
                {
                    { "Breakfast", new List<string> { "milky", "breads", "egg" } },
                    { "Snack1", new List<string> { "snacks" } },
                    { "Lunch", new List<string> { "fleshy", "soups" } },
                    { "Snack2", new List<string> { "fruits" } },
                    { "Dinner", new List<string> { "vegetables", "fish" } }
                };


        }
    }
}
