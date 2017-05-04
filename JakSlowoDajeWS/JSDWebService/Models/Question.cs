using JSDWebService;
using System;
using System.Collections.Generic;

namespace JSDWebService
{
    public class Question
    {
        public int ID { get; set; }
        public string content { get; set; }
        public List<Answer> answers { get; set; }
        public Question()
        {
            answers = new List<Answer>();
        }

        public override string ToString()
        {
            string A = "Pytanie: " + content;
            foreach (var B in answers)
                A += "\n" + B;
            return A;
        }
    }
}
