using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Library.Data;
using Library.Data.Entities;

namespace Library.Business
{
    public class LoanService
    {
        // Načtení seznamu všech aktivních výpůjček (knihy, které jsou momentálně venku)
        public List<Loan> GetActiveLoans()
        {
            using (var context = new LibraryContext())
            {
                // Filtrujeme záznamy, kde chybí datum vrácení
                return context.Loans
                    .Where(l => l.ReturnDate == null)
                    .Include(l => l.Reader) // Načtení dat o čtenáři
                    .Include(l => l.Book)   // Načtení dat o knize
                    .ToList();
            }
        }

        // Metoda pro vytvoření nové výpůjčky
        public void BorrowBook(int readerId, int bookId)
        {
            using (var context = new LibraryContext())
            {
                // Validace: Kontrola dostupnosti knihy (zda ji už někdo nemá)
                bool isBorrowed = context.Loans.Any(l => l.BookId == bookId && l.ReturnDate == null);
                if (isBorrowed)
                {
                    throw new Exception("Tuto knihu nelze půjčit, protože ji má momentálně jiný čtenář.");
                }

                // Vytvoření záznamu s termínem vrácení 31 dní od dnešního data
                var loan = new Loan
                {
                    ReaderId = readerId,
                    BookId = bookId,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(31), // Standardní výpůjční lhůta
                    ReturnDate = null,
                    FineAmount = 0
                };

                context.Loans.Add(loan);
                context.SaveChanges(); // Uložení nové výpůjčky do databáze
            }
        }

        // --- KLÍČOVÁ FUNKCE: VRÁCENÍ KNIHY A VÝPOČET POKUTY ---
        public decimal ReturnBook(int loanId)
        {
            using (var context = new Library.Data.LibraryContext())
            {
                // Najdeme konkrétní výpůjčku podle jejího ID
                var loan = context.Loans.Include(l => l.Book).FirstOrDefault(l => l.Id == loanId);
                if (loan == null) throw new Exception("Výpůjčka nebyla nalezena.");

                // Nastavíme aktuální čas jako okamžik vrácení
                loan.ReturnDate = DateTime.Now;

                // Logika pro výpočet pokuty: 5 Kč za každý den po termínu (DueDate)
                decimal fine = 0;
                if (loan.ReturnDate > loan.DueDate)
                {
                    int daysLate = (loan.ReturnDate.Value - loan.DueDate).Days;
                    fine = daysLate * 5; // Sazba pokuty
                    loan.FineAmount = fine; // Zápis výše pokuty do záznamu
                }

                context.SaveChanges(); // Uložení změn (uzavření výpůjčky)
                return fine; // Vracíme hodnotu pro zobrazení obsluze
            }
        }

        // Načtení historie všech ukončených výpůjček (pro přehledy)
        public List<Loan> GetLoanHistory()
        {
            using (var context = new LibraryContext())
            {
                return context.Loans
                    .Where(l => l.ReturnDate != null) // Pouze ty, co už jsou vráceny
                    .Include(l => l.Reader)
                    .Include(l => l.Book)
                    .OrderByDescending(l => l.ReturnDate) // Nejnovější vrácené nahoře
                    .ToList();
            }
        }

        // Pomocná metoda pro naplnění historie testovacími daty (bez duplicit)
        public void SeedLoansAndHistory()
        {
            using (var context = new Library.Data.LibraryContext())
            {
                var book = context.Books.FirstOrDefault();
                var reader = context.Readers.FirstOrDefault();

                if (book != null && reader != null)
                {
                    // Používáme fixní datum k identifikaci testovacího záznamu
                    DateTime staticDate = new DateTime(2024, 1, 1);

                    // Kontrola, zda už v systému tento testovací záznam existuje
                    bool exists = context.Loans.Any(l => l.BookId == book.Id && l.ReaderId == reader.Id && l.LoanDate == staticDate);

                    if (!exists)
                    {
                        context.Loans.Add(new Library.Data.Entities.Loan
                        {
                            BookId = book.Id,
                            ReaderId = reader.Id,
                            LoanDate = staticDate,
                            DueDate = staticDate.AddDays(31),
                            ReturnDate = staticDate.AddDays(10), // Simulace úspěšného vrácení
                            FineAmount = 0
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}