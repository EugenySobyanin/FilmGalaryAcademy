using FilmGalary.Core.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWpfApp.Core;
using FilmGalary.Core.Entity;
using FilmGalary.Core.Service;

namespace TestWpfApp
{
    class MainViewModel: ObservableObject
    {
        private ObservableCollection<Film> _filmlist = new ObservableCollection<Film>();
        public ObservableCollection<Film> Filmlist { get => _filmlist; set {_filmlist = value; OnPropertyChanged("FilmList");}}
        private FilmService _filmservice;


    }
}
