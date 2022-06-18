using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trener.Commands;
using Trener.Models;
using Trener.Services;
using Trener.Stores;

namespace Trener.ViewModels
{
    public class TrainingListViewModel : ViewModelBase
    {
        private readonly TrainingList _traininglist;
        private readonly ObservableCollection<SessionViewModel> _sessions;
        public Runner _runner { get; set; }
        public SessionViewModel _last { get; set; }

        public IEnumerable<SessionViewModel> Sessions => _sessions;
        public ICommand UpdateRunnerCommand { get; }
        public ICommand NewSessionCommand { get; }
        public ICommand _DeleteListCommand { get; }

        public TrainingListViewModel(TrainingList traininglist, Runner runner, NavigationService runnerViewNavigationService, NavigationService SessionViewNavigationService)
        {
            _traininglist = traininglist;
            _sessions = new ObservableCollection<SessionViewModel>();
            _runner = runner;
            _DeleteListCommand = new DeleteListCommand(this,_traininglist, runnerViewNavigationService);
            UpdateRunnerCommand = new NavigateCommand(runnerViewNavigationService);
            NewSessionCommand = new NavigateCommand(SessionViewNavigationService);
            UpdateSessions();
            LastSession();
        }

        private async void UpdateSessions()
        {
            _sessions.Clear();

            foreach(Session session in await TrainingList.GetSessions())
            {
                SessionViewModel sessionViewModel = new SessionViewModel(session);
                _sessions.Add(sessionViewModel);
            }
        }

        private void LastSession()
        {
            if(_sessions.Count != 0)
            {
                _last = _sessions.Last();
            }
        }
    }
}
