using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAbb3
{
    class Question
    {
        public string Statement { get; set; }
        public string[] Answers { get; set; }

        private readonly int correctAnswer;


        public Question(string statement, int correctAnswer, params string[] answers)
        {
            Statement = statement;
            Answers = answers;


        }


        /*
         public int GetCorrectAnswer()
         {
             return correctAnswer;
         }
        */

    }
}

