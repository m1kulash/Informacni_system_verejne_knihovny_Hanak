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
        // Načtení seznamu všech aktuálně probíhajících výpůjček
        public List<Loan> GetActiveLoans()
        {
            using (var context = new LibraryContext())
            {
                // Filtrování záznamů, které nemají vyplněné datum vrácení (ReturnDate je null)
                // Include zajišťuje načtení souvisejících dat o čtenáři a knize pro zobrazení v UI
                return context.Loans
                    .Where(l => l.ReturnDate == null)
                    .Include(l => l.Reader)
                    .Include(l => l.Book)
                    .ToList();
            }
        }

        // Realizace nové výpůjčky knihy čtenáři
        public void BorrowBook(int readerId, int bookId)
        {
            using (var context = new LibraryContext())
            {
                // Validace dostupnosti: kontrola, zda kniha již není půjčená jinému čtenáři
                bool isBorrowed = context.Loans.Any(l => l.BookId == bookId && l.ReturnDate == null);
                if (isBorrowed)
                {
                    throw new Exception("Tato kniha je již půjčená!");
                }

                // Vytvoření nového záznamu o výpůjčce s nastavením termínů
                var loan = new Loan
                {
                    ReaderId = readerId,
                    BookId = bookId,
                    LoanDate = DateTime.Now, // Aktuální čas zapůjčení
                    DueDate = DateTime.Now.AddDays(31), // Termín vrácení nastaven na 31 dní (standardní měsíc)
                    ReturnDate = null,
                    FineAmount = 0 // Inicializace pokuty na nulu
                };

                context.Loans.Add(loan);
                context.SaveChanges();
            }
        }

        // --- KLÍČOVÁ FUNKCE: VRÁCENÍ KNIHY A KONTROLA POŽADAVKŮ FÁZE 2 ---
        public decimal ReturnBook(int loanId)
        {
            using (var context = new Library.Data.LibraryContext())
            {
                var loan = context.Loans.Include(l => l.Book).FirstOrDefault(l => l.Id == loanId);
                if (loan == null) return 0;

                loan.ReturnDate = DateTime.Now; // Nastavení reálného data vrácení

                // Automatický výpočet pokuty při překročení termínu (DueDate)
                decimal fine = 0;
                if (loan.ReturnDate > loan.DueDate)
                {
                    // Výpočet rozdílu ve dnech
                    int daysLate = (loan.ReturnDate.Value - loan.DueDate).Days;
                    fine = daysLate * 5; // Sazba: 5 Kč za každý den zpoždění
                    loan.FineAmount = fine; // Uložení pokuty do historie výpůjčky
                }

                context.SaveChanges();

                // KONTROLA FRONTY (POŽADAVEK FÁZE 2): Ověření rezervací na vrácenou knihu
                var nextInQueue = context.Reservations
                    .Include(r => r.Reader)
                    .Where(r => r.BookId == loan.BookId)
                    .OrderBy(r => r.ReservationDate) // Řazení od nejstarší rezervace (kdo přišel dřív)
                    .FirstOrDefault();

                if (nextInQueue != null)
                {
                    // Pokud ve frontě někdo čeká, vyvolá se výjimka, která informuje obsluhu v hlavním okně
                    throw new Exception($"Kniha vrácena. POZOR: Na knihu čeká v pořadí čtenář: {nextInQueue.Reader.FirstName} {nextInQueue.Reader.LastName}!");
                }

                return fine; // Vrací výši pokuty pro zobrazení v MessageBoxu
            }
        }

        // Načtení historie všech ukončených výpůjček
        public List<Loan> GetLoanHistory()
        {
            using (var context = new LibraryContext())
            {
                // Výběr záznamů, které již byly vráceny (ReturnDate není null)
                // Seřazeno sestupně podle data vrácení (nejnovější nahoře)
                return context.Loans
                    .Where(l => l.ReturnDate != null)
                    .Include(l => l.Reader)
                    .Include(l => l.Book)
                    .OrderByDescending(l => l.ReturnDate)
                    .ToList();
            }
        }
    }
}