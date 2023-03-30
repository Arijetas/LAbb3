using LAbb3.Managers;
using LAbb3.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LAbb3.ViewModels
{
    public class StartViewModel : ObservableObject
    {
        private readonly NavigationManager _navigationManager;
        private readonly QuizManager _quizManager;

        public AsyncRelayCommand EditButtonCommand { get; }
        public AsyncRelayCommand PlayButtonCommand { get; }
        public  AsyncRelayCommand CreateButtonCommand { get; }

        public StartViewModel(NavigationManager navigationManager, QuizManager quizManager)
        {
            _navigationManager = navigationManager;
            _quizManager = quizManager;

            EditButtonCommand = new AsyncRelayCommand(EditButton);
            PlayButtonCommand = new AsyncRelayCommand(PlayButton);
            CreateButtonCommand = new AsyncRelayCommand(CreateButton);
        }

        private async Task EditButton()
        {
            await Task.Run(() => { _quizManager.AllQuizzes = new ObservableCollection<Quiz>(_quizManager.LoadQuizAsync().Result); });
            _navigationManager.CurrentViewModel = new EditViewModel(_navigationManager, _quizManager);
        }

        private  async Task PlayButton()
        {
            await Task.Run(() =>
            {
                _quizManager.AllQuizzes = new ObservableCollection<Quiz>(_quizManager.LoadQuizAsync().Result);
            });
            _navigationManager.CurrentViewModel = new PlayViewModel(_navigationManager, _quizManager);
        }

        private async Task CreateButton()
        {
            await Task.Run(() => { _quizManager.AllQuizzes = new ObservableCollection<Quiz>(_quizManager.LoadQuizAsync().Result); });
            _navigationManager.CurrentViewModel = new CreateViewModel(_navigationManager, _quizManager);
        }
    }
}
