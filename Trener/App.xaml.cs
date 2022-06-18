using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Trener.Models;
using Trener.Services;
using Trener.Stores;
using Trener.ViewModels;
using Trener.DBContexts;
using Microsoft.EntityFrameworkCore;

namespace Trener
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly Runner _runner;
        private readonly NavigationStore _navigationStore;
        private readonly TrainingList _trainingList;

        public App()
        {
            _trainingList = new TrainingList();
            _runner = InitRunner();
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {

            //using (SessionDBContext dBContext = new SessionDBContext())
            //{
            //    dBContext.Database.Migrate();
            //}
            _navigationStore.CurrentViewModel = CreateTrainingListViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private RunnerViewModel CreateRunnerViewModel()
        {
            return new RunnerViewModel(_runner,new NavigationService(_navigationStore, CreateTrainingListViewModel));
        }

        private MakeSessionViewModel CreateMakeSessionViewModel()
        {
            MessageBox.Show("test");
            return new MakeSessionViewModel(_trainingList, new NavigationService(_navigationStore, CreateTrainingListViewModel), _runner);
        }
        private TrainingListViewModel CreateTrainingListViewModel()
        {
            return new TrainingListViewModel(_trainingList, _runner, new NavigationService(_navigationStore, CreateRunnerViewModel), new NavigationService(_navigationStore, CreateMakeSessionViewModel));
        }

        private Runner InitRunner()
        {
            using var db = new SessionDBContext();

            var addedCount = db.dbSessions.Count();

            if (addedCount != 0)
            {
                var table = db.dbSessions.OrderBy(d => d.ID).Last();
                return new Runner(table.Name, table.Age, table.Weight, table.Gender);
            }
            else
            {//inicjacja przykladowymi danymi
                return new Runner("Jan Kowalski", addedCount, 84, "Mężczyzna");
            }

        }
    }
}
