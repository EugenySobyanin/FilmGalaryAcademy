using FilmGalary.Core.Data;
using FilmGalary.Core.Entity;
using FilmGalary.Core.Service;

Film film = new Film();
film.Title = "Пираты карибского моря.";
Film film2 = new Film();
film2.Title = "Пираты карибского моря - 2.";
Film film3 = new Film();
film3.Title = "Пираты карибского моря - 3.";


Actor actor1 = new Actor("Джони Депп");
Actor actor2 = new Actor("Джон Траволта");


Country country1 = new Country();
country1.Title = "Великобритания";
Country country2 = new Country();
country1.Title = "Россия";
//Console.WriteLine(film.ToString());

//string path = ".\\FilmGalary_Integration.json";

//string text = "qwerty";

//File.WriteAllText(path, text);

//Console.WriteLine(File.ReadAllText(path));


//FilmGalaryDataSource filmGalaryDataSource = new FilmGalaryDataSource();
//filmGalaryDataSource.Write(new List<Film> { film, film2, film3 });
//Console.WriteLine(string.Join("\n", filmGalaryDataSource.Get()));


//ActorDataSource actorDataSource = new ActorDataSource();
//actorDataSource.Write(new List<Actor> { actor1, actor2 });
//Console.WriteLine(string.Join("\n", actorDataSource.Get()));

//CountryDataSource countryDataSource = new CountryDataSource();
//countryDataSource.Write(new List<Country> { country1, country2 });
//Console.WriteLine(string.Join("\n", countryDataSource.Get()));


//FilmService dataService = new FilmService(new FilmGalaryDataSource());


// Проверка операций CRUD для модели Film


