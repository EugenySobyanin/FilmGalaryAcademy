using FilmGalary.Core.Data;
using FilmGalary.Core.Entity;
using FilmGalary.Core.Service;

// Создаем экземпляр класса FilmService
FilmService dataService = new FilmService(new FilmGalaryDataSource());


// Проверка операций CRUD для модели Film

// Получение всех фильмов (из пустого файла)
Console.WriteLine(string.Join(", ", dataService.GetAll()));

// Добавление 3 фильмов по одному
Console.WriteLine("Добавляем 3 фильма.");
dataService.Create(new Film(0, "Аватар"));
dataService.Create(new Film(1, "Кинг-конг"));
dataService.Create(new Film(2, "Трон"));
Console.WriteLine(string.Join(", ", dataService.GetAll()));

// Получаем фильм по id
Console.WriteLine("Получаем фильм по id");
Console.WriteLine(dataService.Get(2));

// Редактируем фильм по id
Console.WriteLine("Редактируем фильм");
dataService.Update(new Film(1, "Мстители"));
Console.WriteLine(string.Join(", ", dataService.GetAll()));

// Удаляем фильм по id
dataService.Delete(2);
Console.WriteLine(string.Join(", ", dataService.GetAll()));





