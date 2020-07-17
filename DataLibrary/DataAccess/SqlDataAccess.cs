using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataLibrary.Models;

namespace DataLibrary.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "MVC_CRUD_DB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        public static int DeleteData(string sql, Object args)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                int result;

                try
                {
                    result = cnn.Execute(sql, args);
                } 
                catch (SqlException)
                {
                    return 0;
                }

                return result;
            }
        }
        public static int UpdateData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }
        public static CompanyModel GetRecordForPrimaryKey(string sql, Object args)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.QueryFirst<CompanyModel>(sql, args);
            }
        }
        public static OfficeModel GetOfficeForPrimaryKey(string sql, Object args)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.QueryFirst<OfficeModel>(sql, args);
            }
        }

        public static int GetIdForName(string sql, Object args)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.QueryFirst<int>(sql, args);
            }
        }

        public static EmployeeModel GetEmployeeForPrimaryKey(string sql, Object args)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.QueryFirst<EmployeeModel>(sql, args);
            }
        }
    }
}
