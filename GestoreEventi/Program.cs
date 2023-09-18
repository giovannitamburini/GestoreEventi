using System.Globalization;

namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {


                Console.Write("Inserisci il nome dell'evento: ");
                string eventTitle = Console.ReadLine();

                Console.Write("Inserisci la data dell'evento (dd/mm/yyyy): ");
                DateTime eventDate = DateTime.Parse(Console.ReadLine());


                Console.Write("Inserisci il numero di posti totali: ");
                int eventMaxCapacity = int.Parse(Console.ReadLine());

                // istanzio un nuovo evento
                Event firstShow = new Event(eventTitle, eventDate, eventMaxCapacity);

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Si è verificato un errore");
                Console.WriteLine(ex.Message);
            }
        }
    }
}