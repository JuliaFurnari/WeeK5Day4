using System;
using System.Collections.Generic;
using System.Linq;
using WeeK5Day4.Entity;
using WeeK5Day4.Interface;
using System.Text;
using System.Threading.Tasks;

namespace WeeK5Day4.ListRepository
{
    class CellulareListRepository : ICellulariRepository
    {
        public static List<Cellulare> cellulari = new List<Cellulare>
        {
            new Cellulare("Nokia", "3310", 3, 0.5f, null),
            new Cellulare("Wiko", "F300", 4, 0.2f, null),
            new Cellulare("Brondi", "President", 8, 1, null),
        };
        public void Delete(Cellulare t)
        {
            cellulari.Remove(t);
        }

        public List<Cellulare> Fetch()
        {
            return cellulari;
        }

        public void Insert(Cellulare t)
        {
            cellulari.Add(t);
        }

        public void Update(Cellulare t)
        {
            Insert(t);
        }
    }
}
