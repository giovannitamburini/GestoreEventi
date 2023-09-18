using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class EventsProgram
    {
        string Title { get; set; }
        List<Event> Events { get; set; }

        // COSTRUTTORE
        public EventsProgram(string programTitle)
        {
            this.Title = programTitle;
            this.Events = new List<Event>(); 
        }

        // METODI

        // metodo che aggiunge alla lista del programma eventi un Evento, passato come parametro al metodo
        public void AddEventToProgramList(Event ev)
        {
            Events.Add(ev);
        }

        // metodo che restituisce una lista di eventi con tutti gli eventi presenti in una certa data
        public List<Event> SearchEventsByDate(DateTime date)
        {
            List<Event> eventsByDate = Events.Where(e => e.Date == date).ToList();

            return eventsByDate;
        }
    }
}
