using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pkgServicies.pkgCollections.pkgLineal.pkgADT;
using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;

namespace pkgServicies.pkgCollections.pkgLineal.pkgDoubleLinked
{
    public class clsDoubleLinkedStack<T> : clsADTDoubleLinked<T>, iStack<T> where T : IComparable<T>
    {
        public bool opPeek(ref T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opPop(ref T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opPush(T prmItem)
        {
            throw new NotImplementedException();
        }
    }
}
