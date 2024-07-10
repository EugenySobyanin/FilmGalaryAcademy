using FilmGalary.Core;
using FilmGalary.Core.Entity;

public class FilmGalaryDataSource
{
    private readonly string path = ".\\data.json";

    public List<Film> Get()
    {
        if (File.Exists(path))
        {
            string data = File.ReadAllText(path);
            return DataSerializer.Deserialize<List<Film>>(data);
        }

        return null;
    }

    public void Write(List<Film> data)
    {
        File.WriteAllText(path, DataSerializer.Serialize(data));
    }
}





