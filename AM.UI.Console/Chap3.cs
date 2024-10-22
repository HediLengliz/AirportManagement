using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore;
using AM.Infrastructure;

namespace AM.UI.Console
{
    public class Chap3
    {
        public static void Test1()
        {
           
            var planes = new List<Plane>
                {
                    InMemorySource.Boeing1,
                    InMemorySource.Boeing2,
                    InMemorySource.Airbus
                };

            var flights = new List<Flight>
                {
                    InMemorySource.Flight1,
                    InMemorySource.Flight2,
                    InMemorySource.Flight3
                };

            var staffList = new List<Staff>
                {
                    InMemorySource.CaptainStaff,
                    InMemorySource.Hostess1Staff,
                    InMemorySource.Hostess2Staff
                };

            var travelers = new List<Traveller>
                {
                    InMemorySource.Traveller1,
                    InMemorySource.Traveller2,
                    InMemorySource.Traveller3
                };

     
            using (var context = new Context())
            {
                context.planes.AddRange(planes);      
                context.flights.AddRange(flights);    
                context.staffs.AddRange(staffList);    
                context.travelers.AddRange(travelers); 

                context.SaveChanges();
            }
        }
    }
}
