using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_Project.Models
{
    public class OfficeEmployeeModel
    {
        public int Id { get; set; }
        public OfficeModel Office { get; set; }
        public EmployeeModel Employee { get; set; }
    }
}