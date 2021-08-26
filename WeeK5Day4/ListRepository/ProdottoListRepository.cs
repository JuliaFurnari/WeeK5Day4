using System;
using System.Collections.Generic;
using System.Linq;
using WeeK5Day4.Entity;
using WeeK5Day4.Interface;
using System.Text;
using System.Threading.Tasks;

namespace WeeK5Day4.ListRepository
{
    class ProdottoListRepository : IProdottiRepository
    {
        static List<Prodotto> prodotti = new List<Prodotto>();

        public static CellulareListRepository cellulariRepository = new CellulareListRepository();
        public static PcListRepository pcRepository = new PcListRepository();
        public static TvListRepository tvRepository = new TvListRepository();
        public void Delete(Prodotto t)
        {
            throw new NotImplementedException();
        }

        public List<Prodotto> Fetch()
        {
            if (prodotti.Count() > 0)
            {
                prodotti.Clear();
            }

            prodotti.AddRange(cellulariRepository.Fetch());
            prodotti.AddRange(pcRepository.Fetch());
            prodotti.AddRange(tvRepository.Fetch());

            return prodotti;
        }

        public void Insert(Prodotto t)
        {
            throw new NotImplementedException();
        }

        public void Update(Prodotto t)
        {
            throw new NotImplementedException();
        }
    }
}
