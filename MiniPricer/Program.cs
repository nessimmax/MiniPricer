using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPricer
{
    class Program
    {
        static void Main(string[] args)
        {

            double prix = 0;
            double volatilite = 0;

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr-FR");

            Console.Write("Le Prix actuel du produit : ");
            if (!double.TryParse(Console.ReadLine(), out prix))
                return;

            Console.Write("Volatilité journalière moyenne de l’instrument en %: ");
            if (!double.TryParse(Console.ReadLine(), out volatilite))
                return;


            Console.Write("Entez la date (s.forme 24/10/2019): ");
            DateTime datePrevisonnelle;
            if (!DateTime.TryParse(Console.ReadLine(), out datePrevisonnelle))
                return;

            Console.Write("Entez date jour ferié ou bien laissez vide (s.forme 10/24/2019): ");
            Product p = new Product();
            p.Prix = prix;
            p.Volatilite = volatilite;

            var console = Console.ReadLine();

            while (console != String.Empty)
            {
                DateTime jourFerie;
                if (!DateTime.TryParse(console, out jourFerie))
                    return;

                p.Feries.Add(jourFerie);
                Console.Write("Entez une autre date jour ferié ou bien laissez vide (s.forme 10/24/2019): ");
                console = Console.ReadLine();
            }


            Console.Write("Le prix {0:C} est le {1:dd/MM/yyyy}", p.GetPrixPrev(datePrevisonnelle), datePrevisonnelle);
            Console.ReadKey();
        }
    }
}
