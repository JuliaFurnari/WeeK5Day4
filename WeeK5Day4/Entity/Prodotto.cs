using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeK5Day4.Entity
{
    class Prodotto
    {
        public string Marca;
        public string Modello;
        public int QuantitàInMagazzino;
        public int? Id;

        public Prodotto() { }
        public Prodotto(string marca, string modello, int quantitàInMagazzino, int? id)
        {
            Marca = marca;
            Modello = modello;
            QuantitàInMagazzino = quantitàInMagazzino;
            Id = id;
        }

        public virtual void PrintInfo()
        {
            Console.Write($"\tMarca: {Marca} \tModello: {Modello} \tQuantità in magazzino: {QuantitàInMagazzino}");
        }
    }
}
