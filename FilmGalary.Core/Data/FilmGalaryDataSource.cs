using FilmGalary.Core.Entity;
using FilmGalary.Core.Utils;


public class FilmGalaryDataSource
{
    private readonly string path = ".\\film_data.json";

    public List<Film> Get()
        // Возвращает список объектов Film из файла json (десериализация)
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
        // Записывает в файл данные из списка. (сериализация)
        File.WriteAllText(path, DataSerializer.Serialize(data));
    }
}





