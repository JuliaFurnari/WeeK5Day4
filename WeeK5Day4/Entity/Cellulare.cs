using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeK5Day4.Entity
{
    class Cellulare:Prodotto
    {
        public float MemoriaGB;
        public Cellulare() { }

        public Cellulare(string marca, string modello, int quantitàInMagazzino, float memoriaGB, int? id)
            :base(marca, modello, quantitàInMagazzino, id)
        {
         
            MemoriaGB = memoriaGB;
        }

        public override void PrintInfo()
        {
            Console.Write("\tTipo prodotto: Cellulare");
            base.PrintInfo();
            Console.Write($"\tMemoria (GB): {MemoriaGB}");
        }

    }
}
