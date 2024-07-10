using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmGalary.Core.Entity;

namespace FilmGalary.Core.Data
{
    public class ActorDataSource
    {
        private readonly string path = ".\\actor_data.json";

        public List<Actor> Get()
        {
            if (File.Exists(path))
            {
                string data = File.ReadAllText(path);
                return DataSerializer.Deserialize<List<Actor>>(data);
            }

            return null;
        }

        public void Write(List<Actor> data)
        {
            File.WriteAllText(path, DataSerializer.Serialize(data));
        }
    }
}
