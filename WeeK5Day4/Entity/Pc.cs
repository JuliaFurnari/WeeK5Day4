using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeK5Day4.Entity
{
    class Pc:Prodotto
    {
        public Sistema SistemaOperativo;
        public bool TouchScreen;

        public Pc() { }

        public Pc(string marca, string modello, int quantitàInMagazzino, Sistema sistemaOperativo, bool touchScreen, int? id)
            :base(marca, modello, quantitàInMagazzino, id)
        {
            SistemaOperativo = sistemaOperativo;
            TouchScreen = touchScreen;
        }

        public override void PrintInfo()
        {
            Console.Write("\tTipo prodotto: Pc");
            base.PrintInfo();
            Console.Write($"\tSistema operativo: {SistemaOperativo} \tTouch screen: {TouchScreen}");
        }
    }
    public enum Sistema
    {
        Windows,
        Mac,
        Linux
    }
}
