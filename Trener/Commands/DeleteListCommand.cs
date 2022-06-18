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
    public class DeleteListCommand : CommandBase
    {
        private TrainingListViewModel _trainingListViewModel;
        private readonly TrainingList _trainingList;
        private readonly NavigationService sessionViewNavigationService;

        public DeleteListCommand(TrainingListViewModel trainingListViewModel, TrainingList trainingList, NavigationService sessionViewNavigationService)
        {
            _trainingListViewModel = trainingListViewModel;
            _trainingList = trainingList;
            this.sessionViewNavigationService = sessionViewNavigationService;
            _trainingListViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public async override void Execute(object parameter)
        {
            if (MessageBox.Show("Zawartość listy zostanie bezpowrotnie usunięta",
                    "Usuń listę biegów",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                await TrainingList.deleteList();
                MessageBox.Show("Lista została wyczyszczona pomyślnie.", "Usunięto", MessageBoxButton.OK, MessageBoxImage.Information);
                sessionViewNavigationService.Navigate();
            }
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCanExecutedChanged();
        }
    }
}
