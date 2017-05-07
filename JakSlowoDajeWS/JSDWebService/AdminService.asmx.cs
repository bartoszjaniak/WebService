using JSDWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace JSDWebService
{
    /// <summary>
    /// Summary description for AdminService
    /// </summary>
    [WebService(Namespace = "http://dosomething.pl/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AdminService : WebService
    {
        //Variables
        public UserAccount UserAccount { get; set; }

        #region USER
        [WebMethod]
        [SoapHeader("UserAccount")]
        public bool Login()
        {
            return UserFunctions.AuthorizeUser(UserAccount);

        }

        [WebMethod]        
        public bool AddUser(UserAccount usr)
        {
            return UserFunctions.AddUser(usr);
        }
        
        [WebMethod]
        public bool ChangePassword(string newPassword)
        {
            if (UserFunctions.AuthorizeUser(UserAccount))
            {
                return UserFunctions.ChangePassword(UserAccount, newPassword);
            }
            return false;
        }
        #endregion


        [WebMethod]
        [SoapHeader("UserAccount")]
        public bool LodadQuestionsToDataBase()
        {
            if (UserFunctions.AuthorizeUser(UserAccount))
                return Functions.LoadQuestions();
            else
                return false;
        }
    }
}
