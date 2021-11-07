using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace LAbb3.Views
{
    /// <summary>
    /// Interaction logic for CreateView.xaml
    /// </summary>
    public partial class CreateView : UserControl
    {
        public Quiz _selectedQuiz;

        public CreateView()
        {
            InitializeComponent();
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }


        public void AddQuiz() //lägger till  ny quiz i listan
        {
            Quiz tempQuiz = new Quiz("title", new List<Question>());
            Quiz.allQuizzes.Add(tempQuiz);
            _selectedQuiz = tempQuiz;
            _selectedQuiz.Title = "quizName";
        }
    

        private void AddQuestion_Click(object sender, RoutedEventArgs e)
        {
            var correctAnswer = 0;
            if (CheckBox1.IsChecked == true)
            {
                correctAnswer = 1;
            }

            if (CheckBox2.IsChecked == true)
            {
                correctAnswer = 2;
            }

            if (CheckBox3.IsChecked == true)
            {
                correctAnswer = 3;
            }
            //var question = new Question(StatementTextBox.Text, correctAnswer,
             //   new[] { Answer1TextBox.Text, Answer2TextBox.Text, Answer3TextBox.Text });

            _selectedQuiz.AddQuestion(StatementTextBox.Text, correctAnswer,
                new[] { Answer1TextBox.Text, Answer2TextBox.Text, Answer3TextBox.Text });
        }




        private async void CreateQuiz_Click(object sender, RoutedEventArgs e)
        {
            /*AddQuiz(); 
        }*/

        //Om den är null eller tom sträng, hoppa ur.
        if (TitleTextBox.Text is null or "")
            {
                return;
            }

            //Testat att skriva till fil med en quesiton, funkar!

            //Markera korrekta svaret
            var correctAnswer = 0;
            if (CheckBox1.IsChecked == true)
            {
                correctAnswer = 1;
            }

            if (CheckBox2.IsChecked == true)
            {
                correctAnswer = 2;
            }

            if (CheckBox3.IsChecked == true)
            {
                correctAnswer = 3;
            }

            //Frågan, rätta svaret och tre svarsalternativ..
            var question = new Question(StatementTextBox.Text, correctAnswer,
                new[] { Answer1TextBox.Text, Answer2TextBox.Text, Answer3TextBox.Text });

            //Quizens titel..
            var quizName = TitleTextBox.Text;

            FileFolder.CreateFolder();
            //await inväntar resultat innan den fortsätter.
            await FileFolder.Save(quizName, new List<Question>() { question });
        }
    }
}





