using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Data.Entities;
using System.Data.Entity;

namespace Library.Business
{
    public class ReservationService
    {
        // Metoda pro zařazení čtenáře do fronty na vypůjčenou knihu
        public void AddReservation(int readerId, int bookId)
        {
            using (var context = new LibraryContext())
            {
                // 1. PRAVIDLO: Kontrola, zda je kniha skutečně půjčená (volná kniha se nerezervuje)
                bool isBorrowed = context.Loans.Any(l => l.BookId == bookId && l.ReturnDate == null);
                if (!isBorrowed)
                    throw new Exception("Kniha je aktuálně volná. Rezervace není nutná, můžete si ji rovnou půjčit.");

                // 2. PRAVIDLO: Čtenář si nemůže rezervovat knihu, kterou má sám zrovna půjčenou
                bool readerHasIt = context.Loans.Any(l => l.BookId == bookId && l.ReaderId == readerId && l.ReturnDate == null);
                if (readerHasIt)
                    throw new Exception("Tuto knihu již máte vypůjčenou, nemůžete si ji rezervovat.");

                // 3. PRAVIDLO: Kontrola duplicity (čtenář nesmí být ve frontě na stejnou knihu dvakrát)
                bool exists = context.Reservations.Any(r => r.ReaderId == readerId && r.BookId == bookId);
                if (exists)
                    throw new Exception("V této frontě již čekáte.");

                // Pokud jsou všechna pravidla splněna, vytvoříme nový záznam o rezervaci
                var reservation = new Reservation
                {
                    ReaderId = readerId,
                    BookId = bookId,
                    ReservationDate = DateTime.Now // Čas zápisu určuje pořadí ve frontě
                };

                context.Reservations.Add(reservation);
                context.SaveChanges(); // Uložení do databáze
            }
        }

        // Získání aktuálního pořadníku pro konkrétní knihu
        public List<Reservation> GetQueueForBook(int bookId)
        {
            using (var context = new LibraryContext())
            {
                // Vracíme seznam seřazený od nejstarší po nejnovější rezervaci (Princip FIFO)
                return context.Reservations
                    .Include(r => r.Reader) // Eager Loading: načtení údajů o čtenáři pro UI
                    .Include(r => r.Book)   // Eager Loading: načtení údajů o knize
                    .Where(r => r.BookId == bookId)
                    .OrderBy(r => r.ReservationDate) // První v pořadí má přednost
                    .ToList();
            }
        }

        // Metoda pro vyřazení z fronty (např. po vyřízení rezervace nebo zrušení zájmu)
        public void RemoveReservation(int reservationId)
        {
            using (var context = new LibraryContext())
            {
                var res = context.Reservations.Find(reservationId);
                if (res != null)
                {
                    context.Reservations.Remove(res); // Odstranění z kontextu
                    context.SaveChanges(); // Fyzické smazání záznamu z DB
                }
            }
        }
    }
}