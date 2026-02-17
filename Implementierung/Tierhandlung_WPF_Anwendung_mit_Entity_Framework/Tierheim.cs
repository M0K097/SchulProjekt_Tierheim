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
        TierheimContext context = new TierheimContext();
        public ObservableCollection<Tiere> alle_tiere { get; set; }
        public ObservableCollection<Tiere> gefilterte_tiere { get; set; }

        public ObservableCollection<Tiere> LoadAnimals()
        {   
            var animals = context.Tiere.ToList();
            var loadet_animals = new ObservableCollection<Tiere>(animals);
            return loadet_animals;
        }

        public void filter(string query)
        {
            gefilterte_tiere.Clear();
                foreach(var element in alle_tiere)
                {
                    if(element.Tiername is not null && element.Tiername.Contains(query))
                    gefilterte_tiere.Add(element);
                }
        }

        public Tierheim()
        {
            alle_tiere = LoadAnimals();
            gefilterte_tiere = new ObservableCollection<Tiere>(alle_tiere);
        }
    }
     
}
