using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPricer
{
    public class Product
    {

        private double prix = 0;
        private double volatilite = 0;
        private List<DateTime> feries;

        public Product()
        {
            feries = new List<DateTime>();
        }
        public double GetPrix( )
        {
            return prix;
        }
        public double GetPrixPrev(DateTime datePrev)
        {
            DateTime Selectedday = DateTime.Now.AddDays(1);
            double NewPrice = prix;
            for (var day = Selectedday.Date; Selectedday.Date <= datePrev.Date; Selectedday = Selectedday.AddDays(1))
            {
                DayOfWeek SelecteddayWeek = Selectedday.DayOfWeek;
                
                if ((SelecteddayWeek != DayOfWeek.Saturday) && (SelecteddayWeek != DayOfWeek.Sunday) && !this.IsFerie(Selectedday) )
                {
                    NewPrice = NewPrice * (1 + volatilite / 100);
                }               
            }

            return NewPrice;
        }

        public bool IsFerie(DateTime date)
        {
            bool e = this.feries.Any(x => x.Date == date.Date);
            return e;
        }

        public double Prix { get { return prix; } set { prix = value;} }
        public double Volatilite { get { return volatilite; } set { volatilite = value; } }

        public List<DateTime> Feries { get => feries; set => feries = value; }
    }
}
