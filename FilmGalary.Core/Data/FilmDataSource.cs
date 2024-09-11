using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmGalary.Core.Utils;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using FilmGalary.Core.Entity;

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
        public async Task<List<Film>> GetFilmListWithSearch()
        {

            HttpResponseMessage response = await client.GetAsync(
                "api/v1/films/");
            response.EnsureSuccessStatusCode();

            List<Film> FilmResponse = new List<Film>();
            if (response.IsSuccessStatusCode)
            {
                FilmResponse = DataSerializer.Deserialize<List<Film>>(await response.Content.ReadAsStringAsync());
            }
            return FilmResponse;
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


        


        // Метод для получения списка просмотренных фильмов GET запросом
        public async Task<List<Film>> GetWatchedList()
        {

            HttpResponseMessage response = await client.GetAsync(
                "api/v1/watched/");
            response.EnsureSuccessStatusCode();

            List<Film> FilmResponse = new List<Film>();
            if (response.IsSuccessStatusCode)
            {
                FilmResponse = DataSerializer.Deserialize<List<Film>>(
                    await response.Content.ReadAsStringAsync()
                );
            }
            return FilmResponse;
        }

    }
}
