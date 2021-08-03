using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote.DBSource
{
    public class UserInfoManager
    {
        public static DataRow GetUserInfoByAccount(string account)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                @" SELECT [ID], [Account], [PWD], [Name], [Email]
                    FROM UserInfo
                    WHERE [Account] = @account
                ";


            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@account", account));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        public static DataRow GetUserInfoByUID(string id)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                @" SELECT [ID], [Account], [PWD], [Name], [Email]
                    FROM UserInfo
                    WHERE [ID] = @id
                ";


            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));

            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        public static void CreateUser(string account, string pwd, string name, string email)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" INSERT INTO [dbo].[UserInfo]
                    (
                        ID
                        ,Account
                        ,PWD
                        ,Name
                        ,Email
                    )
                    VALUES
                    (
                        @id
                        ,@account
                        ,@pwd
                        ,@name
                        ,@email
                    );";

            
            // connect db & execute
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))
                {
                    comm.Parameters.AddWithValue("@id", UIDCreator());
                    comm.Parameters.AddWithValue("@account", account);
                    comm.Parameters.AddWithValue("@pwd", pwd);
                    comm.Parameters.AddWithValue("@name", name);
                    comm.Parameters.AddWithValue("@email", email);

                    try
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Logger.WriteLog(ex);
                    }
                }
            }
        }

        public static bool UpdateUser(string id, string account, string name, string email)
        {

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [UserInfo]
                    SET
                        Account     = @account
                        ,Name     = @name
                        ,Email  = @email
                    WHERE 
                        ID = @id;";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@id", id));
            paramList.Add(new SqlParameter("@account", account));
            paramList.Add(new SqlParameter("@name", name));
            paramList.Add(new SqlParameter("@email", email));


            try
            {
                int effectRows = DBHelper.ModifyData(connStr, dbCommand, paramList);

                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }

        public static DataTable GetDataBase(string str)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand;
            if (str.CompareTo("AS") == 0)
            {
                dbCommand =
                   $@" SELECT 
                        CreateDate
                    FROM Accounting
                    ORDER BY CreateDate ASC;";
            }
            else if (str.CompareTo("AL") == 0)
            {
                dbCommand =
                    $@" SELECT 
                        CreateDate
                    FROM Accounting
                    ORDER BY CreateDate DESC;";
            }
            else
            {
                dbCommand =
                $@" SELECT 
                        *
                    FROM UserInfo;";
            }
            List<SqlParameter> list = new List<SqlParameter>();
            //list.Add(new SqlParameter("@dbName", dbName));

            try
            {
                return DBHelper.ReadDataTable(connStr, dbCommand, list);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        public static void DeleteAccounting(string ID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" DELETE [UserInfo]
                    WHERE ID = @id ";


            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@id", ID));


            try
            {
                DBHelper.ModifyData(connStr, dbCommand, paramList);
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }

        public static bool UpdateUserPassword(string id, string pwd)
        {

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                $@" UPDATE [UserInfo]
                    SET
                        PWD     = @pwd
                    WHERE 
                        ID = @id;";

            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("@id", id));
            paramList.Add(new SqlParameter("@pwd", pwd));

            try
            {
                int effectRows = DBHelper.ModifyData(connStr, dbCommand, paramList);

                if (effectRows == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }

        private static string UIDCreator()
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                @" SELECT NEWID() AS NID;";

            List<SqlParameter> list = new List<SqlParameter>();

            try
            {
                DataRow dr = DBHelper.ReadDataRow(connectionString, dbCommandString, list);
                string nid = dr["NID"].ToString();
                return nid;
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }


    }
}
