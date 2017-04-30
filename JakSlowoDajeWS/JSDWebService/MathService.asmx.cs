using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;

namespace JSDWebService
{
    [WebService(Namespace = "http://sosomething.pl/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MathService : System.Web.Services.WebService
    {
        public UserAuth UserAuth { get; set; }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        
        [WebMethod(Description="Mnorznie macierzy razy liczbę")]
        [SoapHeader("UserAuth")]
        public double[][] MacierzRazyLiczba(double[][] macierz, int mnoznik)
        {
            if (UserAuth.AuthorizeUser(UserAuth) == true)
            {
                for (var i = 0; i < 2; i++)
                {
                    for (var j = 0; j < 2; j++)
                    {
                        macierz[i][j] *= mnoznik;
                    }
                }
                return macierz;
            }
            return new[] { new[] { 0.00, 0.00 }, new[] { 0.00, 0.00 } }; 
        }

       

    }
}
