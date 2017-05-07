using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSDWebService.Models
{
    public class Sesion
    {
        public int ID { get; set; }
        public int[] questionList { get; set; }
        public int[] users { get; set; }

    }
}