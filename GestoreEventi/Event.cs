using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    public class Event
    {
        public string title;
        public DateTime date;
        public int maxCapacity;
        public int ReservedSeats { get; } 

        public string Title
        {
            get { return title; }

            set
            {
                if (string.IsNullOrEmpty(title))
                {
                    throw new ArgumentException($"Il titolo non può ezsere vuoto");

                }
                    title = value;
            }
        }

        public DateTime Date
        {
            get { return date; }

            set
            {
                if (date < DateTime.Now)
                {
                    throw new ArgumentException("La data inserita è errata, non può essere passata");
                }

                date = value;
            }
        }

        public int MaxCapacity
        {
            get { return maxCapacity; }

            set
            {
                if (maxCapacity <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(maxCapacity), "La capienza massima dell'evento deve essere un numero positivo");
                }

                maxCapacity = value;
            }
        }

        // COSTRUTTORE
        public Event(string title, DateTime date, int maxCapacity, int reservedSeats)
        {
            this.Title = title;
            this.Date = date;
            this.MaxCapacity = maxCapacity;
            this.ReservedSeats = 0;
        }

    }
}
