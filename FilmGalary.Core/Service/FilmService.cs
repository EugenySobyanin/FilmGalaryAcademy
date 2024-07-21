using FilmGalary.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmGalary.Core.Service
{
    public class FilmService
    {
        private FilmGalaryDataSource _dataSource;
        private List<Film> _films = []; 
        public FilmService(FilmGalaryDataSource dataSource) // конструктор
        {
            _dataSource = dataSource;
            _films = _dataSource.Get() ?? new List<Film>(); // получаем все фильмы из файла
        }

        
        public List<Film> GetAll() 
        {
            return _films;
        }


        public Film Get(int id)
        {
            List<Film> films = _dataSource.Get();

            foreach (Film film in films)
            {
                if (film.Id == id)
                {
                    return film;
                }
            }
            return null;
        }


        public void Create(Film film)
        {
            _films.Add(film);
            _dataSource.Write(_films);
        }


        public void Delete(int id)
        {
            foreach (Film film in _films)
            {
                if (film.Id == id)
                {
                    _films.Remove(film);
                    break;
                }             
            }
            _dataSource.Write(_films);
        }


        public void Update(Film film)
        {
            for (int i = 0; i < _films.Count; i++){
                if (film.Id == _films[i].Id)
                {
                    _films[i] = film;
                }
            }
            _dataSource.Write(_films);
        }



    }
}
