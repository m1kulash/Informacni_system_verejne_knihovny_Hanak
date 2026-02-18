using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Data.Entities;

namespace Library.Business
{
    public class ReaderService
    {
        // 1. Načíst všechny čtenáře
        public List<Reader> GetAllReaders()
        {
            using (var context = new LibraryContext())
            {
                return context.Readers.ToList();
            }
        }

        // 2. Přidat nového čtenáře
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

                context.Readers.Add(newReader);
                context.SaveChanges();
            }
        }

        // 3. Vytvořit testovacího čtenáře
        public void CreateTestReader()
        {
            using (var context = new LibraryContext())
            {
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

        // Vyhledávání čtenářů podle jména nebo příjmení
        public List<Reader> SearchReaders(string query)
        {
            using (var context = new LibraryContext())
            {
                query = query.ToLower();

                return context.Readers
                    .Where(r => r.LastName.ToLower().Contains(query) ||
                                r.FirstName.ToLower().Contains(query))
                    .ToList();
            }
        }
    }
}