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

                // blocco di codice dove chiedo all'utente se vuole prenotare dei posti --------------------

                // istanzio una variabile per salvare la scelta nell'effettuare una prenotazione
                string choice;

                do
                {
                    Console.Write("Vuoi effettuare una prenotazione (si/no) ? ");
                    choice = Console.ReadLine().ToLower();

                } while (choice != "si" && choice != "no");

                if (choice == "si")
                {
                    Console.Write("Quanti posti desideri prenotare? ");

                    int placesToReserve;

                    if(int.TryParse(Console.ReadLine(), out placesToReserve))
                    {
                        firstShow.ReserveSeats(placesToReserve);

                        firstShow.PrintReservedAndAvailableSeats();
                    } else
                    {
                        Console.WriteLine("Input inserito non valido");
                    }
                }


                // blocco di codice dove domando all'utente se vuole disdire dei posti -----------------------
                string choiceCancellation;

                do
                {
                    Console.Write("Vuoi disdire dei posti (si/no) ? ");
                    choiceCancellation = Console.ReadLine().ToLower();

                    if (choiceCancellation == "si")
                    {
                        Console.Write("Indica il numero di posti da disdire: ");

                        int placesToCancel;

                        if(int.TryParse(Console.ReadLine(), out placesToCancel))
                        {
                            firstShow.CancelSeats(placesToCancel);

                            firstShow.PrintReservedAndAvailableSeats();

                            Console.WriteLine();

                        } else
                        {
                            Console.WriteLine("Input non valido. Inserisci un numero di posti da disdire valido");
                        }
                    }

                } while (choiceCancellation != "no");


            }catch(ArgumentException ex)
            {
                Console.WriteLine("Si è verificato un errore");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Si è verificato un errore");
                Console.WriteLine(ex.Message);
            } 
        }
    }
}