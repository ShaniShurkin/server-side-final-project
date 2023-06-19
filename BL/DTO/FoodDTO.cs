using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BL.DTO
{
    public class FoodDTO
    {
        #region properties
        public int Code { get; set; }
        public string EnglishName { get; set; } = null!;
        public int Smlmitzrach { get; set; }
        public string Shmmitzrach { get; set; } = null!;
        public object Categories { get; set; } = null!;
        //public List<int?> Categories { get; set; } = null!;
        public int Makor { get; set; }
        public double Protein { get; set; }
        public double TotalFat { get; set; }
        public double Carbohydrates { get; set; }
        public double FoodEnergy { get; set; }
        public double TotalDietaryFiber { get; set; }
        public double Calcium { get; set; }
        public double Iron { get; set; }
        public double Magnesium { get; set; }
        public double Phosphorus { get; set; }
        public double Potassium { get; set; }
        public double Sodium { get; set; }
        public double VitaminAIu { get; set; }
        public double Carotene { get; set; }
        public double VitaminE { get; set; }
        public double VitaminC { get; set; }
        public double VitaminB6 { get; set; }
        public double Folate { get; set; }

        public double VitaminB12 { get; set; }
        public double Cholesterol { get; set; }
        public double SaturatedFat { get; set; }

        public double VitaminD { get; set; }
        public double TotalSugars { get; set; }

        public double VitaminARe { get; set; }

        public double VitaminK { get; set; }
        #endregion

    }
}
