using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmGalary.Core.Entity;

namespace FilmGalary.Core.Data
{
    public class CountryDataSource
    {
        private readonly string path = ".\\country_data.json";

        public List<Country> Get()
        {
            if (File.Exists(path))
            {
                string data = File.ReadAllText(path);
                return DataSerializer.Deserialize<List<Country>>(data);
            }

            return null;
        }

        public void Write(List<Country> data)
        {
            File.WriteAllText(path, DataSerializer.Serialize(data));
        }
    }
}

