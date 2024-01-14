using CardComTask.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Task.DAL
{
    public class UserDAL
    {
        private static string SS_ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["Connection String"];
            }
        }


        

        public static int UpdateUsers(User user)
        {
            int rowCount = 0;

            try
            {
                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter("Name", User.Name));
                list.Add(new SqlParameter("UserID", User.UserID));
                list.Add(new SqlParameter("Email", User.Email));
                list.Add(new SqlParameter("Cellphone", User.Cellphone));
                list.Add(new SqlParameter("ID", User.InnerID));

                DataTable dt = ManageSql.ExecuteDataTable(SS_ConnectionString, "User_UpdateUsers", list.ToArray());

                rowCount = Convert.ToInt32(dt.Rows[0]["rowCount"]);

            }
            catch (Exception ex)
            {
                rowCount = 0;
                //writh to log - must
            }

            return rowCount;
        }

        public static List<User> GetAllUser()
        {
            List<CardComUser> userList = null;

            try
            {
                List<SqlParameter> list = new List<SqlParameter>();

                DataTable dt = ManageSql.ExecuteDataTable(SS_ConnectionString, "User_GetAllUsers", list.ToArray());

                cardComUserList = new User().Fill(dt);

            }
            catch (Exception ex)
            {
                //writh to log - must
            }

            return cardComUserList;

        }

        public static List<User>  GetUserInfo(int InnerID)
        {
            List<User> newUserList = null;

            try
            {
                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter("ID", InnerID));

                DataTable dt = ManageSql.ExecuteDataTable(SS_ConnectionString, "User_GetUserInfo", list.ToArray());

                newUserList = new mUser().Fill(dt);

            }
            catch (Exception ex)
            {
                //writh to log - must
            }

            return newUserList;

        }
        


        public static int CreateNewUser(User newUser)
        {
            int rowCount = 0;

            try
            {
                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter("Name", newUser.Name));
                list.Add(new SqlParameter("UserID", newUser.UserID));
                list.Add(new SqlParameter("Email", newUser.Email));
                list.Add(new SqlParameter("BirthDate", newUser.BirthDate));
                list.Add(new SqlParameter("Gender", newCser.Gender));
                list.Add(new SqlParameter("Cellphone", newCardComUser.Cellphone));
                
                DataTable dt = ManageSql.ExecuteDataTable(SS_ConnectionString, "CardComUser_CreateNewUser", list.ToArray());

                rowCount = Convert.ToInt32(dt.Rows[0]["rowCount"]);

            }
            catch (Exception ex)
            {
                rowCount = 0;
                //writh to log - must
            }

            return rowCount;

        }


        public static int DeleteUser(int InnerID)
        {
            int rowCount = 0;

            try
            {
                List<SqlParameter> list = new List<SqlParameter>();
                list.Add(new SqlParameter("ID", InnerID));
                
                DataTable dt = ManageSql.ExecuteDataTable(SS_ConnectionString, "CardComUser_DeleteUser", list.ToArray());

                rowCount = Convert.ToInt32(dt.Rows[0]["rowCount"]);

            }
            catch (Exception ex)
            {
                rowCount = 0;
                //writh to log - must
            }

            return rowCount;

        }
        


    }
}
