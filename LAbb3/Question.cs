using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LAbb3
{
    public class Question
    {

        private string _statement;

        public string Statement
        {
            get { return _statement; }
            set { _statement = value; }
        }


        private string[] _answers;

        public string[] Answers
        {
            get { return _answers; }
            set { _answers = value; }
        }


        private readonly int _correctAnswer;

        public int CorrectAnswer
        {
            get { return _correctAnswer; }
        }


        // visar json Deserialize.. vilken ctor den ska använda 
        //om den inte använder denna så använder den en tom ctor
        [JsonConstructor]
        public Question(string statement, int correctAnswer, params string[] answers)
        {
            _statement = statement;
            _answers = answers;
            _correctAnswer = correctAnswer;
        }

        public Question()
        {

        }

       /*
        public int GetCorrectAnswer()
        {
            return correctAnswer;
        }
       */

    }
}

