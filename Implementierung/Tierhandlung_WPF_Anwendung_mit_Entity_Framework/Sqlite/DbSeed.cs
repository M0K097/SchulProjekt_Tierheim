using System;
using System.IO;
using System.Linq;
using Tierhandlung_WPF_Anwendung_mit_Entity_Framework.DbModels;

namespace Tierhandlung_WPF_Anwendung_mit_Entity_Framework
{
    public static class DbSeeder
    {
        public static void Seed(TierheimContext context)
        {
            // Ensure database and tables exist
            context.Database.EnsureCreated();

            // --- Seed Accounts ---
            if (!context.Account.Any())
            {
                context.Account.AddRange(
                    new Account { Benutzername = "admin", Passwort = "admin123", IsAdmin = true },
                    new Account { Benutzername = "user1", Passwort = "password1", IsAdmin = false },
                    new Account { Benutzername = "user2", Passwort = "password2", IsAdmin = false }
                );
            }

            // --- Seed Tiere ---
            if (!context.Tiere.Any())
            {
                context.Tiere.AddRange(
                    new Tiere
                    {
                        Tiername = "Bello",
                        Tierart = "Hund",
                        Geburtsdatum = new DateTime(2020, 5, 1),
                        Beschreibung = "Freundlicher Hund"
                    },
                    new Tiere
                    {
                        Tiername = "Miezi",
                        Tierart = "Katze",
                        Geburtsdatum = new DateTime(2021, 3, 12),
                        Beschreibung = "Schüchterne Katze"
                    },
                    new Tiere
                    {
                        Tiername = "Hoppel",
                        Tierart = "Kaninchen",
                        Geburtsdatum = new DateTime(2019, 8, 20),
                        Beschreibung = "Neugieriges Kaninchen"
                    }
                );
            }

            // --- Seed Anfragen ---
            if (!context.Anfragen.Any())
            {
                var user1 = context.Account.FirstOrDefault(a => a.Benutzername == "user1");
                var user2 = context.Account.FirstOrDefault(a => a.Benutzername == "user2");
                var tier1 = context.Tiere.FirstOrDefault(t => t.Tiername == "Bello");
                var tier2 = context.Tiere.FirstOrDefault(t => t.Tiername == "Miezi");
                var tier3 = context.Tiere.FirstOrDefault(t => t.Tiername == "Hoppel");

                if (user1 != null && user2 != null && tier1 != null && tier2 != null && tier3 != null)
                {
                    context.Anfragen.AddRange(
                        new Anfragen
                        {
                            NutzerId = user1.NutzerId,
                            TierId = tier1.TierId,
                            Status = "Pending",
                            TextInfo = "User1 interessiert sich für Bello"
                        },
                        new Anfragen
                        {
                            NutzerId = user1.NutzerId,
                            TierId = tier2.TierId,
                            Status = "Pending",
                            TextInfo = "User1 interessiert sich für Miezi"
                        },
                        new Anfragen
                        {
                            NutzerId = user2.NutzerId,
                            TierId = tier3.TierId,
                            Status = "Approved",
                            TextInfo = "User2 hat Hoppel adoptiert"
                        }
                    );
                }
            }

            // Save all changes to the database
            context.SaveChanges();
        }
    }
}
