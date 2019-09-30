using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRating
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public double Rating { get; set; }

        public Book(string title, string author, int year, double rating)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.Rating = rating;
        }
    }
}
