using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeeK5Day4.Entity;
using WeeK5Day4.Interface;
using System.Threading.Tasks;

namespace WeeK5Day4.ListRepository
{
    class TvListRepository : ITvRepository
    {
        public static List<Tv> televisori = new List<Tv>
        {
            new Tv("Samsung", "UE24", 3, 24, null),
            new Tv("LG", "32ML", 7, 32, null),
            new Tv("Samsung", "UE43", 10, 43, null),
        };
        public void Delete(Tv t)
        {
            televisori.Remove(t);
        }

        public List<Tv> Fetch()
        {
            return televisori;
        }

        public void Insert(Tv t)
        {
            televisori.Add(t);
        }

        public void Update(Tv t)
        {
            Insert(t);
        }
    }
}
