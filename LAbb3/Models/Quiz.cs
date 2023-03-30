using System;
using System.Collections.Generic;
using System.Linq;

namespace LAbb3.Models
{
    public class Quiz
    {
        private ICollection<Question> _questions;
        public ICollection<Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }

        private string _title;
        public string Title 
        {
            get => _title;
            set => _title = value; }

        public Quiz(string title)
        {
            _title = title;
            _questions = new List<Question>();

        }

        public Question GetRandomQuestion()
        {
            var qList = Questions.Where(q => q.aQuestion == false).ToList();
            var index = qList.Count();
            var random = new Random();
            var randomQuestion = qList[random.Next(0, index)];
            randomQuestion.aQuestion = true;
            return randomQuestion;
        }

        public void AddQuestion(string statement, int correctAnswer, params string[] answers)
        {
            Question question = new(statement, correctAnswer, answers);
            _questions.Add(question);
        }

        public void RemoveQuestion(int index)
        {
            var question = _questions.ToList();
            var questionToDelete = question[index];
            _questions.Remove(questionToDelete);
        }

    }
}
