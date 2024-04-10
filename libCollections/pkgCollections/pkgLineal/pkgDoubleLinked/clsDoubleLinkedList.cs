using pkgServicies.pkgCollections.pkgLineal.pkgADT;
using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using System;

namespace pkgServicies.pkgCollections.pkgLineal.pkgDoubleLinked
{
    public class clsDoubleLinkedList<T> : clsADTDoubleLinked<T>, iList<T> where T : IComparable<T>
    {
        public bool opAdd(ref T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opInsert(ref int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opRemove(ref int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }
    }
}
