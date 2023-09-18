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

            // MILESTONE 4 -----------------------

            // chiedo all'utente il titolo del EventsProgram

            string programTitle;

            do
            {
                Console.Write("Inseirsci il titolo del tuo programma eventi: ");
                programTitle = Console.ReadLine();

                if (programTitle == null)
                {
                    Console.WriteLine("Hai inserito un valore nulla, devi inserire un nome valido");
                }

            } while (programTitle == null);


            // creo una nuova istanza di EventsProgram utilizando il titolo inserito dall'utente
            EventsProgram firstProgram = new EventsProgram(programTitle);

            // inizializzo una variabile int
            int numberOfEventsToAdd;

            // ciclo fin quando l'utente non inserisce un numero positivo
            do
            {
                Console.WriteLine("Indica il numero di eventi da inserire: ");

                string userInput = Console.ReadLine();

                if (int.TryParse(userInput, out numberOfEventsToAdd))
                {
                    if (numberOfEventsToAdd <= 0)
                    {
                        Console.WriteLine("Il numero inserito deve essere positivo");
                    }
                }
                else
                {
                    Console.WriteLine("Il tuo inserimento risulta errato, devi inserire un numero positivo.");
                }

            } while (numberOfEventsToAdd <= 0);

            for (int i = 0; i < numberOfEventsToAdd; i++)
            {
                //Console.Write($"Inserisci il titolo del {i + 1}° evento: ");
                //string eventTitle = Console.ReadLine() ?? string.Empty;
                //Console.Write($"Inserisci la data del {i + 1}° evento: ");
                //DateTime eventDate = DateTime.Parse(Console.ReadLine());
                //Console.Write($"Inserisci il numero di posti totali del {i + 1}° evento: ");
                //int eventMaxSeats = int.Parse(Console.ReadLine());

                bool validDate = false;

                // ciclo fino a quando non si inseriscono i dati validi
                while (!validDate)
                {
                    Console.Write($"Inserisci il titolo del {i + 1}° evento: ");
                    string eventTitle = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(eventTitle))
                    {
                        Console.WriteLine("Il titolo non può essere vuoto. Riprova.");
                        continue;
                    }

                    Console.Write($"Inserisci la data del {i + 1}° evento (formato dd/MM/yyyy): ");
                    string dateInput = Console.ReadLine();
                    if (!DateTime.TryParseExact(dateInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime eventDate))
                    {
                        Console.WriteLine("Formato data non valido. Utilizza il formato dd/MM/yyyy. Riprova.");
                        continue;
                    }

                    Console.Write($"Inserisci il numero di posti totali del {i + 1}° evento: ");
                    string seatsInput = Console.ReadLine();

                    if (!int.TryParse(seatsInput, out int eventMaxSeats) || eventMaxSeats <= 0)
                    {
                        Console.WriteLine("Il numero di posti deve essere un valore intero positivo. Riprova.");
                        continue;
                    }

                    // creo un nuovo evento
                    Event newEvent = new Event(eventTitle, eventDate, eventMaxSeats);

                    // aggiungo il nuovo evento alla lista degli eventi
                    firstProgram.AddEventToProgramList(newEvent);

                    validDate = true;
                }

            }
        }
    }
}