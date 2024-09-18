using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmGalary.Core.Utils;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FilmGalary.Core.Entity;
using Newtonsoft.Json;

namespace FilmGalary.Core.Data
{
    public class FilmDataSource
    {
        public static HttpClient client = new HttpClient();

        public FilmDataSource()
        {
            client.BaseAddress = new Uri(" http://127.0.0.1:8000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        // Метод для получения списка объектов при GET запросе
        // Этот метод должен принимать строку для отправки запроса с параметром для поиска
        // Пример запроса: http://127.0.0.1:8000/api/v1/films/?search=Пираты
        public async Task<List<Film>> GetFilmListWithSearch(string searchTerm)
        {

            // Кодировщик URL, чтобы избежать проблем с пробелами и специальными символами
            string encodedSearchTerm = Uri.EscapeDataString(searchTerm);

            HttpResponseMessage response = await client.GetAsync($"api/v1/films/?search={encodedSearchTerm}");
            response.EnsureSuccessStatusCode();

            List<Film> FilmResponse = new List<Film>();
            if (response.IsSuccessStatusCode)
            {
                FilmResponse = DataSerializer.Deserialize<List<Film>>(await response.Content.ReadAsStringAsync());
            }
            return FilmResponse;
        }


        // Метод для получения списка просмотренных фильмов GET запросом
        //public async Task<List<Film>> GetWatchedList()
        //{

        //    HttpResponseMessage response = await client.GetAsync("api/v1/watched/");
        //    response.EnsureSuccessStatusCode();


        //    List<Film> FilmResponse = new List<Film>();
        //    if (response.IsSuccessStatusCode)
        //    {
        //        FilmResponse = DataSerializer.Deserialize<List<Film>>(
        //            await response.Content.ReadAsStringAsync()
        //        );
        //    }
        //    return FilmResponse;
        //}

        public async Task<List<WatchedFilm>> GetWatchedList()
        {
            HttpResponseMessage response = await client.GetAsync("api/v1/watched/");
            response.EnsureSuccessStatusCode();

            List<WatchedFilm> watchedFilms = new List<WatchedFilm>();
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                watchedFilms = DataSerializer.Deserialize<List<WatchedFilm>>(jsonResponse);
            }
            return watchedFilms;
        }

        // Метод для получения одного объекта при GET запросе
        public async Task<Film> GetFilmDetail(string path)
        {
            Film film = null;

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                film = DataSerializer.Deserialize<Film>(
                    await response.Content.ReadAsStringAsync());
            }
            return film;
        }


        // Метод для отправки Post запроса на добавление просмотренного фильма
        public async Task<bool> AddWatchedFilm(int filmId, double userRating)
        {
            var url = "api/v1/watched/";
            var data = new
            {
                film = filmId,
                user_rating = userRating
            };

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(url, content);
            return response.IsSuccessStatusCode; // Возвращает true, если запрос успешен
        }


    }
}
