using LAbb3.Managers;
using LAbb3.ViewModels;
using LAbb3.Views;
using System.Windows;

namespace LAbb3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationManager _navigationManager;
        private readonly QuizManager _quizManager;
        
        public App()
        {
            _navigationManager = new NavigationManager();
            _quizManager = new QuizManager();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            _navigationManager.CurrentViewModel = new StartViewModel(_navigationManager, _quizManager);
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationManager)
            };
            MainWindow.Show();
        }
    }
}
