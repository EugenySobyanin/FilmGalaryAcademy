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

        public MainWindow()
        {
            DataContext = viewModel;
            InitializeComponent();
            //filmsList.ItemsSource = films;
  
        }

        private void AddFilmFormWindow(object sender, RoutedEventArgs e)
        {
            if (filmFormWinow == null) 
            {
                filmFormWinow = new FilmForm();
                filmFormWinow.Show();
            }

        }



    }
}