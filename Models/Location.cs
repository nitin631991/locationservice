using System.ComponentModel.DataAnnotations;

namespace  LocationService.Models
{
    public class Location{

       [Key]
        public int Zip {get;set;}
        public double LAT{get;set;}
        public double LNG {get;set;}
        public string? City {get;set;}

    }
}