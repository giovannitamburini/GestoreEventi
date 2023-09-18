using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Conference : Event
    {
        public string Speaker { get; set; }
        public double Price { get; set; }

        public Conference(string title, DateTime date, int maxCapacity, string speaker, double price) : base(title, date, maxCapacity)
        {
            this.Speaker = speaker;
            this.Price = price;
        }

        public string DateFormatter(DateTime date)
        {
            return date.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public string PriceFormatter(double price)
        {
            return price.ToString("0.00");
        }
    }
}
