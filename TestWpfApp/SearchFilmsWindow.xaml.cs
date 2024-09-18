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

//namespace TestWpfApp
//{
//    public partial class SearchFilms : Window
//    {
//        FilmDataSource filmDataSource = new FilmDataSource();
//        private SearchFilmViewModel viewModel = new SearchFilmViewModel(new FilmServiceDB(filmDataSource));
//        public SearchFilms()
//        {
//            DataContext = viewModel;
//            InitializeComponent();
//        }

//        private async void SendPostRequest(object sender, RoutedEventArgs e)
//        {
//            try
//            {

//                bool result = await filmDataSource.AddWatchedFilm(1, 5);

//                if (result)
//                {
//                    MessageBox.Show("Фильм успешно добавлен в просмотренные!");
//                }
//                else
//                {
//                    MessageBox.Show("Ошибка при добавлении фильма");
//                }
//            }
//            catch (HttpRequestException httpEx)
//            {
//                MessageBox.Show($"Ошибка сети: {httpEx.Message}.");
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Произошла ошибка: {ex.Message}.");
//            }
//        }
//    }
//}
namespace TestWpfApp
{
    public partial class SearchFilms : Window
    {
        private FilmDataSource filmDataSource;
        private SearchFilmViewModel viewModel;

        // Конструктор
        public SearchFilms(SearchFilmViewModel vm)
        {
            filmDataSource = vm.filmservice.DataSource;
            viewModel = vm; // Передача его в viewModel
            viewModel.Fetch();
            DataContext = viewModel;
            InitializeComponent();
        }

        private async void SendPostRequest(object sender, RoutedEventArgs e)
        {
            try
            {
                bool result = await filmDataSource.AddWatchedFilm(1, 5);

                if (result)
                {
                    MessageBox.Show("Фильм успешно добавлен в просмотренные! 🎉");
                }
                else
                {
                    MessageBox.Show("Ошибка при добавлении фильма. ❌");
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Ошибка сети: {httpEx.Message}. ⚠️");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}. ⚠️");
            }
        }
    }
}