namespace FilmGalary.Core.Entity
{
    public class Film(int id = 0, string title="Some film")
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        //public double Rating { get; set; } = 0.0;
        //public int Year_release { get; set; } = 0000;
        //public FilmType Type { get; set; } = FilmType.No_data;
        //public List<Genre> Genre { get; set; } = new List<Genre>();
        //public Director Director { get; set; } = new Director();
        //public Country Country { get; set; } = new Country();
        //public bool Is_watched { get; set; } = false;
        //public bool In_watched_plan { get; set; } = false;
        //public List<Actor> Main_actors { get; set; } = new List<Actor>();

        public override string ToString()
        {
            return Title;
        }

    }

    public enum FilmType
    {
        Series,
        Cinema,
        Cartoon,
        Animated_series,
        No_data,
    }

    public enum Genre
    {
        Horror,
        Action,
        Comedy,
    }
}

