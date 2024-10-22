using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public DateTime EmployementDate { get; set; }
        [Required]
        public string Function { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be greater than 0")]
        [Required]
        public double Salary { get; set; }
        public override string PassengerType { get { return "Staff passenger type"; } }
        public override string ToString()
        {
            return base.ToString() + $" -- Function : {Function}";
        }
    }
}
