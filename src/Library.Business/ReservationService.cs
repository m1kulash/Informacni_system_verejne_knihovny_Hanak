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
        // Zařazení čtenáře do fronty na konkrétní knihu
        public void AddReservation(int readerId, int bookId)
        {
            using (var context = new LibraryContext())
            {
                // Kontrola duplicity: ověření, zda čtenář již v dané frontě není zapsán
                bool exists = context.Reservations.Any(r => r.ReaderId == readerId && r.BookId == bookId);
                if (exists) throw new Exception("Tento čtenář už v této frontě čeká.");

                // Vytvoření nového záznamu rezervace
                var reservation = new Reservation
                {
                    ReaderId = readerId,
                    BookId = bookId,
                    ReservationDate = DateTime.Now // Automatické nastavení času zápisu do fronty
                };

                context.Reservations.Add(reservation); // Přidání do databázového kontextu
                context.SaveChanges(); // Potvrzení uložení do SQL
            }
        }

        // Získání aktuálního pořadníku (fronty) pro vybranou knihu
        public List<Reservation> GetQueueForBook(int bookId)
        {
            using (var context = new LibraryContext())
            {
                return context.Reservations
                    .Include(r => r.Reader) // Přibalení dat o čtenáři pro zobrazení jména
                    .Include(r => r.Book)   // Přibalení dat o knize
                    .Where(r => r.BookId == bookId) // Filtrování rezervací pouze pro danou knihu
                    .OrderBy(r => r.ReservationDate) // Řazení podle data: princip "kdo dřív přijde, dřív bere"
                    .ToList();
            }
        }

        // Odstranění čtenáře z fronty (např. při zrušení zájmu nebo po vyřízení)
        public void RemoveReservation(int reservationId)
        {
            using (var context = new LibraryContext())
            {
                // Vyhledání konkrétního záznamu rezervace podle unikátního ID
                var res = context.Reservations.Find(reservationId);
                if (res != null)
                {
                    context.Reservations.Remove(res); // Odstranění z databáze
                    context.SaveChanges(); // Uložení změn
                }
            }
        }
    }
}