using LAbb3.Managers;
using LAbb3.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows;

namespace LAbb3.ViewModels
{
    public class PlayViewModel : ObservableObject
    {
        #region Managers

        private readonly NavigationManager _navigationManager;
        private readonly QuizManager _quizManager;

        #endregion

        public ObservableCollection<Quiz> AvailableQuizzes => _quizManager.AllQuizzes;


        private Quiz _currentQuiz;
        public Quiz CurrentQuiz
        {
            get { return _currentQuiz; }
            set
            {
                SetProperty(ref _currentQuiz, value);
                OnPropertyChanged(nameof(NumberOfAnsweredQuestions));
                OnPropertyChanged(nameof(NumberOfCorrectAnswers));
                OnPropertyChanged(nameof(CurrentQuestion));
            }
        }

        private Question _currentQuestion;
        public Question CurrentQuestion
        {
            get { return _currentQuestion; }
            set { SetProperty(ref _currentQuestion, value); }
        }

        private int _chosenAnswer;



        /// <summary>
        /// räkna vid varje besvarad fråga
        /// </summary>
        private int _numberOfAnsweredQuestions;
        public int NumberOfAnsweredQuestions
        {
            get { return _numberOfAnsweredQuestions; }
            set { SetProperty(ref _numberOfAnsweredQuestions, value); }
        }

        /// <summary>
        ///  räkna vid varje rätt svar
        /// </summary>
        private int _numberOfCorrectAnswers;
        public int NumberOfCorrectAnswers
        {
            get { return _numberOfCorrectAnswers; }
            set { SetProperty(ref _numberOfCorrectAnswers, value); }
        }


        #region Commands

        public RelayCommand StartQuizCommand { get; }
        public RelayCommand GoBackCommand { get; }
        public RelayCommand ChooseAnswer1Command { get; }
        public RelayCommand ChooseAnswer2Command { get; }
        public RelayCommand ChooseAnswer3Command { get; }

        #endregion

        public PlayViewModel(NavigationManager navigationManager, QuizManager quizManager)
        {
            _navigationManager = navigationManager;
            _quizManager = quizManager;
            CurrentQuiz = AvailableQuizzes[0];
            GoBackCommand = new RelayCommand(GoBack);
            ChooseAnswer1Command = new RelayCommand(ChooseAnswer1);
            ChooseAnswer2Command = new RelayCommand(ChooseAnswer2);
            ChooseAnswer3Command = new RelayCommand(ChooseAnswer3);
            StartQuizCommand = new RelayCommand(StartQuiz);
        }

        private void StartQuiz()
        {
            CurrentQuestion = CurrentQuiz.GetRandomQuestion();
            NumberOfCorrectAnswers = 0;
            NumberOfAnsweredQuestions = 0;
        }

        #region SvarsMetoder
        private void ChooseAnswer1()
        {
            _chosenAnswer = 0;
            ControlAnswer();
        }


        private void ChooseAnswer2()
        {
            _chosenAnswer = 1;
            ControlAnswer();
        }
        private void ChooseAnswer3()
        {
            _chosenAnswer = 2;
            ControlAnswer();
        }
        private void ControlAnswer()
        {
            if (CurrentQuestion == null)
            {
                MessageBox.Show("You have to press the Start Game-button!");
            }
            else
            {
                NumberOfAnsweredQuestions++;
                if (_chosenAnswer == CurrentQuestion.CorrectAnswer)
                {
                    NumberOfCorrectAnswers++;
                    MessageBox.Show("Correct answer");
                }
                else
                {
                    MessageBox.Show("Wrong answer :( ");
                }

                if (NumberOfAnsweredQuestions == CurrentQuiz.Questions.Count)
                {
                    MessageBox.Show($"Thank you for playing! You got {NumberOfCorrectAnswers} of {CurrentQuiz.Questions.Count}.");
                    GoBack();
                }
                else
                {
                    CurrentQuestion = CurrentQuiz.GetRandomQuestion();
                }
            }
        }

        #endregion


        private void GoBack()
        {
            _navigationManager.CurrentViewModel = new StartViewModel(_navigationManager, _quizManager);
        }
    }

}

