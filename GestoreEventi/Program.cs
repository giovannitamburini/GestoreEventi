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

                //DateTime eventDate = DateTime.Parse(Console.ReadLine());

                bool inputDate = false;
                DateTime eventDate = DateTime.Now;


                while (!inputDate)
                {
                    Console.Write("Inserisci la data dell'evento (dd/mm/yyyy): ");

                    if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out eventDate))
                    {
                       inputDate = true;
                    }
                    else
                    {
                        Console.WriteLine("Formato non valido, usa il formato dd/MM/yyyy");
                    }
                }


                Console.Write("Inserisci il numero di posti totali: ");
                int eventMaxCapacity = int.Parse(Console.ReadLine());

                // istanzio un nuovo evento
                Event firstShow = new Event(eventTitle, eventDate, eventMaxCapacity);

                string choice;

                do
                {
                    Console.Write("Vuoi effettuare una prenotazione? (si/no): ");
                    choice = Console.ReadLine().ToLower();

                } while (choice != "si" && choice != "no");

                if (choice == "si")
                {
                    Console.Write("Quanti posti desideri prenotare? ");

                    int placesToReserve = int.Parse(Console.ReadLine());

                    firstShow.ReserveSeats(placesToReserve);

                    firstShow.PrintReservedAndAvailableSeats();
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Si è verificato un errore");
                Console.WriteLine(ex.Message);

            } 
        }
    }
}