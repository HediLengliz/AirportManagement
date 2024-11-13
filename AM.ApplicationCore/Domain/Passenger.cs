using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address.")]

        public string EmailAddress { get; set; }

    

        
  
        [Required]
        public FullName FullName { get; set; }
        [Key]
        public string PassportNumber { get; set; }
        [RegularExpression("^[0 - 9]{8}$")]
        public string TelNumber { get; set; }
        public virtual IList<Ticket> Tickets { get; set; }

        public virtual string PassengerType { get { return "Unknown passenger type"; } }

        public override string ToString()
        {
            return $"PassportNumber : {PassportNumber},FullName{FullName}";
        }
    }
}
