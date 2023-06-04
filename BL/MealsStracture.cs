namespace BL
{
    internal class MealsStracture
    {
        public Dictionary<string, List<string>> Meals { get; set; }
        public MealsStracture()
        {
            this.Meals = new Dictionary<string, List<string>>
                {
                    { "Breakfast", new List<string> { "", "value2", "value3" } },
                    { "Snack1", new List<string> { "value4", "value5" } },
                    { "Lunch", new List<string> { "value6", "value7", "value8", "value9" } },
                    { "Snack2", new List<string> { "value6", "value7", "value8", "value9" } },
                    { "Dinner", new List<string> { "value6", "value7", "value8", "value9" } }
                };


        }
    }
}
