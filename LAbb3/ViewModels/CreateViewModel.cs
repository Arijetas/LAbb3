using LAbb3.Managers;
using LAbb3.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LAbb3.ViewModels
{
    public class CreateViewModel : ObservableObject
    {
        #region Managers

        private readonly QuizManager _quizManager;
        private readonly NavigationManager _navigationManager;

        #endregion

        private Quiz _creatingQuiz;
        public Quiz CreatingQuiz
        {
            get => _creatingQuiz;
            set
            {
                SetProperty(ref _creatingQuiz, value);
            }
        }


        private string _quizTitle;
        public string QuizTitle
        {
            get => _quizTitle;
            set
            {
                SetProperty(ref _quizTitle, value);
                OnPropertyChanged(nameof(CreatingQuiz.Title));
            }
        }

        private string _statement;
        public string Statement
        {
            get { return _statement; }
            set
            {
                SetProperty(ref _statement, value);
            }
        }

        #region Answer Stuff
        private string _answer1;
        public string Answer1
        {
            get => _answer1;
            set
            {
                SetProperty(ref _answer1, value);
                Answers[0] = _answer1;
                OnPropertyChanged(nameof(CorrectAnswer));
            }
        }

        private string _answer2;
        public string Answer2
        {
            get => _answer2;
            set
            {
                SetProperty(ref _answer2, value);
                Answers[1] = _answer2;
                OnPropertyChanged(nameof(CorrectAnswer));
            }
        }

        private string _answer3;
        public string Answer3
        {
            get => _answer3;
            set
            {
                SetProperty(ref _answer3, value);
                Answers[2] = _answer3;
                OnPropertyChanged(nameof(CorrectAnswer));
            }
        }

        private int _correctAnswer;
        public int CorrectAnswer
        {
            get => _correctAnswer;
            set { SetProperty(ref _correctAnswer, value); }
        }

        private readonly ObservableCollection<string> _answers = new() { "", "", "" };

        public ObservableCollection<string> Answers
        {
            get { return _answers; }
        }

        #endregion

        public ObservableCollection<string> QuestionList
            
        {
            get { return CreatingQuiz != null ? new ObservableCollection<string>(CreatingQuiz.Questions.Select(q => q.Statement)) : new ObservableCollection<string>(); }
        }

        #region Commands
        public RelayCommand GoBackCommand { get; }
        public AsyncRelayCommand SaveQuizCommand { get; }   
        public RelayCommand AddQuestionCommand { get; }
        public RelayCommand CreateQuizCommand { get; }
        #endregion

        public CreateViewModel(NavigationManager navigationManager, QuizManager quizManager)
        {
            _navigationManager = navigationManager;
            _quizManager = quizManager;
            CorrectAnswer = 0;
            GoBackCommand = new RelayCommand(GoBack);
            SaveQuizCommand = new AsyncRelayCommand(SaveQuiz, CanSaveQuiz);
            AddQuestionCommand = new RelayCommand(AddQuestion, CanAddQuestion);
            CreateQuizCommand = new RelayCommand(CreateQuiz, CanCreateQuiz);

            PropertyChanged += OnViewModelPropertyChanged;
        }

        #region Metoder
        private void GoBack()
        {
            _navigationManager.CurrentViewModel = new StartViewModel(_navigationManager, _quizManager);
        }

        private async Task SaveQuiz()
        {
            await _quizManager.SaveQuizzesToFile();
            MessageBox.Show("Your quiz was successfully saved");
            GoBack();

        }
        private bool CanSaveQuiz()
        {
            if (CreatingQuiz != null && CreatingQuiz.Questions.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AddQuestion()
        {
            CreatingQuiz.AddQuestion(_statement, _correctAnswer, _answer1, _answer2, _answer3);
            OnPropertyChanged(nameof(QuestionList));

            Statement = "";
            CorrectAnswer = 0;
            Answer1 = "";
            Answer2 = "";
            Answer3 = "";
            Answers[0] = "";
            Answers[1] = "";
            Answers[2] = "";
        }

        private bool CanAddQuestion()
        {
            if (CreatingQuiz != null &&
               !string.IsNullOrWhiteSpace(_statement) &&
               !string.IsNullOrWhiteSpace(_answer1) &&
               !string.IsNullOrWhiteSpace(_answer2) &&
               !string.IsNullOrWhiteSpace(_answer3))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CanCreateQuiz()
        {
            bool canCreate = false;
            foreach (var quiz in _quizManager.AllQuizzes)
            {
                if (!string.IsNullOrWhiteSpace(_quizTitle) && _quizTitle.ToLower() != quiz.Title.ToLower())
                {
                    canCreate = true;
                }
                else
                {
                    canCreate = false;
                    break;
                }
            }
            return canCreate;
        }

        private void CreateQuiz()
        {
            CreatingQuiz = new Quiz(_quizTitle);
            _quizManager.AllQuizzes.Add(CreatingQuiz);
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveQuizCommand.NotifyCanExecuteChanged();
            AddQuestionCommand.NotifyCanExecuteChanged();
            CreateQuizCommand.NotifyCanExecuteChanged();
        }

#endregion
    }
}
