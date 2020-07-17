using DataLibrary.DataAccess;
using DataLibrary.Enums;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class EmployeeProcessor
    {
        public static List<EmployeeModel> LoadAllEmployees()
        {
            string sql = "select * from dbo.Employee";

            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }

        public static int CreateEmployee(string FirstName, string LastName, DateTime StartingDate, int Salary, short VacationDays, ExperienceLevel ExperienceLevel)
        {
            EmployeeModel employee = new EmployeeModel
            {
                FirstName = FirstName,
                LastName = LastName,
                StartingDate = StartingDate,
                Salary = Salary,
                VacationDays = VacationDays,
                ExperienceLevel = ExperienceLevel
            };

            string sql = @"insert into dbo.Employee (FirstName, LastName, StartingDate, Salary, VacationDays, ExperienceLevel) 
                            VALUES(@FirstName, @LastName, @StartingDate, @Salary, @VacationDays, @ExperienceLevel)";

            return SqlDataAccess.SaveData<EmployeeModel>(sql, employee);
        }

        public static EmployeeModel GetEmployeeById(int Id)
        {
            var args = new { Id = Id };

            string sql = "select * from dbo.Employee where Id = @Id";

            return SqlDataAccess.GetEmployeeForPrimaryKey(sql, args);
        }

        public static int UpdateEmployee(int Id, string FirstName, string LastName, DateTime StartingDate, int Salary, short VacationDays, ExperienceLevel ExperienceLevel)
        {
            EmployeeModel employee = new EmployeeModel
            {
                Id = Id, 
                FirstName = FirstName,
                LastName = LastName,
                StartingDate = StartingDate,
                Salary = Salary,
                VacationDays = VacationDays,
                ExperienceLevel = ExperienceLevel
            };

            string sql = @"update dbo.Employee set
                            FirstName = @FirstName, LastName = @LastName, StartingDate = @StartingDate, Salary = @Salary, VacationDays = @VacationDays, ExperienceLevel = @ExperienceLevel
                            where Id = @Id";

            return SqlDataAccess.UpdateData<EmployeeModel>(sql, employee);
        }

        public static int DeleteEmployee(int Id)
        {
            var args = new { Id = Id };

            string sql = "delete from dbo.Employee where Id = @Id";

            return SqlDataAccess.DeleteData(sql, args);
        }
    }
}
