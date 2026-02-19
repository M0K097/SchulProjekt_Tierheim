using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Tierhandlung_WPF_Anwendung_mit_Entity_Framework.DbModels;

namespace Tierhandlung_WPF_Anwendung_mit_Entity_Framework.Services
{
    public class Tierheim
    {
        private readonly TierheimContext context;
        public ObservableCollection<Tiere> alle_tiere { get; }
        public ObservableCollection<Tiere> gefilterte_tiere { get; set; }
        public ObservableCollection<Anfragen> alle_anfragen { get; set; }
        public ObservableCollection<Anfragen> deine_anfragen { get; set; }

        public void load_animals()
        {
            var animals = context.Tiere.ToList();
            alle_tiere.Clear();
            gefilterte_tiere.Clear();
            foreach (var an in animals)
            {
                alle_tiere.Add(an);
                gefilterte_tiere.Add(an);
            }
        }

        public void load_anfragen()
        {
            alle_anfragen.Clear();
            var anfragen = context.Anfragen.Include(a => a.Nutzer)
                .Include(a => a.Tier)
                .OrderBy(a => a.AnfrageId);
            foreach (var a in anfragen)
            {
                alle_anfragen.Add(a);
            }

        }
        public Account get_user(string name, string passwd)
        {
            var user = context.Account.SingleOrDefault(a => a.Benutzername == name && a.Passwort == passwd);
            return user;
        }

        public void load_nutzer_anfragen(Account nutzer)
        {
            var alle_anfragen = context.Anfragen.Include(a => a.Tier)
                .Where(a => a.NutzerId == nutzer.NutzerId)
                .ToList();

            deine_anfragen.Clear();
            foreach (var a in alle_anfragen)
            {
                deine_anfragen.Add(a);
            }
        }

        public bool check_if_request_exists(int tierId, int benutzerId)
        {
            if (context.Anfragen.Any(a => a.TierId == tierId && a.NutzerId == benutzerId))
                return true;
            else
                return false;

        }

        public bool create_new_account(Account neuer_account)
        {
            if (context.Account.Any(a => a.Benutzername == neuer_account.Benutzername))
            {
                return false;
            }
            else
            {
                context.Account.Add(neuer_account);
                context.SaveChanges();
                return true;
            }
        }

        public void filter(string query)
        {
            gefilterte_tiere.Clear();
            foreach (var element in alle_tiere)
            {
                if (!string.IsNullOrEmpty(element.Tiername) && !string.IsNullOrEmpty(element.Tierart))
                {
                    if (element.Tiername.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                        element.Tierart.Contains(query, StringComparison.OrdinalIgnoreCase))
                        gefilterte_tiere.Add(element);
                }
            }
        }

        public void anfrage_stellen(int BenutzerId, int TierId)
        {
            var neue_anfrage = new Anfragen();
            neue_anfrage.NutzerId = BenutzerId;
            neue_anfrage.TierId = TierId;

            context.Anfragen.Add(neue_anfrage);
            deine_anfragen.Add(neue_anfrage);
            context.SaveChanges();
        }

        public void remove_animal(Tiere selected_animal)
        {
            var selectedAnimal = context.Tiere
            .Include(t => t.Anfragen)
            .FirstOrDefault(t => t.TierId == selected_animal.TierId);

            if (selectedAnimal != null)
            {
                context.Anfragen.RemoveRange(selectedAnimal.Anfragen);
                context.Tiere.Remove(selectedAnimal);
                context.SaveChanges();
                alle_tiere.Remove(selectedAnimal);
            }

        }

        public void add_animal(string name, string species, DateTime geburtsdatum, string beschreibung)
        {
            var animal_to_add = new Tiere();
            animal_to_add.Tiername = name;
            animal_to_add.Tierart = species;
            animal_to_add.Geburtsdatum = geburtsdatum;
            animal_to_add.Beschreibung = beschreibung;

            context.Tiere.Add(animal_to_add);
            alle_tiere.Add(animal_to_add);
            gefilterte_tiere.Add(animal_to_add);
            context.SaveChanges();
        }

        public void tiere_ändern()
        {
            var con = context.Tiere;
            var tiere = alle_tiere;
            foreach (var t in tiere)
            {
                var to_change = con.FirstOrDefault(match => match.TierId == t.TierId);
                if (to_change == null)
                    continue;

                if (to_change.Tierart != t.Tierart ||
                    to_change.Tiername != t.Tiername ||
                    to_change.Beschreibung != t.Beschreibung ||
                    to_change.Geburtsdatum != t.Geburtsdatum)
                {
                    to_change.Tierart = t.Tierart;
                    to_change.Beschreibung = t.Beschreibung;
                    to_change.Tiername = t.Tiername;
                    to_change.Geburtsdatum = t.Geburtsdatum;
                }

            }
                context.SaveChanges();
        }

        public Tierheim(TierheimContext db_context)
        {
            context = db_context;
            alle_tiere = new ObservableCollection<Tiere>();
            alle_anfragen = new ObservableCollection<Anfragen>();
            deine_anfragen = new ObservableCollection<Anfragen>();
            gefilterte_tiere = new ObservableCollection<Tiere>();
        }

    }

}
