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
    /// Логика взаимодействия для FilmFormPlan.xaml
    /// </summary>
    public partial class FilmFormPlan : Window
    {
        public FilmFormPlan(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void FilmFormPlanClick(object sender, RoutedEventArgs e)
        {
            this.Close(); // при добавлении Планируемого фильма закрываем окно с формой

        }
    }
}
