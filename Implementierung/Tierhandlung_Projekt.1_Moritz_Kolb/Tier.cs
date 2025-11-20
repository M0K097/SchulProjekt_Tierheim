using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tierhandlung_Projekt._1_Moritz_Kolb
{   
    public static class Tierheim
    {
        static List<Tier> alle_tiere = new ();
        static private void tier_hinzufügen(Tier tier) => alle_tiere.Add(tier);
        static public void tier_erstellen()
        {
            Console.WriteLine("Tierart:");
            var art = Console.ReadLine();
            Console.WriteLine("Tiername:");
            var name = Console.ReadLine();
            Console.WriteLine("Geburtsdatum:");
            var datum = Convert.ToDateTime(Console.ReadLine());

            if (art != null && name != null)
            {
                tier_hinzufügen(new Tier(art, name, datum));
            }
            else
            {
                Console.WriteLine("Das Tier konnte nicht hinzugefügt werden");
            }
        }
    }
    public class Tier
    {
        public string tierart { get; set; }
        public string name { get; set; }
        public DateTime geburtsdatum { get; set; }
        public string beschreibung { get; set; }
        public bool reserviert { get; set; }

        public Tier(string art, string name_des_tieres, DateTime geburtsdatum)
        {
            tierart = art;
            name = name_des_tieres;
            this.geburtsdatum = geburtsdatum;
            beschreibung = "keine Beschreibung";
            reserviert = false;
            
        }
            
    }
}
