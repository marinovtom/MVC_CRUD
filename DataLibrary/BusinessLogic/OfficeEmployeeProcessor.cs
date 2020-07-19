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

        public static int AddEmployeeToOffice(int employee, int office)
        {
            OfficeEmployeeModel officeEmployee = new OfficeEmployeeModel
            {
                Employee = employee,
                Office = office
            };

            string sql = "insert into dbo.OfficeEmployee (Employee, Office) VALUES(@Employee, @Office)";

            return SqlDataAccess.SaveData<OfficeEmployeeModel>(sql, officeEmployee);
        }

        public static int RemoveEmployeeFromOffice(int employee, int office)
        {
            var args = new { Employee = employee, Office = office };

            string sql = "delete from dbo.OfficeEmployee where Employee = @Employee and Office = @Office";

            return SqlDataAccess.DeleteData(sql, args);
        }
    }
}
