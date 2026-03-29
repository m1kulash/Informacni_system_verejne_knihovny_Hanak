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
        // Načtení všech knih, které nejsou smazané (v Bazaru)
        public List<Book> GetAllBooks()
        {
            using (var context = new LibraryContext())
            {
                // .Include zajišťuje tzv. Eager Loading - načte data z propojených tabulek najednou
                return context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Publisher)
                    .Where(b => b.IsDeleted == false)
                    .ToList();
            }
        }

        // Vyhledávání napříč všemi parametry knihy (case-insensitive)
        public List<Book> SearchBooks(string query)
        {
            using (var context = new LibraryContext())
            {
                query = query.ToLower();
                return context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Publisher)
                    .Where(b => b.IsDeleted == false && (
                        b.Title.ToLower().Contains(query) ||
                        b.Author.LastName.ToLower().Contains(query) ||
                        b.Genre.Name.ToLower().Contains(query) ||
                        b.Publisher.Name.ToLower().Contains(query) ||
                        b.Year.ToString().Contains(query)
                    )).ToList();
            }
        }

        // Fyzické smazání knihy z databáze
        public void DeleteBook(int bookId)
        {
            using (var context = new LibraryContext())
            {
                var book = context.Books.Find(bookId);
                if (book != null)
                {
                    context.Books.Remove(book);
                    context.SaveChanges(); // Propsání změn do SQL serveru
                }
            }
        }

        // Přesun knihy do bazaru (tzv. Soft Delete)
        public void DiscardBook(int bookId, decimal salePrice)
        {
            using (var context = new LibraryContext())
            {
                var book = context.Books.Find(bookId);
                if (book != null)
                {
                    // Validace: Nelze vyřadit knihu, kterou má někdo zrovna doma
                    bool isLent = context.Loans.Any(l => l.BookId == bookId && l.ReturnDate == null);
                    if (isLent)
                        throw new Exception("Nelze vyřadit knihu, která je aktuálně vypůjčená!");

                    book.IsDeleted = true; // Kniha v DB zůstane, ale změní se její stav
                    book.SalePrice = salePrice; // Nastavení ceny pro výprodej
                    context.SaveChanges();
                }
            }
        }

        // Načtení pouze knih označených jako vyřazené
        public List<Book> GetDiscardedBooks()
        {
            using (var context = new LibraryContext())
            {
                return context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Publisher)
                    .Where(b => b.IsDeleted == true)
                    .ToList();
            }
        }

        // Odstranění knihy po jejím úspěšném prodeji v Bazaru
        public void BuyDiscardedBook(int bookId)
        {
            using (var context = new LibraryContext())
            {
                var book = context.Books.Find(bookId);
                if (book != null && book.IsDeleted)
                {
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Tuto knihu nelze zakoupit (není v bazaru).");
                }
            }
        }

        // Pomocné metody pro naplnění ComboBoxů (výběrových polí) v UI
        public List<Author> GetAuthors()
        {
            using (var context = new LibraryContext()) { return context.Authors.ToList(); }
        }

        public List<Genre> GetGenres()
        {
            using (var context = new LibraryContext()) { return context.Genres.ToList(); }
        }

        public List<Publisher> GetPublishers()
        {
            using (var context = new LibraryContext()) { return context.Publishers.ToList(); }
        }

        // Inteligentní přidání knihy s kontrolou existujících autorů/žánrů
        public void AddBookSmart(string title, int year, string description, string authorName, string genreName, string publisherName, string mediaType = "Kniha")
        {
            using (var context = new LibraryContext())
            {
                // Rozdělení jména autora pro vyhledávání (např. "Karel Čapek")
                string firstName = "";
                string lastName = authorName;

                if (!string.IsNullOrWhiteSpace(authorName) && authorName.Contains(" "))
                {
                    var parts = authorName.Split(new[] { ' ' }, 2);
                    firstName = parts[0].Trim();
                    lastName = parts[1].Trim();
                }

                // Kontrola, zda autor už v DB není - pokud ne, založíme ho
                var author = context.Authors.FirstOrDefault(a => a.FirstName == firstName && a.LastName == lastName);
                if (author == null)
                {
                    author = new Author { FirstName = firstName, LastName = lastName };
                    context.Authors.Add(author);
                }

                // Stejná kontrola pro žánr (zabraňuje duplicitám)
                var genre = context.Genres.FirstOrDefault(g => g.Name == genreName);
                if (genre == null)
                {
                    genre = new Genre { Name = genreName };
                    context.Genres.Add(genre);
                }

                // Kontrola pro vydavatele
                var publisher = context.Publishers.FirstOrDefault(p => p.Name == publisherName);
                if (publisher == null)
                {
                    publisher = new Publisher { Name = publisherName };
                    context.Publishers.Add(publisher);
                }

                // Vytvoření nové knihy s vazbami na entity
                var book = new Book
                {
                    Title = title,
                    Year = year,
                    Description = description,
                    MediaType = mediaType,
                    IsDeleted = false,
                    Author = author,
                    Genre = genre,
                    Publisher = publisher
                };

                context.Books.Add(book);
                context.SaveChanges(); // Uložení knihy i případných nových entit naráz
            }
        }

        // Automatické naplnění (Seeding) databáze ukázkovými daty
        public void SeedBooks()
        {
            using (var context = new Library.Data.LibraryContext())
            {
                var titles = new[] { "Zaklínač I. - Poslední přání", "Zaklínač II. - Meč osudu" };

                // Příprava entit, které budeme ke knihám připojovat
                var author = context.Authors.FirstOrDefault(a => a.LastName == "Sapkowski")
                             ?? new Library.Data.Entities.Author { FirstName = "Andrzej", LastName = "Sapkowski" };

                var genre = context.Genres.FirstOrDefault(g => g.Name == "Fantasy")
                            ?? new Library.Data.Entities.Genre { Name = "Fantasy" };

                var pub = context.Publishers.FirstOrDefault(p => p.Name == "Leonardo")
                          ?? new Library.Data.Entities.Publisher { Name = "Leonardo" };

                // Přidání knih pouze v případě, že v DB ještě nejsou
                foreach (var title in titles)
                {
                    if (!context.Books.Any(b => b.Title == title))
                    {
                        context.Books.Add(new Library.Data.Entities.Book
                        {
                            Title = title,
                            Year = 1993,
                            Author = author,
                            Genre = genre,
                            Publisher = pub,
                            IsInterlibrary = false,
                            Description = "Testovací záznam."
                        });
                    }
                }
                context.SaveChanges();
            }
        }
    }
}