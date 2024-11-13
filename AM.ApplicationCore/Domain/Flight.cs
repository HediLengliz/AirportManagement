using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        [Required(ErrorMessage = "departure doit etre rempli")]
        public string Departure { get; set; }
        [Required(ErrorMessage = "Destination doit etre rempli")]
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public float EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public int? PlaneId { get; set; }

        public virtual Plane Plane { get; set; }
       
        public virtual IList<Ticket> Tickets { get; set; }
        public override string ToString()
        {
            return $"FlightId : {FlightId}, Destination : {Destination}, FlightDate : {FlightDate}";

        }



    }
}
