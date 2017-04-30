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

        

        public static bool AuthorizeUser(UserAuth usr)
        {
            
            if (DAL.UserInvalid(usr.UserName, usr.Password) == 0)
                return true;
            else
                return false;
        }
    }
 
}