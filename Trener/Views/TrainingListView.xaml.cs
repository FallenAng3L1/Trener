using System.Windows;
using System.Windows.Controls;
using Trener.DBContexts;
using Trener.ViewModels;

namespace Trener.Views
{
    /// <summary>
    /// Interaction logic for TrainingListView.xaml
    /// </summary>
    public partial class TrainingListView : UserControl
    {
        public TrainingListView()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void PrintText(object sender, SelectionChangedEventArgs args)
        {
            //MessageBox.Show((sender as ListView).SelectedIndex.ToString());
            using var db = new SessionDBContext();
            if((sender as ListView).SelectedValue != null)
            {
                var sesja = (sender as ListView).SelectedValue as SessionViewModel;
                //SessionTable tabela = new SessionTable();

                if (db.dbSessions.Find(sesja.ID) != null)
                {
                    var tabela = db.dbSessions.Find(sesja.ID);
                    db.dbSessions.Remove(tabela);
                    db.SaveChanges();
                }
            }
        }
    }
}
