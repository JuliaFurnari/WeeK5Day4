using System;
using System.Collections.Generic;
using System.Linq;
using WeeK5Day4.Entity;
using WeeK5Day4.Interface;
using System.Text;
using System.Threading.Tasks;

namespace WeeK5Day4.ListRepository
{
    class PcListRepository : IPcRepository
    {
        public static List<Pc> computers = new List<Pc>
        {
            new Pc("HP", "14s", 10, Sistema.Windows, false, null),
            new Pc("Dell", "5401", 5, Sistema.Linux, true, null),
            new Pc("Apple", "Air 13", 15, Sistema.Mac, true, null),
        };
        public void Delete(Pc t)
        {
            computers.Remove(t);
        }

        public List<Pc> Fetch()
        {
            return computers;
        }

        public void Insert(Pc t)
        {
            computers.Add(t);
        }

        public void Update(Pc t)
        {
            Insert(t);
        }
    }
}
