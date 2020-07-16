using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class OfficeModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public short StreetNumber { get; set; }
        public Boolean isHQ { get; set; }
        public int Company { get; set; }
    }
}
