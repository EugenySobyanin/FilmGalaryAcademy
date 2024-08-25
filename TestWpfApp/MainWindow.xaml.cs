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
        //public Film obj1 = new(0, "Пираты карибского моря.");
        //public Film obj2 = new(1, "Тачки");
        //Film obj3 = new(2, "Остров проклятых");



        //ObservableCollection<Film> films = new ObservableCollection<Film>
        //{
        //    new Film(0, "Пираты карибского моря."),
        //    new Film(1, "Пираты карибского моря."),
        //    new Film(2, "Пираты карибского моря."),
        //};
        //public FilmService service = new FilmService(new FilmGalaryDataSource());
        //ObservableCollection<Film> films2 = new ObservableCollection<Film>(service.GetAll());
        private MainViewModel viewModel = new MainViewModel(new FilmService(new FilmGalaryDataSource()));
        private static FilmForm filmFormWinow;
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
                viewModel.IsWatchedAdd = true;
                viewModel.InPlanAdd = false;
                filmFormWinow = new FilmForm(viewModel);
                filmFormWinow.Show();
            }
            else if (selectedTab.Name.ToString() == "planTab")
            {
                viewModel.IsWatchedAdd = false;
                viewModel.InPlanAdd = true;
                filmFormPlanWindow = new FilmFormPlan(viewModel);
                filmFormPlanWindow.Show();
            }

        }
    }
}