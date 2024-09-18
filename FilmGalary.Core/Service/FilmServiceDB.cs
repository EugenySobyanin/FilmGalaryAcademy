using FilmGalary.Core.Entity;
using FilmGalary.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace FilmGalary.Core.Service
{
    public class FilmServiceDB
    {
        // экземпляр класса датасорса(который ходит в БД)
        private FilmDataSource _dataSource;
        

        // конструктор
        public FilmServiceDB(FilmDataSource dataSource)
        {
            DataSource = dataSource;
        }

        public FilmDataSource DataSource { get => _dataSource; set => _dataSource = value; }

        // асинхронный метод получения фильмов с параметром поиска
        public async Task<List<Film>> GetContent(string search) 
        {
            return await DataSource.GetFilmListWithSearch(search);   
        }

        // асинхронный метод получения просмотренных пользователем фильмов
        public async Task<List<WatchedFilm>> GetWatched()
        {
            return await DataSource.GetWatchedList();
        }


    }
}

