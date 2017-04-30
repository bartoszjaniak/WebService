using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace JSDWebService
{
    public class DAL
    {

        //przykład pobrania procedurki zwracającej jedną rzcz
        public static int UserInvalid(string Login, string Password)
        {
                FbCommand cmd = new FbCommand("UserInvalid");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@login", Login);
                cmd.Parameters.Add("@pw", Password);
                using (cmd.Connection = new FbConnection(ConfigurationManager.ConnectionStrings["fb"].ConnectionString))
                {
                    cmd.Connection.Open();
                    int id = Convert.ToInt32(cmd.ExecuteScalar());
                    return id;
                }
            }
       
        public static bool ConnectionTest()
        {
            bool status = false;
            using (FbConnection connection = new FbConnection(ConfigurationManager.ConnectionStrings["fb"].ConnectionString))
            {
                string sqlCommand = string.Format(@"select first 1 * from users");

                connection.Open();
                FbCommand command = new FbCommand(sqlCommand, connection);

                using (FbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string temp = "";

                        temp = reader[0].ToString();
                        if (temp.Length > 0 ) status = true;

                    }
                }
            }
            return status;
        }

    }
}