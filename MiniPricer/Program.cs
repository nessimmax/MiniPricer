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

            double P = 0;
            double V = 0;

            Console.Write("Le Prix acteul de produit : ");
            double.TryParse(Console.ReadLine(), out P);
            Console.Write("Volatilité journalière moyenne de l’instrument en %: ");
            double.TryParse(Console.ReadLine(), out V);


            Console.Write("Entez la date (s.forme 10/24/2019): ");
            DateTime DatePrevisonnel = DateTime.Parse(Console.ReadLine());

            Console.Write("Entez date jour ferié ou bien laissez vide (s.forme 10/24/2019): ");
            Product p = new Product();
            p.Prix = P;
            p.Volatilite = V;

            var console = Console.ReadLine();

            while (console !="")
            {
                p.Feries.Add(DateTime.Parse(console));
                Console.Write("Entez une autre date jour ferié ou bien laissez vide (s.forme 10/24/2019): ");
                console = Console.ReadLine();
            }


            Console.Write("Le prix {0} est le {1}", p.GetPrixPrev(DatePrevisonnel), DatePrevisonnel.ToString("dd/MM/yyyy"));
            Console.ReadKey();
        }
    }
}
