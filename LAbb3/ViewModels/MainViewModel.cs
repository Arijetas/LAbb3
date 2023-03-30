using LAbb3.Managers;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace LAbb3.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private readonly NavigationManager _navigationManager;

        public ObservableObject CurrentViewModel => _navigationManager.CurrentViewModel;

        public MainViewModel(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            _navigationManager.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
