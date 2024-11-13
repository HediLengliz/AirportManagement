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
        public static void test3()
        {
            using (var dbContext = new Context())
            {
                var planes = new List<Plane>();
                planes.Add(InMemorySource.Boeing1);
                planes.Add(InMemorySource.Boeing2);
                planes.Add(InMemorySource.Airbus);
                var flights = InMemorySource.Flights;
                var staffs = InMemorySource.Staffs;
                var travellers = InMemorySource.Travellers;

                dbContext.flights.AddRange(flights);
                dbContext.planes.AddRange(planes);
                dbContext.staffs.AddRange(staffs);
                dbContext.travelers.AddRange(travellers);
                dbContext.SaveChanges();



            }
        }
        static ShowLine showLine = System.Console.WriteLine;
        public static void Test2()
        {
            using (var dbContext = new Context())
            {
                var list = dbContext.Tickets.ToList();
                list.ShowList("ticket list", showLine);


            }

        }
    }

}
