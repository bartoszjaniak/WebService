using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace JSDWebService
{
    static public class Functions
    {
        public static string RemovePolischChars(string s)
        {
            String normalizedString = s.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < normalizedString.Length; i++)
            {
                Char c = normalizedString[i];
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    stringBuilder.Append(c);
            }
            return stringBuilder.ToString().Replace('ł', 'l').Replace('Ł', 'L');
        }

        public static void AddQestiounToBase()
        {
            List<Question> lista_pytan = new List<Question>();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lista_pytan.GetType());
            Question question = new Question() { content = "ulubione imię psa?" };
            {
                Answer answer = new Answer() { accuracy = 50 };
                answer.variants.Add(new Variant() { variant = "Reksio" });
                answer.variants.Add(new Variant() { variant = "Reks" });
                question.answers.Add(answer);

            }
            {
                Answer answer = new Answer() { accuracy = 30 };
                answer.variants.Add(new Variant() { variant = "Maks" });
                answer.variants.Add(new Variant() { variant = "Max" });
                question.answers.Add(answer);
            }
            lista_pytan.Add(question);
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"test.xml");
            x.Serialize(file, lista_pytan);
            file.Close();
        }

        public static bool LoadQuestions()
        {
            try
            {
                using (var db = new DataBaseContext())
                {
                    //foreach (var A in db.Question)
                    //    db.Question.Remove(A);           
                    List<Question> lista_pytan = new List<Question>();
                    System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(lista_pytan.GetType());
                    lista_pytan.Clear();
                    using (System.Xml.XmlReader reader = System.Xml.XmlReader.Create(@"C:\Users\Bartosz Janiak\Projekty\WebServiceJakSlowoDaje\JakSlowoDajeWS\JSDWebService\test.xml"))
                    {
                        lista_pytan = (List<Question>)x.Deserialize(reader);
                    }
                    foreach (var A in lista_pytan)
                    {

                        db.Question.Add(A);
                        Console.Write(".");
                    }
                    db.SaveChanges();                    
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
