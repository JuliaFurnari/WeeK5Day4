using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeK5Day4.ListRepository;
using WeeK5Day4.Entity;

namespace WeeK5Day4
{
    class Gestore
    {
        // i repository che chiamano le classi con le liste statiche
        public static ProdottoListRepository prodottoRepository = new ProdottoListRepository();
        public static CellulareListRepository cellulareRepository = new CellulareListRepository();
        public static PcListRepository pcRepository = new PcListRepository();
        public static TvListRepository tvRepository = new TvListRepository();


        internal static void MostraProdotti()
        {
            List<Prodotto> prodotti = prodottoRepository.Fetch();
            foreach (var prodotto in prodotti)
            {
                prodotto.PrintInfo();
                Console.WriteLine("");
            }
        }

        internal static void MostraCellulari()
        {
            List<Cellulare> cellulari = cellulareRepository.Fetch();
            foreach (var cellulare in cellulari)
            {
                cellulare.PrintInfo();
                Console.WriteLine("");
            }
        }

        internal static void MostraPc()
        {
            List<Pc> computers = pcRepository.Fetch();
            foreach (var pc in computers)
            {
                pc.PrintInfo();
                Console.WriteLine("");
            }
        }
        internal static void MostraTv()
        {
            List<Tv> televisori = tvRepository.Fetch();
            foreach (var televisore in televisori)
            {
                televisore.PrintInfo();
                Console.WriteLine("");
            }
        }

        //***************************** Inserimento Prodotto **********

        internal static void InserisciProdotti()
        {
            int prodottoScelto;

            do
            {
                Console.WriteLine("Che prodotto vuoi scegliere?");
                Console.WriteLine("Premi 1 per inserire un nuovo cellulare");
                Console.WriteLine("Premi 2 per inserire un nuovo pc");
                Console.WriteLine("Premi 3 per inserire una nuova tv");                 

            } while (!int.TryParse(Console.ReadLine(), out prodottoScelto) || prodottoScelto <= 0 || prodottoScelto >= 4);

            switch (prodottoScelto)
            {
                case 1:
                    Cellulare cellulare = InserisciCellulare();
                    cellulareRepository.Insert(cellulare);
                    break;
                case 2:
                    Pc pc = InserisciPc();
                    pcRepository.Insert(pc);
                    break;
                case 3:
                    Tv tv = InserisciTv();
                    tvRepository.Insert(tv);
                    break;
            }

        }



        private static Tv InserisciTv()
        {
            Prodotto prodotto = InserisciProdotto();
            Tv tv = new Tv();
            tv.Marca = prodotto.Marca;
            tv.Modello = prodotto.Modello;
            tv.QuantitàInMagazzino = prodotto.QuantitàInMagazzino;
            tv.Pollici = InserisciPollici();
            return tv;
        }

        private static Pc InserisciPc()
        {
            Prodotto prodotto = InserisciProdotto();
            Pc pc = new Pc();
            pc.Marca = prodotto.Marca;
            pc.Modello = prodotto.Modello;
            pc.QuantitàInMagazzino = prodotto.QuantitàInMagazzino;
            pc.SistemaOperativo = InsertSistemaOperativo();
            pc.TouchScreen = InsertTouchScreen();
            return pc;
        }

   

        private static Cellulare InserisciCellulare()
        {
            Prodotto prodotto = InserisciProdotto();
            Cellulare cellulare = new Cellulare();
            cellulare.Marca = prodotto.Marca;
            cellulare.Modello = prodotto.Modello;
            cellulare.QuantitàInMagazzino = prodotto.QuantitàInMagazzino;
            cellulare.MemoriaGB = InserisciMemoriaGB();
            return cellulare;
        }

        private static Prodotto InserisciProdotto()
        {
            Prodotto prodotto = new Prodotto();
            prodotto.Marca = InserisciMarca();
            prodotto.Modello = InserisciModello();
            prodotto.QuantitàInMagazzino = InserisciQuantitaMagazzino();
      
            return prodotto;
        }

        private static string InserisciMarca()
        {
            string marca = String.Empty;
            do
            {
                Console.WriteLine("Inserisci marca.");
                marca = Console.ReadLine();

            } while (String.IsNullOrEmpty(marca));
            return marca;
        }

        private static string InserisciModello()
        {
            string modello = String.Empty;
            do
            {
                Console.WriteLine("Inserisci modello.");
                modello = Console.ReadLine();

            } while (String.IsNullOrEmpty(modello));
            return modello;
        }

        private static int InserisciQuantitaMagazzino()
        {
            int quantitaMagazzino;
            Console.WriteLine("Inserisci quantità magazzino.");
            while (!int.TryParse(Console.ReadLine(), out quantitaMagazzino) || quantitaMagazzino <= 0) 
            {
                Console.WriteLine("Errore. Devi inserire un intero");
            }
            return quantitaMagazzino;
        }

        private static float InserisciMemoriaGB()
        {
            float memoriaGB;
            Console.WriteLine("Inserisci la memoria in GB.");
            while (!float.TryParse(Console.ReadLine(), out memoriaGB) || memoriaGB<= 0)
            {
                Console.WriteLine("Errore. Devi inserire un numero.");
            }
            return memoriaGB;
        }

        private static Sistema InsertSistemaOperativo()
        {
           
            int sistemaOperativo = 0;
            do
            {
                Console.WriteLine("Inserisci il tipo di sistema operativo.");
                foreach (var sistema in Enum.GetValues(typeof(Sistema)))
                {
                    Console.WriteLine($"Premi {(int)sistema} per {(Sistema)sistema}");
                }

              
            } while (!int.TryParse(Console.ReadLine(), out sistemaOperativo) ||  sistemaOperativo < 0 || sistemaOperativo > 2);
            return (Sistema)sistemaOperativo;
        }

        private static bool InsertTouchScreen()
        {
            
            string risposta;
            do
            {
                Console.WriteLine("Ha il touch screen? Scrivi si o no");
                risposta = Console.ReadLine();
                
                   
            } while (risposta != "si" && risposta != "no");

            return risposta == "si" ? true : false;
        }

        private static int InserisciPollici()
        {
            int pollici;
            Console.WriteLine("Inserisci i pollici della tv.");
            while (!int.TryParse(Console.ReadLine(), out pollici) || pollici <= 0)
            {
                Console.WriteLine("Errore. Devi inserire un intero.");
            }
            return pollici;
        }

        //******************** Modifica Prodotto *******************************

        internal static void ModificaProdotto()
        {
            int prodottoScelto;

            do
            {
                Console.WriteLine("Che prodotto vuoi scegliere?");
                Console.WriteLine("Premi 1 per modificare un cellulare.");
                Console.WriteLine("Premi 2 per modificare un pc.");
                Console.WriteLine("Premi 3 per modificare una tv.");

            } while (!int.TryParse(Console.ReadLine(), out prodottoScelto) || prodottoScelto <= 0 || prodottoScelto >= 4);

            switch (prodottoScelto)
            {
                case 1:
                    ModificaCellulare();

                    break;
                case 2:
                     ModificaPc();

                    break;
                case 3:
                    ModificaTv();

                    break;
            }

        }   
        public static Cellulare SceltaCellulare()
        {
            List<Cellulare> cellulari = cellulareRepository.Fetch();
            int i = 1;
            foreach (var cellulare in cellulari)
            {
                Console.WriteLine($"Premi {i} per selezionare: ");
                cellulare.PrintInfo();
                i++;
            }

            int cellulareScelto;
            do
            {
                Console.WriteLine("Quale cellulare?");

            } while (!int.TryParse(Console.ReadLine(), out cellulareScelto) || cellulareScelto <= 0 || cellulareScelto > cellulari.Count);

            Console.WriteLine("Hai scelto di modificare");
            Cellulare cellulare1 = cellulari.ElementAt(cellulareScelto - 1);

            return cellulare1;
        }
        public static void ModificaCellulare() {

            Cellulare cellulare = SceltaCellulare();
            if (cellulare.Id == null)
            {
                cellulareRepository.Delete(cellulare);
            }

            bool continuare = true;
            string risposta;
            do
            {
                Console.WriteLine("Vuoi modificare la marca?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                cellulare.Marca = InserisciMarca();
            }

            do
            {
                Console.WriteLine("Vuoi modificare il modello?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                cellulare.Modello = InserisciModello();
            }

            do
            {
                Console.WriteLine("Vuoi modificare la quantità in magazzino?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                cellulare.QuantitàInMagazzino = InserisciQuantitaMagazzino();
            }

            do
            {
                Console.WriteLine("Vuoi modificare il numero di GB?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                cellulare.MemoriaGB = InserisciMemoriaGB();
            }

            cellulareRepository.Update(cellulare);
        }

        public static Pc SceltaPc()
        {
            List<Pc> computers = pcRepository.Fetch();
            int i = 1;
            foreach (var pc in computers)
            {
                Console.WriteLine($"Premi {i} per selezionare: ");
                pc.PrintInfo();
                i++;
            }

            int pcScelto;
            do
            {
                Console.WriteLine("Quale pc?");

            } while (!int.TryParse(Console.ReadLine(), out pcScelto) || pcScelto <= 0 || pcScelto > computers.Count);

            Console.WriteLine("Hai scelto di modificare");
            return computers.ElementAt(pcScelto - 1);           
        }

        public static void ModificaPc()
        {

            Pc pc = SceltaPc();
            if (pc.Id == null)
            {
                pcRepository.Delete(pc);
            }

            bool continuare = true;
            string risposta;
            do
            {
                Console.WriteLine("Vuoi modificare la marca?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                pc.Marca = InserisciMarca();
            }

            do
            {
                Console.WriteLine("Vuoi modificare il modello?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                pc.Modello = InserisciModello();
            }

            do
            {
                Console.WriteLine("Vuoi modificare la quantità in magazzino?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                pc.QuantitàInMagazzino = InserisciQuantitaMagazzino();
            }

            do
            {
                Console.WriteLine("Vuoi modificare il sistema operativo?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                pc.SistemaOperativo = InsertSistemaOperativo();
            }

            do
            {
                Console.WriteLine("Vuoi modificare il touch screen?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                pc.TouchScreen = InsertTouchScreen();
            }

            pcRepository.Update(pc);
        }

        public static Tv SceltaTv()
        {
            List<Tv> televisori = tvRepository.Fetch();
            int i = 1;
            foreach (var tv in televisori)
            {
                Console.WriteLine($"Premi {i} per selezionare: ");
                tv.PrintInfo();
                i++;
            }

            int tvScelto;
            do
            {
                Console.WriteLine("Quale tv?");

            } while (!int.TryParse(Console.ReadLine(), out tvScelto) || tvScelto <= 0 || tvScelto > televisori.Count);

            Console.WriteLine("Hai scelto di modificare");
            return televisori.ElementAt(tvScelto - 1);
        }

        public static void ModificaTv()
        {

            Tv tv = SceltaTv();
            if (tv.Id == null)
            {
                tvRepository.Delete(tv);
            }

            bool continuare = true;
            string risposta;
            do
            {
                Console.WriteLine("Vuoi modificare la marca?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                tv.Marca = InserisciMarca();
            }

            do
            {
                Console.WriteLine("Vuoi modificare il modello?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                tv.Modello = InserisciModello();
            }

            do
            {
                Console.WriteLine("Vuoi modificare la quantità in magazzino?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                tv.QuantitàInMagazzino = InserisciQuantitaMagazzino();
            }

            do
            {
                Console.WriteLine("Vuoi modificare il numero di pollici?");
                risposta = Console.ReadLine();
                if (risposta == "si" || risposta == "no")
                    continuare = false;
            } while (continuare);
            if (risposta == "si")
            {
                tv.Pollici = InserisciPollici();
            }

            tvRepository.Update(tv);
        }

        //*********************** Elimina Prodotto ***************************
        internal static void CancellaProdotto()
        {
            int prodottoScelto;

            do
            {
                Console.WriteLine("Che prodotto vuoi scegliere?");
                Console.WriteLine("Premi 1 per eliminare un cellulare.");
                Console.WriteLine("Premi 2 per eliminare un pc.");
                Console.WriteLine("Premi 3 per eliminare una tv.");

            } while (!int.TryParse(Console.ReadLine(), out prodottoScelto) || prodottoScelto <= 0 || prodottoScelto >= 4);

            switch (prodottoScelto)
            {
                case 1:
                    EliminaCellulare();

                    break;
                case 2:
                    EliminaPc();

                    break;
                case 3:
                    EliminaTv();

                    break;
            }
        }

        private static void EliminaCellulare()
        {
            Cellulare cellulare = SceltaCellulare();
            cellulareRepository.Delete(cellulare);
        }
        private static void EliminaPc()
        {
            Pc pc = SceltaPc();
            pcRepository.Delete(pc);
        }

        private static void EliminaTv()
        {
            Tv tv = SceltaTv();
            tvRepository.Delete(tv);
        }
    }
}
