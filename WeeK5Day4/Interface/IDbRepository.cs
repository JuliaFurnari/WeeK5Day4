using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeK5Day4.Interface
{
    interface IDbRepository<T>
    {
        public List<T> Fetch();
        public void Insert(T t);
        public void Delete(T t);
        public void Update(T t);
    }
}
