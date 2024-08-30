using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmGallaryAPI
{
    public class Film2
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Rating {  get; set; }


        private const int MAX_TITLE_LENGTH = 64;

        //public void Configure(EntityTypeBuilder<Film2> builder)
        //{
        //    builder.Property(film => film.Id).IsRequired();
        //    builder.HasOne(film => film.Author_id)
        //        .WithMany(author => author.Films)
        //        .HasForeignKey(film => film.Author_id);
        //}

        
    }
}
