using System;

public class Question
{
        public int ID { get; set; }
        public string content { get; set; }
        public List<Answers> answers { get; set; }
        public Question()
        {
           answers = new List<Answers>();
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
