using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorList<T> : iList<T> where T : IComparable<T>
    {
        protected clsVectorList()
        {

        }

        public bool opAdd(ref T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opExists(T Item)
        {
            throw new NotImplementedException();
        }

        public int opFind(T Item)
        {
            throw new NotImplementedException();
        }

        public bool opInsert(ref int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opModify(ref int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opRemove(ref int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }
    }
}
