using LocationService.Models;

namespace LocationService.Data{

public class LocationRepo : ILocationRepo
    {
        public LocationRepo()
        {
            using (var context = new AppDbContext())
            {

                if (context.Locations.Count()==0)
                {
                     var locations = new List<Location>
                {
                new Location 
                {
                    Zip  =90002,
                    LAT  =33.949099,
                    LNG=-118.246737,
                    City="Los Angeles"
                      
                },
                new Location
                {
                    Zip  =90247,
                    LAT  =33.890853,
                    LNG=-118.297967,
                    City="Gardena"
                },
                new Location
                {
                    Zip  =90245,
                    LAT  =33.91714,
                    LNG=-118.404267,
                    City="El Segundo"
                },
                new Location
                {
                    Zip  =90240,
                    LAT  =33.955729,
                    LNG=-118.118346,
                    City="Downey"
                },
                new Location
                {
                    Zip  =90230,
                    LAT  =33.997862,
                    LNG=-118.393617,
                    City="Culver City"
                }, new Location 
                {
                    Zip  =90069,
                    LAT  =34.093828,
                    LNG=-118.381697,
                    City="West Hollywood"
                      
                },
                new Location
                {
                    Zip  =90094,
                    LAT  =33.975414,
                    LNG=-118.41699,
                    City="Culver City"
                },
                new Location
                {
                    Zip  =90201,
                    LAT  =33.970343,
                    LNG=-118.171368,
                    City="Bell Gardens"
                },
                new Location
                {
                    Zip  =92801,
                    LAT  =33.844983,
                    LNG=-117.952151,
                    City="Anaheim"
                },
                new Location
                {
                    Zip  =92649,
                    LAT  =33.72524,
                    LNG=-118.051579,
                    City="Huntington Beach"
                }
                };
                context.Locations.AddRange(locations);
                context.SaveChanges();
                }
               
            }
        }
        public Location GetLocationByZip(int ZIP)
        {
            using (var context =  new AppDbContext())
            {
                Location location=new Location ();
                var locations =   context.Locations.Where(l=>l.Zip==ZIP).ToList();

                if (locations.Count()>0)
                {
                  return  locations.FirstOrDefault();
                }
                return  location;
            }
        }

         public  List<Location> GetAllLocations()
        {
            using (var context = new AppDbContext())
            {
                var locations =  context.Locations.ToList();

                return  locations;
            }
        }
    }

} 