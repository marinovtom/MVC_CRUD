using DataLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLibrary.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Starting Date")]
        public DateTime StartingDate { get; set; }
        [Required]
        [DisplayName("Salary")]
        public int Salary { get; set; }
        [Required]
        [DisplayName("Vacation days")]
        public short VacationDays { get; set; }
        [Required]
        [DisplayName("Experience Level")]
        public ExperienceLevel ExperienceLevel { get; set; }
    }
}
