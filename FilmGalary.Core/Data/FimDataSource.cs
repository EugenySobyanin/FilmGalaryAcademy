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

        public async Task<Film> GetFilmAsync(string path)
        {
            Film film = null;

            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                cinema = DataSerializer.Deserialize<Cinema>(
                    await response.Content.ReadAsStringAsync());
            }
            return cinema;
        }

    }
}
