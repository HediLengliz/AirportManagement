using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller : Passenger
    {
        [Required(ErrorMessage = "Health information is required.")]
        [DataType(DataType.MultilineText)]
        public string HealthInformation { get; set; }

        [Required(ErrorMessage = "Nationality is required.")]
        public string Nationality { get; set; }

        public override string PassengerType { get { return "Traveller passenger type"; } }

        public override string ToString()
        {
            return base.ToString() + $" -- Nationality : {Nationality}";
        }
    }
}
