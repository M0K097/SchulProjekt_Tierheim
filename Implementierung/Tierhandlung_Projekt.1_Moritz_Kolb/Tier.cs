using System.ComponentModel.Design;

namespace Tierhandlung_Projekt._1_Moritz_Kolb
{   
    public static class Tierheim
    {
        static public List<Tier> alle_tiere = new ();
        static public List<Tier> ausgewählte_tiere = new();
        
        static public void tier_hinzufügen()
        {
            try
            {
                Console.WriteLine("Tierart:");
                var art = Console.ReadLine();
                Console.WriteLine("Tiername:");
                var name = Console.ReadLine();
                Console.WriteLine("Geburtsdatum:");
                var datum = Convert.ToDateTime(Console.ReadLine());

                if (art != null && name != null)
                {
                    alle_tiere.Add(new Tier(art, name, datum));
                }
                else
                {
                    throw new Exception("Tierart oder Name war NULL");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Fehler: {e}");
            }
        }

        static public void filter_nach_tier()
        {

            string suchbegriff = "";
            var suche = Console.ReadLine();
            if (suche is not null)
            {
                suchbegriff = suche;
            }
            var gefilterte_tiere = alle_tiere.Where(( tier ) => tier.tierart.Contains(suchbegriff)).ToList();
            tiere_anzeigen(gefilterte_tiere);
            Console.ReadLine();
        }

        static public void tiere_anzeigen(List<Tier> tiere)
        {
            foreach(Tier tier in tiere)
            {
                Console.WriteLine($"Art: {tier.tierart} Name: {tier.name} Geburtsdatum: {tier.geburtsdatum} Adoptionsnfrage: {tier.reserviert}");
            }
            Console.WriteLine();
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
