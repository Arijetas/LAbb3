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
    public class Quiz
    {
        private ICollection<Question> _questions;

        public ICollection <Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }


       /* public ICollection Questions
        {
            get
            {
                var questions = new List<Question>();
                return questions;
            }
        }*/

        public static List<Quiz> allQuizzes = new List<Quiz>(); //Lista för alla quiz




        private string _title;

        public string Title
        {
            get => _title;
            set => _title = value;
        }

       
        public Quiz(string title, List <Question> questions)
        {
            _title = title;
            _questions = questions;
        }

    
        /*public Question GetRandomQuestion()
       {

       }
      */

        public void AddQuestion(string statement, int correctAnswer, params string[] answers)
        {

            var question = new Question(statement,correctAnswer,answers);
            Questions.Add(question);

        }

        public void RemoveQuestion(int index)
        {

        }
    }
}


