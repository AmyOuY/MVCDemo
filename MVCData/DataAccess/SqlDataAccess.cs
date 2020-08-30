using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCData.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionStringName = "MVCDemoDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }


        public static void SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                cnn.Execute(sql, data);
            }
        }
    }
}
