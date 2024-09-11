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
            _dataSource = dataSource;
        }

        // асинхронный метод получения просмотренных фильмов
        public async Task<List<Film>> GetContent() 
        {
            return await _dataSource.GetWatchedList();   
        }

    }
}

