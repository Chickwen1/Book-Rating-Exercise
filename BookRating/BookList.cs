using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRating
{
    public class BookList
    {
        private List<Book> books;
        private List<Book> allBooks;

        public BookList()
        {
            allBooks = new List<Book>();
        }

        public void AddBook(Book books)
        {
            allBooks.Add(books);
        }

        public int NumberBooks()
        {
            return allBooks.Count();
        }

        public void RemoveBook(int year)
        {
            List<Book> removeList = new List<Book>(); //list to hold search results
            foreach (Book b in allBooks)
            {
                if (b.Year == year) //we have a hit!
                {
                    //allBooks.Remove(b);
                    removeList.Add(b); //add search result to the list
                }
            }
            allBooks = allBooks.Except(removeList).ToList();
        }

        public void RemoveLastAdded()
        {
            allBooks.RemoveAt(allBooks.Count - 1);
        }

        public Book OldestBook()
        {
            Book oldestBook = allBooks[0];
            foreach (Book b in allBooks)
            {
                if (b.Year < oldestBook.Year)
                    oldestBook = b;
            }
            return oldestBook;
        }

        public Book YoungestBook()
        {
            Book youngestBook = allBooks[0];
            foreach (Book b in allBooks)
            {
                if (b.Year > youngestBook.Year)
                    youngestBook = b;
            }
            return youngestBook;
        }

        public bool ContainsBook(Book book)
        {
            return allBooks.Contains(book);
        }

        public double AverageRating()
        {
            double result = -1;
            double sum = 0;
            foreach (Book b in allBooks)
            {
                sum += b.Rating;
            }
            result = sum / allBooks.Count;
            return result;
        }

        public double AverageRatingByAuthor(Book book)
        {
            double result = -1;
            double sum = 0;
            string searchName = book.Author;
            bool found = false;
            int numberOfBooks = 0;
            foreach (Book b in allBooks)
            {
                if (b.Author.Equals(book.Author))
                {
                    found = true;
                    sum += b.Rating;
                    numberOfBooks += 1;
                }
                result = sum / numberOfBooks;
            }
            return result;
        }
    }
}
