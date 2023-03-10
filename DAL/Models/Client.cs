﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _Id { get; set; }
        //[BsonElement("firstName")]
        public string FirstName { get; set; } = null!;

        //[BsonElement("lastName")]
        public string LastName { get; set; } = null!;

        //[BsonElement("emailAddress")]
        public string EmailAddress { get; set; } = null!;

        //[BsonElement("gender")]
        public string? Gender { get; set; }

        //[BsonElement("bornDate")]
        public DateTime? BornDate { get; set; }

        //[BsonElement("height")]
        public double Height { get; set; }

        //[BsonElement("weight")]
        public double Weight { get; set; }

        //[BsonElement("fitnessLevel")]
        public int FitnessLevel { get; set; }

        //[BsonElement("route")]
        public Route Route { get; set; }

        //[BsonElement("startDate")]
        public DateTime StartDate { get; set; }

        //[BsonElement("duration")]
        public int Duration { get; set; }

        //[BsonElement("progress")]
        public double[] Progress { get; set; }

        //[BsonElement("food")]
        public Dictionary<string, int> Food { get; set; }

        public Client(string firstName, string lastName, string emailAddress,
           DateTime bornDate, double height, double weight,
           Route route = Route.health, int fitnessLevel = 50, int duration = 4)
        {
            //this._Id = ObjectId.GenerateNewId();
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