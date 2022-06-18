using System;
using System.Collections.Generic;
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
    public class RunnerViewModel : ViewModelBase
    {
        private string _name;
        public string NameProperty
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(NameProperty));
            }
        }

        private int _wiek;
        public int WiekProperty
        {
            get
            {
                return _wiek;
            }
            set
            {
                _wiek = value;
                OnPropertyChanged(nameof(WiekProperty));
            }
        }

        private int _waga;
        public int WagaProperty
        {
            get
            {
                return _waga;
            }
            set
            {
                _waga = value;
                OnPropertyChanged(nameof(WagaProperty));
            }
        }

        private string _plec;

        public string PlecProperty 
        { 
            get
            {
                return _plec;
            }
            set
            {
                _plec = value;
                OnPropertyChanged(nameof(PlecProperty));
            } 
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public RunnerViewModel(Runner runner, NavigationService runnerViewNavigationService)
        {
            SubmitCommand = new UpdateRunnerCommand(this, runner, runnerViewNavigationService);
            CancelCommand = new NavigateCommand(runnerViewNavigationService);
        }
    }
}
