using Newtonsoft.Json;
using System;


namespace FilmGalary.Core.Entity
{
    public class Film
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public double Rating_kp { get; set; }
        public double Rating_imdb { get; set; }
        public int Release_year { get; set; }
        public string Type { get; set; }
        public double UserRating { get; set; }

        public List<string> Country { get; set; }
        public List<Genre> Genre { get; set; }
        public List<Person> Person { get; set; }


        // От них нужно избавиться!
        public bool IsWatched { get; set; } = false;
        public bool InPlan { get; set; } = false;


        public override string ToString()
        {
            return Title;
        }

    }


    public class Genre
    {
        public string Name { get; set; }
    }

    public class Person
    {
        public string Name { get; set; }
    }

    public class WatchedFilm
    {
        public Film Film { get; set; } // Объект FilmDetails
        public double UserRating { get; set; }
    }
}

