namespace DAL.Models
{
    //Code	smlmitzrach	shmmitzrach	makor	edible	psolet	ahuz_ibud_nozlim	protein	total_fat	carbohydrates	food_energy	alcohol	moisture	total_dietary_fiber	calcium	iron	magnesium	phosphorus	potassium	sodium	zinc	copper	vitamin_a_iu	carotene	vitamin_e	vitamin_c	thiamin	riboflavin	niacin	vitamin_b6	folate	folate_dfe	vitamin_b12	cholesterol	saturated_fat	butyric	caproic	caprylic	capric	lauric	myristic	palmitic	stearic	oleic	linoleic	linolenic	arachidonic	docosahexanoic	palmitoleic	parinaric	gadoleic	eicosapentaenoic	erucic	docosapentaenoic	mono_unsaturated_fat	poly_unsaturated_fat	vitamin_d	total_sugars	trans_fatty_acids	vitamin_a_re	isoleucine	leucine	valine	lysine	threonine	methionine	phenylalanine	tryptophan	histidine	tyrosine	arginine	cystine	serine	vitamin_k	pantothenic_acid	iodine	selenium	sugar_alcohols	choline	biotin	manganese	fructose	tarich_ptiha	tarich_idkun	english_name

    public class Food
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int Code { get; set; }
        [BsonElement("englishName")]
        public string EnglishName { get; set; }
        [BsonElement("smlmitzrach")]
        public string Smlmitzrach { get; set; }
        [BsonElement("shmmitzrach")]
        public string Shmmitzrach { get; set; }
        [BsonElement("makor")]
        public int Makor { get; set; }
        [BsonElement("edible")]
        public int Edible { get; set; }
        [BsonElement("ahuzIbudNozlim")]
        public double AhuzIbudNozlim { get; set; }
        [BsonElement("protein")]
        public double Protein { get; set; }
        [BsonElement("totalFat")]
        public double TotalFat { get; set; }
        [BsonElement("carbohydrates")]
        public double Carbohydrates { get; set; }
        [BsonElement("foodEnergy")]
        public double FoodEnergy { get; set; }
        [BsonElement("alcohol")]
        public double Alcohol { get; set; }
        [BsonElement("moisture")]
        public double Moisture { get; set; }
        [BsonElement("ahuzIbtotalDietaryFiberudNozlim")]
        public double AhuzIbtotalDietaryFiberudNozlim { get; set; }
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
        [BsonElement("zinc")]
        public double Zinc { get; set; }
        [BsonElement("copper")]
        public double Copper { get; set; }
        [BsonElement("vitaminAIu")]
        public double VitaminAIu { get; set; }
        [BsonElement("carotene")]
        public double Carotene { get; set; }
        [BsonElement("vitaminE")]
        public double VitaminE { get; set; }
        [BsonElement("vitaminC")]
        public double VitaminC { get; set; }
        [BsonElement("thiamin")]
        public double Thiamin { get; set; }
        [BsonElement("riboflavin")]
        public double Riboflavin { get; set; }
        [BsonElement("niacin")]
        public double Niacin { get; set; }
        [BsonElement("vitaminB6")]
        public double VitaminB6 { get; set; }
        [BsonElement("folate")]
        public double Folate { get; set; }
        [BsonElement("folateDfe")]
        public double FolateDfe { get; set; }
        [BsonElement("vitaminB12")]
        public double VitaminB12 { get; set; }
        [BsonElement("cholesterol")]
        public double Cholesterol { get; set; }
        [BsonElement("saturatedFat")]
        public double SaturatedFat { get; set; }
        [BsonElement("butyric")]
        public double Butyric { get; set; }
        [BsonElement("caproic")]
        public double Caproic { get; set; }
        [BsonElement("caprylic")]
        public double Caprylic { get; set; }
        [BsonElement("capric")]
        public double Capric { get; set; }
        [BsonElement("lauric")]
        public double Lauric { get; set; }
        [BsonElement("myristic")]
        public double Myristic { get; set; }
        [BsonElement("palmitic")]
        public double Palmitic { get; set; }
        [BsonElement("stearic")]
        public double Stearic { get; set; }
        [BsonElement("oleic")]
        public double Oleic { get; set; }
        [BsonElement("linoleic")]
        public double Linoleic { get; set; }
        [BsonElement("linolenic")]
        public double Linolenic { get; set; }
        [BsonElement("arachidonic")]
        public double Arachidonic { get; set; }
        [BsonElement("docosahexanoic")]
        public double Docosahexanoic { get; set; }
        [BsonElement("palmitoleic")]
        public double Palmitoleic { get; set; }
        [BsonElement("parinaric")]
        public double Parinaric { get; set; }
        [BsonElement("gadoleic")]
        public double Gadoleic { get; set; }
        [BsonElement("eicosapentaenoic")]
        public double Eicosapentaenoic { get; set; }
        [BsonElement("erucic")]
        public double Erucic { get; set; }
        [BsonElement("docosapentaenoic")]
        public double Docosapentaenoic { get; set; }
        [BsonElement("monoUnsaturatedFat")]
        public double MonoUnsaturatedFat { get; set; }
        [BsonElement("polyUnsaturatedFat")]
        public double PolyUnsaturatedFat { get; set; }
        [BsonElement("vitaminD")]
        public double VitaminD { get; set; }
        [BsonElement("totalSugars")]
        public double TotalSugars { get; set; }
        [BsonElement("transFattyAcids")]
        public double TransFattyAcids { get; set; }
        [BsonElement("vitaminARe")]
        public double VitaminARe { get; set; }
        [BsonElement("isoleucine")]
        public double Isoleucine { get; set; }
        [BsonElement("leucine")]
        public double Leucine { get; set; }
        [BsonElement("valine")]
        public double Valine { get; set; }
        [BsonElement("lysine")]
        public double Lysine { get; set; }
        [BsonElement("threonine")]
        public double Threonine { get; set; }
        [BsonElement("methionine")]
        public double Methionine { get; set; }
        [BsonElement("phenylalanine")]
        public double Phenylalanine { get; set; }
        [BsonElement("tryptophan")]
        public double Tryptophan { get; set; }
        [BsonElement("histidine")]
        public double Histidine { get; set; }
        [BsonElement("tyrosine")]
        public double Tyrosine { get; set; }
        [BsonElement("arginine")]
        public double Arginine { get; set; }
        [BsonElement("cystine")]
        public double Cystine { get; set; }
        [BsonElement("serine")]
        public double Serine { get; set; }
        [BsonElement("vitaminK")]
        public double VitaminK { get; set; }
        [BsonElement("pantothenicAcid")]
        public double PantothenicAcid { get; set; }
        [BsonElement("iodine")]
        public double Iodine { get; set; }
        [BsonElement("selenium")]
        public double Selenium { get; set; }
        [BsonElement("sugarAlcohols")]
        public double SugarAlcohols { get; set; }
        [BsonElement("choline")]
        public double Choline { get; set; }
        [BsonElement("biotin")]
        public double Biotin { get; set; }
        [BsonElement("manganese")]
        public double Manganese { get; set; }
        [BsonElement("fructose")]
        public double Fructose { get; set; }

        public Food()
        {

        }
        
     }
}
