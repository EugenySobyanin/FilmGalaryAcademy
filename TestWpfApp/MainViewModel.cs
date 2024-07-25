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
    public class MainViewModel: ObservableObject
    {
        private ObservableCollection<Film> _filmlist = new ObservableCollection<Film>();
        public ObservableCollection<Film> FilmList { get => _filmlist; set {_filmlist = value; OnPropertyChanged("FilmList");}}
        private FilmService filmservice;
        private Film _selectedFilm;
        public Film SelectedFilm
        {
            get => _selectedFilm;
            set
            {
                _selectedFilm = value;
                OnPropertyChanged("SelectedFilm");
            }
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

        //конструктор
        public MainViewModel(FilmService service)
        {
            filmservice = service;
            FilmList = new ObservableCollection<Film>(filmservice.GetAll());
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      filmservice.Create(
                          new Film(InputTitle)
                          );
                      FilmList = new ObservableCollection<Film>(filmservice.GetAll());
                  }));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                  (deleteCommand = new RelayCommand(obj =>
                  {
                      filmservice.Delete(
                          SelectedFilm.Id
                          );
                      FilmList = new ObservableCollection<Film>(filmservice.GetAll());
                  }));
            }
        }


    }
}
