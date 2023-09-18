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

        // un metodo statico che si occupa, presa una lista di eventi, di stamparla in Console, o ancora meglio vi restituisca la rappresentazione in stringa della vostra lista di eventi.
        public static string PrintEventsList(List<Event> events)
        {
            StringBuilder sb = new StringBuilder();

            Console.WriteLine("Lita eventi in stringa:");

            foreach (Event singleEvent in events)
            {
                sb.Append($"- Titolo evento: {singleEvent.Title}, ");
                sb.Append($"Data evento: {singleEvent.Date}, ");
                sb.Append($"Capacità massima evento: {singleEvent.MaxCapacity}");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        // un metodo che restituisce quanti eventi sono presenti nel programma eventi attualmente.
        public int CountEventsInTheList()
        {
            return Events.Count;
        }
    }


}
