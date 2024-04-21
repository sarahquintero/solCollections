using pkgServicies.pkgCollections.pkgLineal.pkgADT;
using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using System;

namespace pkgServicies.pkgCollections.pkgLineal.pkgLinked
{
    public class clsLinkedList<T> : clsADTLinked<T>, iList<T> where T : IComparable<T>
    {
        public bool opAdd(T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opInsert(int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opRemove(int Idx, ref T prmItem)
        {
            throw new NotImplementedException();
        }
    }
}
