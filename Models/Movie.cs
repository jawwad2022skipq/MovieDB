using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        public int ID { get; set; } // ID provides the primary key value for the database
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)] // This attribute specifies the type of the data (Date)
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}