using Newtonsoft.Json;


namespace FilmGalary.Core.Entity
{
    public class Film
    {   
        public static int _id_counter = 0;
        
        // конструктор
        public Film(string title = "Без названия", double rating=0.0, int year=0, double user_rating=0.0, bool isWatched=true, bool isPlan=false)
        {
            Id = _id_counter++;
            Title = title;
            Rating_kp = rating;
            Release_year = year;
            UserRating = user_rating;
            IsWatched = isWatched;
            InPlan = isPlan;
        }

        // свойства
        [JsonProperty("ItemId")]
        public int Id { get; set; }
        public string Title { get; set; }
        public double Rating_kp { get; set; } = 0.0;
        public double Rating_imdb { get; set; } = 0.0;
        public int Release_year { get; set; } = 0000;
        public double UserRating { get; set; } = 0.0;


        //public FilmType Type { get; set; } = FilmType.No_data;
        //public List<Genre> Genre { get; set; } = new List<Genre>();
        //public Director Director { get; set; } = new Director();
        //public Country Country { get; set; } = new Country();
        public bool IsWatched { get; set; } = false;
        public bool InPlan { get; set; } = false;
        //public List<Actor> Main_actors { get; set; } = new List<Actor>();


        public override string ToString()
        {
            return Title;
        }

    }

    //public enum FilmType
    //{
    //    Series,
    //    Cinema,
    //    Cartoon,
    //    Animated_series,
    //    No_data,
    //}

    //public enum Genre
    //{
    //    Horror,
    //    Action,
    //    Comedy,
    //}
}

