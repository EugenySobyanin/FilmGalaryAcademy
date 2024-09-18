using System;
using System.Collections.Generic;
using System.Linq;
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
using TestWpfApp.Core;
using FilmGalary.Core.Entity;
using FilmGalary.Core.Data;
using FilmGalary.Core.Service;

namespace TestWpfApp
{
    /// <summary>
    /// Логика взаимодействия для FilmForm.xaml
    /// </summary>
    public partial class FilmForm : Window
    {
        private MainViewModel viewModel;
        private SearchFilmViewModel searchViewModel;

        private string _searchString;
        public FilmForm(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
            searchViewModel = new SearchFilmViewModel(viewModel.Filmservice);
            InitializeComponent();
        }

        private void FilmFormClick(object sender, RoutedEventArgs e)
        {
            SearchFilms anotherWindow = new SearchFilms(searchViewModel);
            anotherWindow.Show();

            this.Close(); // при добавлении Просмотренного фильма закрываем окно с формой

        }

        private void InputTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchString = (sender as TextBox)!.Text;
        }
    }
}
