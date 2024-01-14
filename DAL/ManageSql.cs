using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CardComTask.DAL
{
    internal sealed class ManageSql
    {
        /// <summary>
        /// Private Contructor
        /// </summary>
        /// <remarks>This class cannot be instanciate or heritate.</remarks>
        private ManageSql() { }



        public static DataSet ExecuteLongTimeDataSet(string connectionString, string procName, SqlParameter[] SqlParams)
        {
            DataSet ds = null;
            try
            {
                ds = SqlHelper.ExecuteLongTimeDataSet(connectionString, CommandType.StoredProcedure, procName, SqlParams);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataTable ExecuteLongTimeDataTable(string connectionString, string procName, SqlParameter[] SqlParams)
        {
            DataTable dt = null;
            try
            {
                dt = SqlHelper.ExecuteLongTimeDataTable(connectionString, CommandType.StoredProcedure, procName, SqlParams);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static Int32 ExecuteNoneQuery(string connectionString, string procName, SqlParameter[] SqlParams)
        {
            Int32 result = 0;
            try
            {
                SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, procName, SqlParams);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static DataTable ExecuteDataTable(string connectionString, string procName, SqlParameter[] SqlParams)
        {
            DataTable dt = null;
            try
            {
                dt = SqlHelper.ExecuteDataTable(connectionString, CommandType.StoredProcedure, procName, SqlParams);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataTable ExecuteSPFillData(string spName, SqlParameter[] paramArray)
        {
            DataTable dt = null;
            try
            {
                dt = SqlHelper.ExecuteSPFillData(spName, paramArray, ConfigurationManager.AppSettings["ConnectionString"]);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public static DataSet ExecuteDataSet(string connectionString, string procName, SqlParameter[] SqlParams)
        {
            DataSet ds = null;
            try
            {
                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, procName, SqlParams);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static DataSet ExecuteDataSet(string procName, SqlParameter[] SqlParams)
        {
            DataSet ds = null;
            try
            {
                ds = ExecuteDataSet(ConfigurationManager.AppSettings["ConnectionString"], procName, SqlParams);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public static object ExecuteScalar(string procName, SqlParameter[] SqlParams)
        {
            //Initialization
            object obj = null;

            try
            {
                obj = SqlHelper.ExecuteScalar(ConfigurationManager.AppSettings["ConnectionString"], CommandType.StoredProcedure, procName, SqlParams);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return obj;
        }

        public static string ConvertToDBNullParam(string sParam)
        {
            if (sParam == null)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(sParam.Trim()))
            {
                return string.Empty;
            }
            return sParam;
        }

        public static SqlDataReader GetSQLReader(SqlConnection sqlConnection, string spName, SqlParameter[] SqlParams)
        {
            return SqlHelper.ExecuteReader(sqlConnection, spName, SqlParams);
        }


        public static SqlDataReader ExecuteReader(SqlConnection conn, string cmdText, CommandType type, SqlParameter[] prms)
        {
            //SqlConnection conn = new SqlConnection(connectionString);
            using (SqlCommand cmd = new SqlCommand(cmdText, conn))
            {
                cmd.CommandTimeout = 1000;
                cmd.CommandType = type;

                if (prms != null)
                {
                    foreach (SqlParameter p in prms)
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }
    }
}
