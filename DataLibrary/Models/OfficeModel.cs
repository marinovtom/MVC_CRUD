using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DataLibrary.Models
{
    public class OfficeModel
    {
        public int Id { get; set; }
        [DisplayName("Country")]
        public string Country { get; set; }
        [DisplayName("City")]
        public string City { get; set; }
        [DisplayName("Street")]
        public string Street { get; set; }
        [DisplayName("Street number")]
        public short StreetNumber { get; set; }
        [DisplayName("Is Headquarters")]
        public Boolean isHQ { get; set; }
        public int Company { get; set; }
    }
}
