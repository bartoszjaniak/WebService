using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSDWebService
{
    public class Variant
    {
        public int ID { get; set; }
        public string variant { get; set; }
        public Answer answer { get; set; }

        public override string ToString()
        {
            return variant;
        }
    }
}