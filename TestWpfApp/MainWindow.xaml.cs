using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FilmGalary.Core.Entity;
using FilmGalary.Core.Data;
using FilmGalary.Core.Service;
using System.Data.Common;
using System.Diagnostics;




namespace TestWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private MainViewModel viewModel = new MainViewModel(new FilmServiceDB(new FilmDataSource()));
        private static FilmForm filmFormWindow;
        private static FilmFormPlan filmFormPlanWindow;


        public MainWindow()
        {
            DataContext = viewModel;
            InitializeComponent();
            //filmsList.ItemsSource = films;
  
        }

        private void AddFilmFormWindow(object sender, RoutedEventArgs e)
        {
            // Получаем текущий выбранный TabItem
            var selectedTab = tabControl.SelectedItem as TabItem;
            // В зависимости от того какая вкладка открыта, будем отдавать разные формы
            //if (filmFormWinow == null) 
            //{
            //    filmFormWinow = new FilmForm(viewModel);
            //    filmFormWinow.Show();
            //}

            //Console.WriteLine(selectedTab.Header.ToString());
            //Debug.WriteLine("Все норм.");

            if (selectedTab.Name.ToString() == "watchedTab")
            {
                if (filmFormPlanWindow != null) 
                {  
                    filmFormPlanWindow.Close(); 
                }
                viewModel.IsWatchedAdd = true;
                viewModel.InPlanAdd = false;
                filmFormWindow = new FilmForm(viewModel);
                filmFormWindow.Show();
                
            }
            else if (selectedTab.Name.ToString() == "planTab")
            {
                if (filmFormWindow != null)
                {
                    filmFormWindow.Close();
                }
                viewModel.IsWatchedAdd = false;
                viewModel.InPlanAdd = true;
                filmFormPlanWindow = new FilmFormPlan(viewModel);
                filmFormPlanWindow.Show();
            }

        }
    }
}