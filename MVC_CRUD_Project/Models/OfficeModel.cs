using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_Project.Models
{
    public class OfficeModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public short StreetNumber { get; set; }
        public Boolean IsHQ { get; set; }
    }
}