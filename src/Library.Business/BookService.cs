using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Library.Data;
using Library.Data.Entities;

namespace Library.Business
{
    public class BookService
    {
        // 1. Načtení všech knih 
        public List<Book> GetAllBooks()
        {
            using (var context = new LibraryContext())
            {
                return context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Publisher)
                    .ToList();
            }
        }

        // 2. Pomocné metody pro naplnění roletek (ComboBoxů)
        public List<Author> GetAuthors()
        {
            using (var context = new LibraryContext())
            {
                return context.Authors.ToList();
            }
        }

        public List<Genre> GetGenres()
        {
            using (var context = new LibraryContext())
            {
                return context.Genres.ToList();
            }
        }

        public List<Publisher> GetPublishers()
        {
            using (var context = new LibraryContext())
            {
                return context.Publishers.ToList();
            }
        }

        // 3. Metoda pro přidání nové knihy
        public void AddBook(string title, int year, string description, int authorId, int genreId, int publisherId)
        {
            using (var context = new LibraryContext())
            {
                var newBook = new Book
                {
                    Title = title,
                    Year = year,
                    Description = description,
                    MediaType = "Kniha", // Defaultně
                    IsDeleted = false,
                    AuthorId = authorId,
                    GenreId = genreId,
                    PublisherId = publisherId
                };

                context.Books.Add(newBook);
                context.SaveChanges();
            }
        }

        // Testovací data
        public void CreateTestData()
        {
            using (var context = new LibraryContext())
            {
                if (!context.Books.Any())
                {
                    var author = new Author { FirstName = "Karel", LastName = "Čapek" };
                    var genre = new Genre { Name = "Sci-fi" };
                    var publisher = new Publisher { Name = "Albatros" };

                    var book = new Book
                    {
                        Title = "R.U.R.",
                        Year = 1920,
                        MediaType = "Kniha",
                        Description = "Rossumovi Univerzální Roboti",
                        IsDeleted = false,
                        Author = author,
                        Genre = genre,
                        Publisher = publisher
                    };

                    context.Books.Add(book);
                    context.SaveChanges();
                }
            }
        }

        // Vyhledávání knih podle názvu nebo autora
        public List<Book> SearchBooks(string query)
        {
            using (var context = new LibraryContext())
            {
                // Převedeme na malá písmena, aby nezáleželo na velikosti
                query = query.ToLower();

                return context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Publisher)
                    .Where(b => b.Title.ToLower().Contains(query) ||
                                b.Author.LastName.ToLower().Contains(query))
                    .ToList();
            }
        }

        public void AddBookSmart(string title, int year, string description,
                         string authorFullName, string genreName, string publisherName)
        {
            using (var context = new LibraryContext())
            {
                // 1. ŘEŠENÍ AUTORA (Najdi nebo Vytvoř)
                var author = context.Authors
                    .FirstOrDefault(a => (a.FirstName + " " + a.LastName) == authorFullName ||
                                         a.LastName == authorFullName);

                if (author == null)
                {
                    // Autor neexistuje, musíme ho vytvořit
                    // Zkusíme rozdělit jméno na Křestní a Příjmení podle mezery
                    var parts = authorFullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string firstName = "";
                    string lastName = authorFullName;

                    if (parts.Length > 1)
                    {
                        lastName = parts[parts.Length - 1]; // Poslední slovo je příjmení
                        firstName = string.Join(" ", parts, 0, parts.Length - 1); // Zbytek je jméno
                    }

                    author = new Author { FirstName = firstName, LastName = lastName };
                    context.Authors.Add(author);
                }

                // 2. ŘEŠENÍ ŽÁNRU
                var genre = context.Genres.FirstOrDefault(g => g.Name == genreName);
                if (genre == null)
                {
                    genre = new Genre { Name = genreName };
                    context.Genres.Add(genre);
                }

                // 3. ŘEŠENÍ VYDAVATELE
                var publisher = context.Publishers.FirstOrDefault(p => p.Name == publisherName);
                if (publisher == null)
                {
                    publisher = new Publisher { Name = publisherName };
                    context.Publishers.Add(publisher);
                }

                // Protože jsme mohli přidat nové entity, musíme uložit změny, aby dostaly ID
                context.SaveChanges();

                // 4. ULOŽENÍ KNIHY
                var newBook = new Book
                {
                    Title = title,
                    Year = year,
                    Description = description,
                    MediaType = "Kniha",
                    IsDeleted = false,
                    AuthorId = author.Id,       // Teď už má ID (staré nebo nové)
                    GenreId = genre.Id,
                    PublisherId = publisher.Id
                };

                context.Books.Add(newBook);
                context.SaveChanges();
            }
        }

        public void DeleteBook(int bookId)
        {
            using (var context = new LibraryContext())
            {
                var book = context.Books.Find(bookId);
                if (book != null)
                {
                    // Zkusíme ji natvrdo odstranit
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
            }
        }
    }
}