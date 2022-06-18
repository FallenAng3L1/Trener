using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Trener.Models;
using Trener.Services;
using Trener.ViewModels;

namespace Trener.Commands
{
    public class MakeSessionCommand : CommandBase
    {
        private MakeSessionViewModel _makeSessionViewModel;
        private readonly TrainingList _trainingList;
        private readonly NavigationService sessionViewNavigationService;
        private readonly Runner _runner;

        public MakeSessionCommand(MakeSessionViewModel makeSessionViewModel, TrainingList trainingList, NavigationService sessionViewNavigationService, Runner runner)
        {
            _makeSessionViewModel = makeSessionViewModel;
            _runner = runner;
            _trainingList = trainingList;
            this.sessionViewNavigationService = sessionViewNavigationService;
            _makeSessionViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object parameter)
        {
            return _makeSessionViewModel.Time > 0 &&
                _makeSessionViewModel.HeartRate > 0 && base.CanExecute(parameter);
        }
        public async override void Execute(object parameter)
        {
            Session session = new Session(_makeSessionViewModel.Time, _makeSessionViewModel.HeartRate, 
                _runner.Name, _runner.Age, _runner.Weight, _runner.Gender, _makeSessionViewModel.ID);
            await _trainingList.AddSession(session);
            MessageBox.Show("Pomyślnie wprowadzono nową sesję.", _makeSessionViewModel.Name , MessageBoxButton.OK, MessageBoxImage.Information);
            sessionViewNavigationService.Navigate();
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MakeSessionViewModel.Time) ||
                e.PropertyName == nameof(MakeSessionViewModel.HeartRate))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
