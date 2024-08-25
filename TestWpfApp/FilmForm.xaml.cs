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
        public FilmForm(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
