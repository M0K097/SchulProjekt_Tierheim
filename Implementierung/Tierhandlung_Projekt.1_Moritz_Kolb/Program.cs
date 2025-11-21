//Kurzbeschreibung: Eine Anwendung, mit der Mitarbeiter eines Tierheims die zu vermittelnden
//Tiere mit Fotos und Beschreibungen präsentieren können.
//Interessenten können die Tiere filtern und Adoptionsanfragen stellen.
using static Tierhandlung_Projekt._1_Moritz_Kolb.Tierheim;

namespace Tierhandlung_Projekt._1_Moritz_Kolb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while(running)
            {
                Console.Clear();
                Console.WriteLine(">> TIERHEIM <<");
                tiere_anzeigen(alle_tiere);
                Console.WriteLine("Drücken sie f um nach einem Tier zu filter und x um ein neues Tier hinzuzufügen");
                var selection = Console.ReadLine();
                switch (selection)
                {
                    case "f":
                        filter_nach_tier();
                        break;
                    case "x":
                        tier_hinzufügen();
                        break;
                    case "e":
                        running = false;
                        Console.WriteLine(" ==>> Programm beendet");
                        break;
                    default: Console.WriteLine($"option {selection} nicht verfügbar");
                        break;
                };

            }
            
        }
    }
}