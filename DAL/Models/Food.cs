using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    //Code	smlmitzrach	shmmitzrach	makor	edible	psolet	ahuz_ibud_nozlim	protein	total_fat	carbohydrates	food_energy	alcohol	moisture	total_dietary_fiber	calcium	iron	magnesium	phosphorus	potassium	sodium	zinc	copper	vitamin_a_iu	carotene	vitamin_e	vitamin_c	thiamin	riboflavin	niacin	vitamin_b6	folate	folate_dfe	vitamin_b12	cholesterol	saturated_fat	butyric	caproic	caprylic	capric	lauric	myristic	palmitic	stearic	oleic	linoleic	linolenic	arachidonic	docosahexanoic	palmitoleic	parinaric	gadoleic	eicosapentaenoic	erucic	docosapentaenoic	mono_unsaturated_fat	poly_unsaturated_fat	vitamin_d	total_sugars	trans_fatty_acids	vitamin_a_re	isoleucine	leucine	valine	lysine	threonine	methionine	phenylalanine	tryptophan	histidine	tyrosine	arginine	cystine	serine	vitamin_k	pantothenic_acid	iodine	selenium	sugar_alcohols	choline	biotin	manganese	fructose	tarich_ptiha	tarich_idkun	english_name

    public class Food
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; }

        public int Code { get; set; }


        public string Smlmitzrach { get; set; }
        public string Shmmitzrach { get; set; }
        public int Makor { get; set; }
        public int Edible { get; set; }


        public Food(string firstName, string lastName, string emailAddress,
                  DateTime bornDate, double height, double weight,
                  Route route = Route.health, int fitnessLevel = 50, int duration = 4)
        {
            
            
        }
    }
}
