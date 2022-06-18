using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trener.DBContexts;
using Trener.Models;
using Trener.Services;
using Trener.ViewModels;

namespace Trener.Commands
{
    public class UpdateRunnerCommand : CommandBase
    {
        private RunnerViewModel _runnerViewModel;
        private readonly Runner _runner;
        private readonly NavigationService runnerViewNavigationService;
        

        public UpdateRunnerCommand(RunnerViewModel runnerViewModel, Runner runner, NavigationService runnerViewNavigationService)
        {
            _runnerViewModel = runnerViewModel;
            _runner = runner;
            this.runnerViewNavigationService = runnerViewNavigationService;
            _runnerViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        
        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_runnerViewModel.NameProperty) && 
                _runnerViewModel.WagaProperty>0 && 
                _runnerViewModel.WiekProperty>0 &&base.CanExecute(parameter);
        }
        public override void Execute(object parameter)
        {
            Runner runner = new Runner(_runnerViewModel.NameProperty, _runnerViewModel.WiekProperty, _runnerViewModel.WagaProperty, _runnerViewModel.PlecProperty);
            _runner.UpdateRunner(runner);
            MessageBox.Show("Pomyślnie uaktualniono warunki fizyczne.", "aktualizacja", MessageBoxButton.OK, MessageBoxImage.Information);
            runnerViewNavigationService.Navigate();            
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(RunnerViewModel.NameProperty) ||
                e.PropertyName == nameof(RunnerViewModel.WagaProperty) ||
                    e.PropertyName == nameof(RunnerViewModel.WiekProperty) ||
                        e.PropertyName == nameof(RunnerViewModel.PlecProperty))
            {
                OnCanExecutedChanged();
            }
        }

    }
}
