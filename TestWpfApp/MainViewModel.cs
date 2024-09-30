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
using System.Windows.Controls;

namespace TestWpfApp
{
    public class MainViewModel : ObservableObject
    {
        // Для просмотренных фильмов
        private ObservableCollection<WatchedFilm> _filmlist = new ObservableCollection<WatchedFilm>();
        public ObservableCollection<WatchedFilm> FilmList { get => _filmlist; set { _filmlist = value; OnPropertyChanged("FilmList"); } }

        // Для планируемых фильмов
        private ObservableCollection<Film> _filmlistPlan = new ObservableCollection<Film>();
        public ObservableCollection<Film> FilmListPlan { get => _filmlistPlan; set { _filmlistPlan = value; OnPropertyChanged("FilmListPlan"); } }

        // Для рекомендованных фильмов
        // ...

        private FilmServiceDB filmservice;
        //private FilmServiceFile filmservice;

        private TabControl _tabControl;  // Хранение ссылки на TabControl



        // Следим какой фильм выбран
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


        // Следим за тем какая вкладка открыта
        private TabItem _selectedTab;
        public TabItem SelectedTab
        {
            //get => _selectedTab;
            //set
            //{
            //    _selectedTab = value;
            //    OnPropertyChanged("SelectedTab"); // вызов метода, уведомляющего об изменении
            //                                      // Обработка состояния здесь
            //}
            get => (TabItem)_tabControl.SelectedItem; // Возвращаем текущий выбранный элемент
            set
            {
                _tabControl.SelectedItem = value; // Устанавливаем новый выбранный элемент
                OnPropertyChanged(nameof(SelectedTab));
            }
        }

        private bool _isWatchedAdd;
        public bool IsWatchedAdd 
        {
            get => _isWatchedAdd;
            set 
            {
                _isWatchedAdd = value;
            } 
        }

        private bool _inPlanAdd;
        public bool InPlanAdd
        {
            get => _inPlanAdd;
            set
            {
                _inPlanAdd = value;
            }
        }

        // Связано с полем для ввода названия
        //private string _inputTitle = string.Empty;
        //public string InputTitle
        //{
        //    get => _inputTitle;
        //    set
        //    {
        //        _inputTitle = value;
        //        OnPropertyChanged("InputTitle");
        //    }
        //}

        // Связано с полем для ввода рейтинга кинопоиска
        private double _inputRating;
        public double InputRating
        {
            get => _inputRating;
            set
            {
                _inputRating = value;
                OnPropertyChanged("InputRating");
            }
        }

        // Связано с полем для ввода года выпуска
        private int _inputYear;
        public int InputYear
        {
            get => _inputYear;
            set
            {
                _inputYear = value;
                OnPropertyChanged("InputYear");
            }
        }

        // Связано с полем для ввода пользовательского рейтинга
        private double _inputUserRating;
        public double InputUserRating
        {
            get => _inputUserRating;
            set
            {
                _inputUserRating = value;
                OnPropertyChanged("InputUserRating");
            }
        }

        public FilmServiceDB Filmservice { get => filmservice; set => filmservice = value; }



        //конструктор
        public MainViewModel(FilmServiceDB service)
        {
            Filmservice = service;
            // Либо можно попробовать здесь получать просмотренные или планируемые фильмы
            Task.Run(() => Init()).Wait();
            //FilmList = new ObservableCollection<Film>(filmservice.GetWatched());
            //FilmListPlan = new ObservableCollection<Film>(filmservice.GetPlan());

        }

        private async Task Init()
        {
            FilmList = new ObservableCollection<WatchedFilm>(await Filmservice.GetWatched());
            //FilmListPlan = new ObservableCollection<Film>(filmservice.GetPlan());
        }

        public void UpdateWatched()
        {
            Task.Run(() => Init()).Wait();
        }

        //private RelayCommand addCommand;
        //public RelayCommand AddCommand
        //{
        //    get
        //    {
        //        return addCommand ??
        //          (addCommand = new RelayCommand(obj =>
        //          {
        //              filmservice.Create(
        //                  new Film(InputTitle, InputRating, InputYear, InputUserRating, IsWatchedAdd, InPlanAdd)
        //                  );
        //              FilmList = new ObservableCollection<Film>(filmservice.GetWatched());
        //              FilmListPlan = new ObservableCollection<Film>(filmservice.GetPlan());
        //              InputTitle = "";
        //              InputUserRating = 0;
        //          }));
        //    }
        //}

        //private RelayCommand deleteCommand;
        //public RelayCommand DeleteCommand
        //{
        //    get
        //    {
        //        return deleteCommand ??
        //          (deleteCommand = new RelayCommand(obj =>
        //          {
        //              filmservice.Delete(
        //                  SelectedFilm.Id
        //                  );
        //              FilmList = new ObservableCollection<Film>(filmservice.GetWatched());
        //              FilmListPlan = new ObservableCollection<Film>(filmservice.GetPlan());
        //          }));
        //    }
        //}


    }
}
