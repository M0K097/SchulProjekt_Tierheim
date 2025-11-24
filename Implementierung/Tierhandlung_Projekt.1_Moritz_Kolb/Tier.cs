namespace Tierhandlung_Projekt._1_Moritz_Kolb
{   
    public static class Tierheim
    {
        static public List<Tier> alle_tiere = new ();       
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
                    Console.WriteLine($"{art}{name} wurde erfoglreich hinzugefügt");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Fehler: {e}");
            }

            Console.WriteLine("Drücke eine beliebige Taste...");
            Console.ReadLine();
        }

        static public void filter_nach_tier()
        {
<<<<<<< HEAD
            var gefilterte_tiere = alle_tiere.Where((Tier t) => t.name == suchbegriff).ToList();
            return gefilterte_tiere;
=======
            string suchbegriff = "";
            var suche = Console.ReadLine();
            if (suche is not null)
            {
                suchbegriff = suche;
            }
            var gefilterte_tiere = alle_tiere.Where(( tier ) => tier.tierart.Contains(suchbegriff)).ToList();
            tiere_anzeigen(gefilterte_tiere);
            Console.ReadLine();
>>>>>>> d3f50f0bc5f4e0cbb7523d394e46bdebd8f293e7
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

        public Tier(string art, string name_des_tieres, DateTime geburtsdatum)
        {
            tierart = art;
            name = name_des_tieres;
            this.geburtsdatum = geburtsdatum;
            beschreibung = "keine Beschreibung";
            
        }
            
    }
}
