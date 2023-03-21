namespace DAL.Models
{
    //Code	smlmitzrach	shmmitzrach	makor	edible	psolet	ahuz_ibud_nozlim	protein	total_fat	carbohydrates	food_energy	alcohol	moisture	total_dietary_fiber	calcium	iron	magnesium	phosphorus	potassium	sodium	zinc	copper	vitamin_a_iu	carotene	vitamin_e	vitamin_c	thiamin	riboflavin	niacin	vitamin_b6	folate	folate_dfe	vitamin_b12	cholesterol	saturated_fat	butyric	caproic	caprylic	capric	lauric	myristic	palmitic	stearic	oleic	linoleic	linolenic	arachidonic	docosahexanoic	palmitoleic	parinaric	gadoleic	eicosapentaenoic	erucic	docosapentaenoic	mono_unsaturated_fat	poly_unsaturated_fat	vitamin_d	total_sugars	trans_fatty_acids	vitamin_a_re	isoleucine	leucine	valine	lysine	threonine	methionine	phenylalanine	tryptophan	histidine	tyrosine	arginine	cystine	serine	vitamin_k	pantothenic_acid	iodine	selenium	sugar_alcohols	choline	biotin	manganese	fructose	tarich_ptiha	tarich_idkun	english_name

    public class Food
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Code { get; set; }
        public string EnglishName { get; set; }
        public string Smlmitzrach { get; set; }
        public string Shmmitzrach { get; set; }
        public int Makor { get; set; }
        public int Edible { get; set; }
        public double AhuzIbudNozlim { get; set; }
        public double Protein { get; set; }
        public double TotalFat { get; set; }
        public double Carbohydrates { get; set; }
        public double FoodEnergy { get; set; }
        public double Alcohol { get; set; }
        public double Moisture { get; set; }
        public double AhuzIbtotalDietaryFiberudNozlim { get; set; }
        public double Calcium { get; set; }
        public double Iron { get; set; }
        public double Magnesium { get; set; }
        public double Phosphorus { get; set; }
        public double Potassium { get; set; }
        public double Sodium { get; set; }
        public double Zinc { get; set; }
        public double Copper { get; set; }
        public double VitaminAIu { get; set; }
        public double Carotene { get; set; }
        public double VitaminE { get; set; }
        public double VitaminC { get; set; }
        public double Thiamin { get; set; }
        public double Riboflavin { get; set; }
        public double Niacin { get; set; }
        public double VitaminB6 { get; set; }
        public double Folate { get; set; }
        public double FolateDfe { get; set; }
        public double VitaminB12 { get; set; }
        public double Cholesterol { get; set; }
        public double SaturatedFat { get; set; }
        public double Butyric { get; set; }
        public double Caproic { get; set; }
        public double Caprylic { get; set; }
        public double Capric { get; set; }
        public double Lauric { get; set; }
        public double Myristic { get; set; }
        public double Palmitic { get; set; }
        public double Stearic { get; set; }
        public double Oleic { get; set; }
        public double Linoleic { get; set; }
        public double Linolenic { get; set; }
        public double Arachidonic { get; set; }
        public double Docosahexanoic { get; set; }
        public double Palmitoleic { get; set; }
        public double Parinaric { get; set; }
        public double Gadoleic { get; set; }
        public double Eicosapentaenoic { get; set; }
        public double Erucic { get; set; }
        public double Docosapentaenoic { get; set; }
        public double MonoUnsaturatedFat { get; set; }
        public double PolyUnsaturatedFat { get; set; }
        public double VitaminD { get; set; }
        public double TotalSugars { get; set; }
        public double TransFattyAcids { get; set; }
        public double VitaminARe { get; set; }
        public double Isoleucine { get; set; }
        public double Leucine { get; set; }
        public double Valine { get; set; }
        public double Lysine { get; set; }
        public double Threonine { get; set; }
        public double Methionine { get; set; }
        public double Phenylalanine { get; set; }
        public double Tryptophan { get; set; }
        public double Histidine { get; set; }
        public double Tyrosine { get; set; }
        public double Arginine { get; set; }
        public double Cystine { get; set; }
        public double Serine { get; set; }
        public double VitaminK { get; set; }
        public double PantothenicAcid { get; set; }
        public double Iodine { get; set; }
        public double Selenium { get; set; }
        public double SugarAlcohols { get; set; }
        public double Choline { get; set; }
        public double Biotin { get; set; }
        public double Manganese { get; set; }
        public double Fructose { get; set; }

        public Food()
        {

        }
        
     }
}
