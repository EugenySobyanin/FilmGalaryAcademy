using FilmGalary.Core.Data;
using FilmGalary.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestWpfApp
{
    public partial class SearchFilms : Window
    {
        private SearchFilmViewModel viewModel = new SearchFilmViewModel(new FilmServiceDB(new FilmDataSource()));
        public SearchFilms()
        {
            DataContext = viewModel;
            InitializeComponent();
        }

        private void SendPostRequest(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
        }
    }
}
