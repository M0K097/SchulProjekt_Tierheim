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

        public ObservableCollection<Tiere> load_animals()
        {   
            var animals = context.Tiere.ToList();
            var loadet_animals = new ObservableCollection<Tiere>(animals);
            return loadet_animals;
        }

        public ObservableCollection<Anfragen> load_anfragen()
        {
            var anfragen = context.Anfragen.Include(a => a.Nutzer)
                .Include(a => a.Tier)
                .OrderBy(a => a.AnfrageId);

            ObservableCollection<Anfragen> loaded_anfragen = new ObservableCollection<Anfragen>(anfragen);
            return loaded_anfragen;
        }

        public void login(string name, string password)
        {
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

        public Tierheim(TierheimContext tierheim)
        {
            this.context = new TierheimContext();
            alle_tiere = load_animals();
            alle_anfragen = load_anfragen();
            gefilterte_tiere = new ObservableCollection<Tiere>(alle_tiere);
        }
    }
     
}
