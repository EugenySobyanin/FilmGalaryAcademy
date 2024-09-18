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
    public class SearchFilmViewModel : ObservableObject
    {
        private ObservableCollection<Film> _filmlist = new ObservableCollection<Film>();
        public ObservableCollection<Film> FilmList { get => _filmlist; set { _filmlist = value; OnPropertyChanged("FilmList"); } }
        public FilmServiceDB filmservice;

        public SearchFilmViewModel(FilmServiceDB service)
        {
            filmservice = service;
            // Либо можно попробовать здесь получать просмотренные или планируемые фильмы
            Task.Run(() => Fetch()).Wait();
        }


        // Связано с полем для ввода названия
        private string _inputTitle = string.Empty;
        public string InputTitle
        {
            get => _inputTitle;
            set
            {
                _inputTitle = value;
                OnPropertyChanged("InputTitle");
            }
        }


        public async Task Fetch()
        {
            FilmList = new ObservableCollection<Film>(await filmservice.GetContent(_inputTitle));
        }
    }
}
