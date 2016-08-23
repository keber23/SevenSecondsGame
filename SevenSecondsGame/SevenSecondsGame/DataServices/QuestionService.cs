using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenSecondsGame.DataServices
{
    public class QuestionService
    {
        List<string> questions = new List<string>();

        public QuestionService()
        {
            questions.Add("Zatancz jak kura");
            questions.Add("Szczekaj jak pies");

            questions.Add("Zawyj jak wilk");
            questions.Add("Miaucz jak kot");
            questions.Add("Poszukaj czegos zielonego");
            questions.Add("Poszukaj czegos niebieskiego");
            questions.Add("Wymień cztery potrawy");


            questions.Add("Idź jak kura i miaucz jak kot");

            questions.Add("Idź jak modelka");

            questions.Add("Zachowuj się jak zwycięzca loterii");
            
        }

        public string GetNextQuestion()
        {
            var random = new Random();
            int index = random.Next(questions.Count);
            return questions[index];
        }
    }
}
