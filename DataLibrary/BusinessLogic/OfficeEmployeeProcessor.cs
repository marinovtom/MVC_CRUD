using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class OfficeEmployeeProcessor
    {
        public static List<OfficeEmployeeModel> LoadAll()
        {
            string sql = "select * from dbo.OfficeEmployee";

            return SqlDataAccess.LoadData<OfficeEmployeeModel>(sql);
        }
    }
}
