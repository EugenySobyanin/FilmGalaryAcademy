namespace FilmGalary.Core
{
    public class Film
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = "";
        public double Rating { get; set; } = 0.0;
        public int Year_release { get; set; } = 0000;
        public FilmType Type { get; set; };
        //public Genre Genre { get; set; }
        public Director Director { get; set; } = new Director();
        public Country Country { get; set; } = new Country();
        public bool Is_watched { get; set; } = false;
        public bool In_watched_plan { get; set; } = false;
        public List<Actor> Main_actors { get; set; } = new List<Actor>();

        public override string ToString()
        {
            return Title;
        }

    }

    public enum FilmType
    {
        Series,
        Cinema,
    }

    public enum Genre
    {
        Horror,
        Action,
    }
}

