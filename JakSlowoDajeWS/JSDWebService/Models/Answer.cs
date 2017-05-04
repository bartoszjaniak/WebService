using JSDWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSDWebService
{
    public class Answer
    {
        public int ID { get; set; }
        public int accuracy { get; set; }
        public Question question { get; set; }
        public List<Variant> variants { get; set; }
        public Answer()
        {
            variants = new List<Variant>();
        }

        public override string ToString()
        {
            string A = "Waga odpowiedzi: " + accuracy + "\n";
            foreach (var B in variants)
                A += B + " ";
            return A;
        }
    }
}