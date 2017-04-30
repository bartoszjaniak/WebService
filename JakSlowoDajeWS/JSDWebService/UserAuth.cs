using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace JSDWebService
{
    public class UserAuth : SoapHeader
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public static List<string> ExecuteQuery(string queryString)
        {

            List<string> clientNameList = new List<string>();
            using (FbConnection connection = new FbConnection(ConfigurationManager.ConnectionStrings["fb"].ConnectionString))
            {
                string sqlCommand = queryString;

                connection.Open();
                FbCommand command = new FbCommand(sqlCommand, connection);

                using (FbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string temp = "";

                        temp = reader["NAME"].ToString();

                        clientNameList.Add(temp);
                    }
                }
            }
            return clientNameList;

        }

        public static bool AuthorizeUser(UserAuth usr)
        {
            
            if (usr.UserName.Equals("Admin") && usr.Password.Equals("123"))
                return true;
            else
                return false;
        }
    }
 
}