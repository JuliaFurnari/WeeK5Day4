using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeK5Day4
{
    class Menu
    {
        internal static void Start()
        {
            bool continuare = true;

            do
            {
                Console.WriteLine("Premi 1 per visualizzare tutti i prodotti.");
                Console.WriteLine("Premi 2 per visualizzare tutti i cellulari.");
                Console.WriteLine("Premi 3 per visualizzare tutti i pc.");
                Console.WriteLine("Premi 4 per visualizzare tutte le tv.");
                Console.WriteLine("Premi 5 per inserire un nuovo prodotto.");
                Console.WriteLine("Premi 6 per modificare un prodotto.");
                Console.WriteLine("Premi 7 per eliminare un prodotto.");
                Console.WriteLine("Premi 0 per uscire");
                Console.WriteLine();
                string scelta = Console.ReadLine();

                switch (scelta)
                {
                    case "1":
                        //Visualizza tutti i prodotti
                       Gestore.MostraProdotti();
                        break;
                    case "2":
                        //Visualizza tutti i cellulari
                       Gestore.MostraCellulari();
                        break;
                    case "3":
                        //Visualizza tutti i pc
                      Gestore.MostraPc();
                        break;
                    case "4":
                        //Visualizza tutte le tv
                      Gestore.MostraTv();
                        break;
                    case "5":
                        //Inserisci prodotti
                        Gestore.InserisciProdotti();
                        break;
                    case "6":
                        //Modifica i dati di un prodotto
                        Gestore.ModificaProdotto();
                        break;
                    case "7":
                        //Cancella un prodotto
                          Gestore.CancellaProdotto();
                        break;
                    case "0":
                        Console.WriteLine("Ciao alla prossima");
                        continuare = false;
                        break;
                    default:
                        Console.WriteLine("Scelta sbagliata riprova");
                        break;
                }
            } while (continuare);
        }
    }
}
