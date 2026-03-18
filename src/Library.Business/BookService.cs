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
        // Načtení všech aktivních knih z databáze
        public List<Book> GetAllBooks()
        {
            using (var context = new LibraryContext())
            {
                return context.Books
                    .Include(b => b.Author)   // Propojení s tabulkou autorů (Eager Loading)
                    .Include(b => b.Genre)    // Propojení s tabulkou žánrů
                    .Include(b => b.Publisher) // Propojení s tabulkou vydavatelů
                    .Where(b => b.IsDeleted == false) // Filtrování: pouze knihy, které nejsou v Bazaru
                    .ToList();
            }
        }

        // Vyhledávání v knihách podle textového řetězce
        public List<Book> SearchBooks(string query)
        {
            using (var context = new LibraryContext())
            {
                query = query.ToLower(); // Převod na malá písmena pro case-insensitive hledání
                return context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Publisher)
                    .Where(b => b.IsDeleted == false && (
                        b.Title.ToLower().Contains(query) || // Hledání v názvu
                        b.Author.LastName.ToLower().Contains(query) || // Hledání v příjmení autora
                        b.Genre.Name.ToLower().Contains(query) || // Hledání v názvu žánru
                        b.Publisher.Name.ToLower().Contains(query) || // Hledání ve vydavateli
                        b.Year.ToString().Contains(query) // Hledání v roce vydání
                    )).ToList();
            }
        }

        // Trvalé odstranění knihy z databáze podle ID
        public void DeleteBook(int bookId)
        {
            using (var context = new LibraryContext())
            {
                var book = context.Books.Find(bookId); // Vyhledání konkrétního záznamu
                if (book != null)
                {
                    context.Books.Remove(book); // Příkaz ke smazání
                    context.SaveChanges(); // Potvrzení změn v SQL databázi
                }
            }
        }

        // --- FUNKCE PRO BAZAR A VYŘAZOVÁNÍ (POŽADAVEK FÁZE 2) ---

        // Logické vyřazení knihy a nastavení prodejní ceny
        public void DiscardBook(int bookId, decimal salePrice)
        {
            using (var context = new LibraryContext())
            {
                var book = context.Books.Find(bookId);
                if (book != null)
                {
                    // Kontrola integrity: nelze vyřadit knihu, která má aktivní výpůjčku
                    bool isLent = context.Loans.Any(l => l.BookId == bookId && l.ReturnDate == null);
                    if (isLent)
                        throw new Exception("Nelze vyřadit knihu, která je aktuálně vypůjčená!");

                    book.IsDeleted = true; // "Soft delete" - kniha zůstává v DB, ale je označena jako vyřazená
                    book.SalePrice = salePrice; // Nastavení snížené ceny pro odkup čtenářem
                    context.SaveChanges();
                }
            }
        }

        // Načtení seznamu knih určených výhradně pro záložku Bazar
        public List<Book> GetDiscardedBooks()
        {
            using (var context = new LibraryContext())
            {
                return context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Publisher)
                    .Where(b => b.IsDeleted == true) // Filtrování: pouze vyřazené kusy
                    .ToList();
            }
        }

        // Realizace prodeje vyřazené knihy
        public void BuyDiscardedBook(int bookId)
        {
            using (var context = new LibraryContext())
            {
                var book = context.Books.Find(bookId);
                if (book != null && book.IsDeleted)
                {
                    // Po prodeji se záznam z databáze odstraní definitivně
                    context.Books.Remove(book);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Tuto knihu nelze zakoupit (není vyřazená).");
                }
            }
        }

        // --- POMOCNÉ METODY PRO UI (PLNĚNÍ COMBOBOXŮ) ---

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

        // --- INTELIGENTNÍ PŘIDÁVÁNÍ KNIH (SMART ADD) ---
        // Metoda automaticky spravuje vazby mezi entitami, aby nedocházelo k duplicitám
        public void AddBookSmart(string title, int year, string description, string authorName, string genreName, string publisherName, string mediaType = "Kniha")
        {
            using (var context = new LibraryContext())
            {
                // Parsování jména: rozdělení celého jména na jméno a příjmení podle první mezery
                string firstName = "";
                string lastName = authorName;

                if (!string.IsNullOrWhiteSpace(authorName) && authorName.Contains(" "))
                {
                    var parts = authorName.Split(new[] { ' ' }, 2);
                    firstName = parts[0].Trim();
                    lastName = parts[1].Trim();
                }

                // Kontrola existence autora: pokud v DB není, vytvoří se nový
                var author = context.Authors.FirstOrDefault(a => a.FirstName == firstName && a.LastName == lastName);
                if (author == null)
                {
                    author = new Author { FirstName = firstName, LastName = lastName };
                    context.Authors.Add(author);
                }

                // Kontrola existence žánru: zabraňuje duplicitním názvům žánrů
                var genre = context.Genres.FirstOrDefault(g => g.Name == genreName);
                if (genre == null)
                {
                    genre = new Genre { Name = genreName };
                    context.Genres.Add(genre);
                }

                // Kontrola existence vydavatele
                var publisher = context.Publishers.FirstOrDefault(p => p.Name == publisherName);
                if (publisher == null)
                {
                    publisher = new Publisher { Name = publisherName };
                    context.Publishers.Add(publisher);
                }

                // Sestavení finálního objektu knihy s vazbami na zkontrolované entity
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
                context.SaveChanges(); // Transakční uložení všech změn naráz
            }
        }
    }
}