using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.Models;

namespace DataLibrary.BusinessLogic
{
    public static class CompanyProcessor
    {
        public static int CreateCompany(String Name, DateTime CreationDate)
        {
            CompanyModel data = new CompanyModel
            {
                Name = Name,
                CreationDate = CreationDate
            };

            string sql = @"insert into dbo.Company (Name, CreationDate) 
                            Values(@Name, @CreationDate);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<CompanyModel> LoadCompanies()
        {
            string sql = "select * from dbo.Company";

            return SqlDataAccess.LoadData<CompanyModel>(sql);
        }

        public static int DeleteCompany(int Id)
        {
            var args = new { Id = Id };

            string sql = "delete from dbo.Company where Id = @Id;";

            return SqlDataAccess.DeleteData(sql, args);
        }

        public static CompanyModel GetCompanyForId(int Id)
        {
            var args = new { Id = Id };

            string sql = "select * from dbo.Company where Id = @Id";

            return SqlDataAccess.GetRecordForPrimaryKey(sql, args);
        }

        public static int UpdateCompany(int Id, string Name, DateTime CreationDate)
        {
            CompanyModel company = new CompanyModel { Id = Id, Name = Name, CreationDate = CreationDate };

            string sql = "update dbo.Company set Name = @Name, CreationDate = @CreationDate where Id = @Id";

            return SqlDataAccess.UpdateData(sql, company);
        }

        public static int GetCompanyIdForName(string Name)
        {
            var args = new { Name = Name };

            string sql = "select Id from dbo.Company where Name = @Name";

            return SqlDataAccess.GetIdForName(sql, args);
        }
    }
}
