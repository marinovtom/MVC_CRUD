using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        [DisplayName("Company Name")]
        public string Name { get; set; }
        [DisplayName("Creation Date")]
        public DateTime CreationDate { get; set; }
    }
}
