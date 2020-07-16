using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class OfficeProcessor
    {
        public static List<OfficeModel> LoadOffices()
        {
            string sql = "select * from dbo.Office";

            return SqlDataAccess.LoadData<OfficeModel>(sql);
        }

        public static int CreateOffice(string Country, string City, string Street, short StreetNumber, Boolean isHQ, int Company)
        {
            OfficeModel office = new OfficeModel
            {
                Country = Country,
                City = City,
                Street = Street,
                StreetNumber = StreetNumber,
                isHQ = isHQ,
                Company = Company
            };

            string sql = @"insert into dbo.Office (Country, City, Street, StreetNumber, isHQ, Company) 
                            VALUES(@Country, @City, @Street, @StreetNumber, @isHQ, @Company)";

            return SqlDataAccess.SaveData<OfficeModel>(sql, office);
        }

        public static int DeleteOffice(int Id)
        {
            var args = new { Id = Id };

            string sql = "delete from dbo.Office where Id = @Id";

            return SqlDataAccess.DeleteData(sql, args);
        }

        public static OfficeModel getOfficeForPrimaryKey(int Id)
        {
            var args = new { Id = Id };

            string sql = "select * from dbo.Office where Id = @Id";

            return SqlDataAccess.GetOfficeForPrimaryKey(sql, args);
        }

        public static int UpdateOffice(int Id, string Country, string City, string Street, short StreetNumber, Boolean isHQ, int Company)
        {
            OfficeModel office = new OfficeModel
            {
                Id = Id,
                Country = Country,
                City = City,
                Street = Street,
                StreetNumber = StreetNumber,
                isHQ = isHQ,
                Company = Company
            };

            string sql = @"update dbo.Office set 
                            Country = @Country, City = @City, Street = @Street, StreetNumber = @StreetNumber, isHQ = @isHQ, Company = @Company
                            where Id = @Id";

            return SqlDataAccess.UpdateData(sql, office);
        }
    }
}
