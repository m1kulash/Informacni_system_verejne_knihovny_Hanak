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
        // 1. Získat seznam všech AKTUÁLNÍCH výpůjček (ty, co ještě nebyly vráceny)
        public List<Loan> GetActiveLoans()
        {
            using (var context = new LibraryContext())
            {
                // Načteme výpůjčky, kde ReturnDate je null (nevráceno)
                // A načteme k tomu jméno čtenáře a název knihy (.Include)
                return context.Loans
                    .Where(l => l.ReturnDate == null)
                    .Include(l => l.Reader)
                    .Include(l => l.Book)
                    .ToList();
            }
        }

        // 2. Půjčit knihu
        public void BorrowBook(int readerId, int bookId)
        {
            using (var context = new LibraryContext())
            {
                // Kontrola: Je kniha vůbec dostupná? (Není už půjčená?)
                bool isBorrowed = context.Loans.Any(l => l.BookId == bookId && l.ReturnDate == null);
                if (isBorrowed)
                {
                    throw new Exception("Tato kniha je již půjčená!");
                }

                var loan = new Loan
                {
                    ReaderId = readerId,
                    BookId = bookId,
                    LoanDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(31), // Půjčujeme na měsíc
                    ReturnDate = null,
                    FineAmount = 0
                };

                context.Loans.Add(loan);
                context.SaveChanges();
            }
        }

        // 3. Vrátit knihu (s výpočtem pokuty)
        public decimal ReturnBook(int loanId)
        {
            using (var context = new LibraryContext())
            {
                var loan = context.Loans.Find(loanId);
                if (loan != null)
                {
                    loan.ReturnDate = DateTime.Now;
                    decimal fine = 0;

                    // Kontrola zpoždění
                    if (loan.ReturnDate > loan.DueDate)
                    {
                        // Spočítáme rozdíl ve dnech
                        var timeSpan = loan.ReturnDate.Value - loan.DueDate;
                        int daysLate = timeSpan.Days;

                        if (daysLate > 0)
                        {
                            // Sazba: 5 Kč za každý den zpoždění
                            fine = daysLate * 5;
                            loan.FineAmount = fine;
                        }
                    }

                    context.SaveChanges();
                    return fine; // Vrátíme vypočtenou pokutu (0 nebo víc)
                }
                return 0;
            }
        }

        // 4. Získat historii (pouze vrácené výpůjčky)
        public List<Loan> GetLoanHistory()
        {
            using (var context = new LibraryContext())
            {
                // Chceme ty, kde ReturnDate NENÍ null (už byly vráceny)
                // Seřadíme je od nejnovějších vrácení po nejstarší (OrderByDescending)
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