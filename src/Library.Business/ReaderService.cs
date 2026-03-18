using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Data.Entities;

namespace Library.Business
{
    public class ReaderService
    {
        // Načtení kompletního seznamu čtenářů z databáze
        public List<Reader> GetAllReaders()
        {
            using (var context = new LibraryContext())
            {
                // Jednoduchý select všech záznamů z tabulky Readers
                return context.Readers.ToList();
            }
        }

        // Registrace nového čtenáře do systému
        public void AddReader(string firstName, string lastName, string email, DateTime birthDate, string gender, string education)
        {
            using (var context = new LibraryContext())
            {
                // Mapování parametrů z formuláře na vlastnosti entity Reader
                var newReader = new Reader
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    DateOfBirth = birthDate, // Důležité pro kontrolu věku nebo narozenin
                    Gender = gender,
                    EducationLevel = education
                };

                context.Readers.Add(newReader); // Přidání objektu do kontextu
                context.SaveChanges(); // Fyzický zápis do SQL databáze
            }
        }

        // Automatické generování ukázkových dat (Data Seeding)
        public void CreateTestReader()
        {
            using (var context = new LibraryContext())
            {
                // Kontrola existence: pokud v DB nikdo není, vytvoří se vzorový záznam
                if (!context.Readers.Any())
                {
                    context.Readers.Add(new Reader
                    {
                        FirstName = "Jan",
                        LastName = "Novák",
                        Email = "jan.novak@email.cz",
                        DateOfBirth = new DateTime(1990, 5, 15),
                        Gender = "Muž",
                        EducationLevel = "VŠ"
                    });
                    context.SaveChanges();
                }
            }
        }

        // Filtrování čtenářů podle zadaného textu (vyhledávání)
        public List<Reader> SearchReaders(string query)
        {
            using (var context = new LibraryContext())
            {
                query = query.ToLower(); // Normalizace textu na malá písmena

                // Hledání shody buď v příjmení, nebo v křestním jméně
                return context.Readers
                    .Where(r => r.LastName.ToLower().Contains(query) ||
                                r.FirstName.ToLower().Contains(query))
                    .ToList();
            }
        }
    }
}