using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Data.Entities;

namespace Library.Business
{
    public class ReaderService
    {
        // Načtení kompletního seznamu všech registrovaných čtenářů
        public List<Reader> GetAllReaders()
        {
            using (var context = new LibraryContext())
            {
                // Vrací seznam všech entit z tabulky Readers
                return context.Readers.ToList();
            }
        }

        // Registrace nového čtenáře: Mapování dat z UI formuláře do databáze
        public void AddReader(string firstName, string lastName, string email, DateTime birthDate, string gender, string education)
        {
            using (var context = new LibraryContext())
            {
                var newReader = new Reader
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    DateOfBirth = birthDate,
                    Gender = gender,
                    EducationLevel = education
                };

                context.Readers.Add(newReader); // Zařazení do fronty na zápis
                context.SaveChanges(); // Fyzické propsání změn do SQL databáze
            }
        }

        // Vyhledávání čtenářů podle jména nebo příjmení (case-insensitive)
        public List<Reader> SearchReaders(string query)
        {
            using (var context = new LibraryContext())
            {
                query = query.ToLower(); // Převod na malá písmena pro spolehlivé hledání

                return context.Readers
                    .Where(r => r.LastName.ToLower().Contains(query) ||
                                r.FirstName.ToLower().Contains(query))
                    .ToList();
            }
        }

        // --- KLÍČOVÁ FUNKCE: BEZPEČNÉ SMAZÁNÍ ČTENÁŘE ---
        public void DeleteReader(int readerId)
        {
            using (var context = new Library.Data.LibraryContext())
            {
                // KONTROLA INTEGRITY: Ověříme, zda čtenář nemá v tuto chvíli půjčenou knihu
                bool hasActiveLoans = context.Loans.Any(l => l.ReaderId == readerId && l.ReturnDate == null);

                if (hasActiveLoans)
                {
                    // Pokud má knihy u sebe, vyvoláme výjimku (program akci zastaví)
                    throw new Exception("Čtenáře nelze smazat, protože má nevrácené knihy!");
                }

                var reader = context.Readers.Find(readerId);
                if (reader != null)
                {
                    context.Readers.Remove(reader); // Odstranění záznamu
                    context.SaveChanges(); // Potvrzení smazání v DB
                }
            }
        }

        // AUTOMATICKÉ PLNĚNÍ (SEEDING) BEZ DUPLICIT
        public void SeedReaders()
        {
            using (var context = new Library.Data.LibraryContext())
            {
                // Definice vzorových čtenářů pro prezentaci
                var testReaders = new[]
                {
                    new { F = "Jan", L = "Novák" },
                    new { F = "Marie", L = "Svobodová" }
                };

                foreach (var r in testReaders)
                {
                    // Kontrola existence: Přidáme jen ty, kteří v databázi ještě nejsou
                    if (!context.Readers.Any(reader => reader.FirstName == r.F && reader.LastName == r.L))
                    {
                        context.Readers.Add(new Library.Data.Entities.Reader
                        {
                            FirstName = r.F,
                            LastName = r.L,
                            DateOfBirth = new DateTime(1990, 1, 1),
                            Gender = "Ostatní",
                            EducationLevel = "SŠ"
                        });
                    }
                }
                context.SaveChanges(); // Hromadné uložení nových záznamů
            }
        }
    }
}