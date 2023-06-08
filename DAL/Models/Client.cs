namespace DAL.Models;

public class Client
{
    #region properties
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ObjectId { get; set; }
    
    [BsonElement("code")]
    public int Code { get; set; }
    
    [BsonElement("password")]
    public string Password { get; set; } = null!;
    
    [BsonElement("firstName")]
    public string FirstName { get; set; } = null!;
    
    [BsonElement("lastName")]
    public string LastName { get; set; } = null!;
    
    [BsonElement("emailAddress")]
    public string EmailAddress { get; set; } = null!;
    [BsonElement("gender")]
    public int Gender { get; set; }
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
    [BsonElement("activityLevel")]
    public int ActivityLevel { get; set; }
    [BsonElement("duration")]
    public int Duration { get; set; }
    [BsonElement("progress")]
    public double[] Progress { get; set; }
    [BsonElement("food")]
    public Dictionary<string, int> Foods { get; set; }
    [BsonElement("menu")]
    public string Menu { get; set; }
    #endregion


}
