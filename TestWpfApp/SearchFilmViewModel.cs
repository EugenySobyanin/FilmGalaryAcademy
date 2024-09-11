using FilmGalary.Core.Entity;
using FilmGalary.Core.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWpfApp.Core;

namespace TestWpfApp
{
    internal class SearchFilmViewModel : ObservableObject
    {
        private ObservableCollection<Film> _filmlist = new ObservableCollection<Film>();
        public ObservableCollection<Film> FilmList { get => _filmlist; set { _filmlist = value; OnPropertyChanged("FilmList"); } }
        private FilmServiceDB filmservice;

        public SearchFilmViewModel(FilmServiceDB service)
        {
            filmservice = service;
            // Либо можно попробовать здесь получать просмотренные или планируемые фильмы
            Task.Run(() => Init()).Wait();
        }


        private async Task Init()
        {
            FilmList = new ObservableCollection<Film>(await filmservice.GetContent());
        }
    }
}
