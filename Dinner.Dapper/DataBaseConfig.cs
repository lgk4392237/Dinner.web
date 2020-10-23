using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Dinner.Dapper
{
    public class DataBaseConfig
    {
        private static DataBaseConfig instance;
        private static object lockObj=new object();
        private DataBaseConfig()
        { 
        }
        public static DataBaseConfig GetInstance()
        {
            if (instance==null)
            {
                lock (lockObj)
                {
                    if (instance==null)
                    {
                        instance = new DataBaseConfig();
                    }
                }
            }
            return instance;
        }
        public IDbConnection GetSqlConnection(string sqlConnectionString = null)
        {
            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                sqlConnectionString = AppConfigurtaionHelp.Configuration["ConnectionStrings"];
            }
            using (IDbConnection conn = new SqlConnection(sqlConnectionString))
            {
                conn.Open();
                return conn;
            }
        }
    }
}
