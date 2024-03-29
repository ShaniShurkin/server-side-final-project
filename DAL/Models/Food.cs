﻿namespace DAL.Models
{
    //Code	smlmitzrach	shmmitzrach	makor	edible	psolet	ahuz_ibud_nozlim	protein	total_fat	carbohydrates	food_energy	alcohol	moisture	total_dietary_fiber	calcium	iron	magnesium	phosphorus	potassium	sodium	zinc	copper	vitamin_a_iu	carotene	vitamin_e	vitamin_c	thiamin	riboflavin	niacin	vitamin_b6	folate	folate_dfe	vitamin_b12	cholesterol	saturated_fat	butyric	caproic	caprylic	capric	lauric	myristic	palmitic	stearic	oleic	linoleic	linolenic	arachidonic	docosahexanoic	palmitoleic	parinaric	gadoleic	eicosapentaenoic	erucic	docosapentaenoic	mono_unsaturated_fat	poly_unsaturated_fat	vitamin_d	total_sugars	trans_fatty_acids	vitamin_a_re	isoleucine	leucine	valine	lysine	threonine	methionine	phenylalanine	tryptophan	histidine	tyrosine	arginine	cystine	serine	vitamin_k	pantothenic_acid	iodine	selenium	sugar_alcohols	choline	biotin	manganese	fructose	tarich_ptiha	tarich_idkun	english_name

    public class Food
    {
        #region properties
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("code")]
        public int Code { get; set; }
        [BsonElement("english_name")]
        public string EnglishName { get; set; } = null!;
        [BsonElement("smlmitzrach")]
        public int Smlmitzrach { get; set; }
        [BsonElement("shmmitzrach")]
        public string Shmmitzrach { get; set; } = null!;
        [BsonElement("categories")]
        public object Categories { get; set; } = null!;

        //public List<int?> Categories { get; set; } = null!;
        [BsonElement("short_name")]
        public string ShortName { get; set; }
        [BsonElement("makor")]
        public int Makor { get; set; }
        [BsonElement("protein")]
        public double Protein { get; set; }
        [BsonElement("total_fat")]
        public double TotalFat { get; set; }
        [BsonElement("carbohydrates")]
        public double Carbohydrates { get; set; }
        [BsonElement("food_energy")]
        public double FoodEnergy { get; set; }
        [BsonElement("total_dietary_fiber")]
        public double TotalDietaryFiber { get; set; }
        [BsonElement("calcium")]
        public double Calcium { get; set; }
        [BsonElement("iron")]
        public double Iron { get; set; }
        [BsonElement("magnesium")]
        public double Magnesium { get; set; }
        [BsonElement("phosphorus")]
        public double Phosphorus { get; set; }
        [BsonElement("potassium")]
        public double Potassium { get; set; }
        [BsonElement("sodium")]
        public double Sodium { get; set; }
        [BsonElement("vitamin_a_iu")]
        public double VitaminAIu { get; set; }
        [BsonElement("carotene")]
        public double Carotene { get; set; }
        [BsonElement("vitamin_e")]
        public double VitaminE { get; set; }
        [BsonElement("vitamin_c")]
        public double VitaminC { get; set; }
        [BsonElement("vitamin_b6")]
        public double VitaminB6 { get; set; }
        [BsonElement("folate")]
        public double Folate { get; set; }

        [BsonElement("vitamin_b12")]
        public double VitaminB12 { get; set; }
        [BsonElement("cholesterol")]
        public double Cholesterol { get; set; }
        [BsonElement("saturated_fat")]
        public double SaturatedFat { get; set; }

        [BsonElement("vitamin_d")]
        public double VitaminD { get; set; }
        [BsonElement("total_sugars")]
        public double TotalSugars { get; set; }

        [BsonElement("vitamin_a_re")]
        public double VitaminARe { get; set; }

        [BsonElement("vitamin_k")]
        public double VitaminK { get; set; }

        #endregion

        
    }
}
