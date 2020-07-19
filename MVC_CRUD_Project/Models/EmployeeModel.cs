using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using DataLibrary.Enums;

namespace MVC_CRUD_Project.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime StartingDate { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public short VacationDays { get; set; }
        [Required]
        public ExperienceLevel ExperienceLevel { get; set; }
        public int OfficeId { get; set; }
        public string FullName { get; set; }
        //[Required]
        //public byte[] Image { get; set; }
    }
}