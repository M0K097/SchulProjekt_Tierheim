using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tierhandlung_WPF_Anwendung_mit_Entity_Framework.DbModels;

namespace Tierhandlung_WPF_Anwendung_mit_Entity_Framework.Models
{
    public class Tierheim
    {
        public readonly TierheimContext context;
        public ObservableCollection<Tiere> alle_tiere { get; set; }
        public ObservableCollection<Tiere> gefilterte_tiere { get; set; }
        public ObservableCollection<Anfragen> alle_anfragen { get; set; }
        public ObservableCollection<Anfragen> deine_anfragen { get; set; }

        public void load_animals()
        {   
            var animals = context.Tiere.ToList();
            alle_tiere.Clear();
            gefilterte_tiere.Clear();
            foreach(var an in animals)
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
            foreach(var a in anfragen)
            {
                alle_anfragen.Add(a);
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
                        element.Tierart.Contains(query,StringComparison.OrdinalIgnoreCase))
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

        public Tierheim(TierheimContext tierheim)
        {
            this.context = new TierheimContext();
            alle_tiere = new ObservableCollection<Tiere>();
            alle_anfragen = new ObservableCollection<Anfragen>();
            deine_anfragen = new ObservableCollection<Anfragen>();
            gefilterte_tiere = new ObservableCollection<Tiere>();
        }
    }
     
}
