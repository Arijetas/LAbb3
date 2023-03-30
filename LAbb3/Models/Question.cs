namespace LAbb3.Models
{
    public class Question
    {
        public string Statement { get; set; }
        public string[] Answers { get; set; }
        public int CorrectAnswer { get; }
        public bool aQuestion { get; set; }


        public Question(string statement, int correctAnswer, params string[] answers)
        {
            Statement = statement;
            Answers = answers;
            CorrectAnswer = correctAnswer;

        }
    }
}
