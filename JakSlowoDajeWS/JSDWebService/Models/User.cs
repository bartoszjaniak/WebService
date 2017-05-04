using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSDWebService.Models
{
    public class User
    {
        public int ID { get; set; }
        public string nick { get; set; }
        public int points { get; set; }
        public int wins { get; set; }
        public int loses { get; set; }

        public override string ToString()
        {
            return ID + " : " + " " + nick + " wygrane: " + wins + " przegrane " + loses + " punkty: " + points;
        }
    }
}