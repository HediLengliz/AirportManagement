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
        [AllowNull]
        public string? EmailAddress { get; set; }
        [Required(ErrorMessage = "First name est required.")]
        [MaxLength(300)]
        [StringLength(250, ErrorMessage = "first name doit etre inferieur a 250 charchteres .")]
        public string FirstName { get; set; }
       
        [Required(ErrorMessage = "Last name est required.")]
        [MaxLength(300)]
        [StringLength(250, ErrorMessage = "Last name must not exceed 250 characters.")]
        public string LastName { get; set; }
        [Key]
        public string PassportNumber { get; set; }
        public string TelNumber { get; set; }
        public IList<Flight> Flights { get; set; }
        public virtual string PassengerType { get { return "Unknown passenger type"; } }
        public override string ToString()
        {
            return $"PassportNumber : {PassportNumber}, FirstName : {FirstName}, LastName : {LastName}";
        }
    }
}
