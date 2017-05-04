using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JSDWebService.Models;

namespace JSDWebService
{
    public class DataBaseInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataBaseContext>
    {
        /// <summary>
        /// Specjalna metoda, która jest wywoływana raz po przebudowaniu bazy danych.
        /// Założenie jest, że baza jest pusta, więc trzeba ją wypełnić początkowymi danymi.
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(DataBaseContext context)
        {
            User user;
            user = new User() { nick = "test", points = 0, wins = 0, loses = 0 };


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


            context.SaveChanges();
            base.Seed(context);
        }
    }
}