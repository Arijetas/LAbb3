using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace LAbb3
{
    class Quiz
    {
        public ICollection Questions
        {
            get
            {
                var Lista = new List<Question>();
                return Lista;
            }
        }

        public string Title { get; }

        /*public Question GetRandomQuestion()
        {

        }
       */

        public void AddQuestion(string statement, int correctAnswer, params string[] answers)
        {
            List<Question> Lista = new List<Question>();

          Lista.Add(new Question(statement,correctAnswer,answers));

        }

        public void RemoveQuestion(int index)
        {

        }
    }
}


