using LocationService.Data;
using Microsoft.AspNetCore.Mvc;
using LocationService.Models;

namespace LocationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
  
     readonly ILocationRepo _repository;

    public LocationController(ILocationRepo repository)
    {
        _repository = repository;
    }


      [HttpGet("GetAllLocations")]
    public  ActionResult<List<Location>> GetAllLocations()
    {
      return _repository.GetAllLocations();

    }
   
   [HttpGet("GetLocations")]
    public  ActionResult<Location> GetLocationDisctance(int ZIP1)
    {

       Location LOC1=new Location();
      
       LOC1=_repository.GetLocationByZip(ZIP1);
       
       return  LOC1;
    }

    [HttpGet("GetLocationDisctance")]
    public  ActionResult<string> GetLocationDisctance(int ZIP1, int ZIP2)
    {

       Location LOC1;
       Location LOC2;

       LOC1=_repository.GetLocationByZip(ZIP1);
       LOC2=_repository.GetLocationByZip(ZIP2);

       if (LOC1==null || LOC2==null)
       {
        return "Location not found";
       }

       double distance=00.00;
      distance= getdistance(LOC1.LAT,LOC2.LAT,LOC1.LNG,LOC2.LNG);


        string result="The distance between "+LOC1.City+" ("+ZIP1+") to "+LOC2.City+" ("+ZIP2+") is "+distance.ToString("0.###")+" miles";
         return  result;
    }


    private double toRadians(
           double angleIn10thofaDegree)
    {
        // Angle in 10th
        // of a degree
        return (angleIn10thofaDegree * 
                       Math.PI) / 180;
    }
    private double getdistance(double lat1,
                           double lat2,
                           double lon1,
                           double lon2)
    {
 
        // The math module contains
        // a function named toRadians
        // which converts from degrees
        // to radians.
        lon1 = toRadians(lon1);
        lon2 = toRadians(lon2);
        lat1 = toRadians(lat1);
        lat2 = toRadians(lat2);
 
        // Haversine formula
        double dlon = lon2 - lon1;
        double dlat = lat2 - lat1;
        double a = Math.Pow(Math.Sin(dlat / 2), 2) +
                   Math.Cos(lat1) * Math.Cos(lat2) *
                   Math.Pow(Math.Sin(dlon / 2),2);
             
        double c = 2 * Math.Asin(Math.Sqrt(a));
 
        // Radius of earth in
        // Use 6371 kilometers. 
        // Use 3956 for miles
        double r = 3956;
 
        // calculate the result
        return (c * r);
    }
}
