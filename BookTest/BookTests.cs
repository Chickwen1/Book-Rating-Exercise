using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRating.Tests
{
    [TestClass()]
    public class BookTests
    {
        Book b1;
        Book b2;
        Book b3;
        Book b4;
        Book b5;
        Book b6;
        Book b7;
        Book b8;
        Book b9;
        Book b10;
        BookList books;

        [TestInitialize]
        public void SetUp()
        {

            b1 = new Book("A Tale Of Two Cities", "Charles Dickens", 1859, 3.76);
            b2 = new Book("The Great Gatsby", "F. Scott Fitzgerald", 1925, 3.85);
            b3 = new Book("Pride and Prejudice", "Jane Austen", 1813, 4.23);
            b4 = new Book("To Kill A Mockingbird", "Harper Lee", 1960, 4.23);
            b5 = new Book("Jane Eyre", "Charlotte Bronte", 1847, 4.07);
            b6 = new Book("The Catcher and the Rye", "J.D. Salinger", 1951, 3.77);
            b7 = new Book("Sense and Sensibility", "Jane Austen", 1811, 4.04);
            b8 = new Book("Emma", "Jane Austen", 1815, 3.97);
            b9 = new Book("1984", "George Orwell", 1949, 4.09);
            b10 = new Book("Oliver Twist", "Charles Dickens", 1838, 3.82);

            books = new BookList();
            books.AddBook(b1);
            books.AddBook(b2);
            books.AddBook(b3);
            books.AddBook(b4);
            books.AddBook(b5);
            books.AddBook(b6);
            books.AddBook(b7);
            books.AddBook(b8);
            books.AddBook(b9);
            books.AddBook(b10);

        }

        [TestMethod]
        public void TestBooksAdded()
        {
            Assert.AreEqual(10, books.NumberBooks());

            //add new book to make sure NumberBooks() works
            Book b11 = new Book("Twilight", "Stephanie Myers", 2005, 3.57);
            books.AddBook(b11);
            Assert.AreEqual(11, books.NumberBooks());
        }

        [TestMethod]
        public void RemoveBookByYear()
        {
            books.RemoveBook(1815);
            Assert.AreEqual(9, books.NumberBooks());
        }

        [TestMethod]
        public void TestRemoveLastAdd()
        {
            books.RemoveLastAdded();
            Assert.IsFalse(books.ContainsBook(b10));
        }

        [TestMethod]
        public void TestOldestBook()
        {
            Assert.AreSame(b7, books.OldestBook());

            //add new oldest book
            Book b11 = new Book("Gulliver's Travels", "Johnathan Swift", 1726, 4.01);
            books.AddBook(b11);
            Assert.AreSame(b11, books.OldestBook());
        }

        [TestMethod]
        public void TestYoungestBook()
        {
            Assert.AreSame(b4, books.YoungestBook());

            //add new youngest book
            Book b11 = new Book("Twilight", "Stephanie Myers", 2005, 3.57);
            books.AddBook(b11);
            Assert.AreSame(b11, books.YoungestBook());
        }

        [TestMethod]
        public void TestAverageRating()
        {
            Assert.AreEqual(3.98, books.AverageRating(), .003);
        }

        [TestMethod]
        public void TestAverageRatingByAuthor()
        {
            Assert.AreEqual(4.23, books.AverageRatingByAuthor(b4), .003);
            //authors with multiple ratings
            Assert.AreEqual(3.79, books.AverageRatingByAuthor(b1), .003);
            //added another book by Charles Dickens to see if it adds correctly
            Book b11 = new Book("A CHristmas Carol", "Charles Dickens", 1843, 4.00);
            books.AddBook(b11);
            Assert.AreEqual(3.86, books.AverageRatingByAuthor(b1), .003);
        }
    }
}