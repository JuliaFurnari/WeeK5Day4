using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeK5Day4.Entity
{
    class Tv:Prodotto
    {
        public int Pollici;
       

        public Tv() { }

        public Tv(string marca, string modello, int quantitàInMagazzino, int pollici, int? id)
            : base(marca, modello, quantitàInMagazzino, id)
        {
            Pollici = pollici;       
        }

        public override void PrintInfo()
        {
            Console.Write("\tTipo prodotto: Tv");
            base.PrintInfo();
            Console.Write($"\tPollici: {Pollici} ");
        }
    }
}
