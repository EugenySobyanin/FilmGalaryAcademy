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
using System.Windows.Media.Effects;




namespace TestWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        // Здесь создается экземпляр Main
        private MainViewModel viewModel = new MainViewModel(new FilmServiceDB(new FilmDataSource()));
        //public MainViewModel ViewModel
        //{
        //    get { return viewModel; }
        //}
        private static FilmForm filmFormWindow;
        private static FilmFormPlan filmFormPlanWindow;
        private static SearchFilms searchFilmsWindow;


        public MainWindow()
        {
            DataContext = viewModel;
            InitializeComponent();
            //filmsList.ItemsSource = films;
  
        }

        private void AddSearchWindow(object sender, RoutedEventArgs e)
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

            //if (selectedTab.Name.ToString() == "watchedTab")
            //{
            //    if (filmFormPlanWindow != null) 
            //    {  
            //        filmFormPlanWindow.Close(); 
            //    }
            //    viewModel.IsWatchedAdd = true;
            //    viewModel.InPlanAdd = false;
            //    filmFormWindow = new FilmForm(viewModel);
            //    filmFormWindow.Show();

            //}
            //else if (selectedTab.Name.ToString() == "planTab")
            //{
            //    if (filmFormWindow != null)
            //     filmFormPlanWindow = new FilmFormPlan(viewModel);
            //    filmFormPlanWindow.Show();
            //}  {
            //        filmFormWindow.Close();
            //    }
            //    viewModel.IsWatchedAdd = false;
            //    viewModel.InPlanAdd = true;

            this.Effect = (BlurEffect)FindResource("BlurEffect");
            searchFilmsWindow = new SearchFilms(new SearchFilmViewModel(viewModel.Filmservice), this.viewModel);
            searchFilmsWindow.ShowDialog();
            this.Effect = null;


        }
    }
}