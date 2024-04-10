using pkgServicies.pkgCollections.pkgLineal.pkgADT;
using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using System;

namespace pkgServicies.pkgCollections.pkgLineal.pkgDoubleLinked
{
    public class clsDoubleLinkedQueue<T> : clsADTDoubleLinked<T>, iQueue<T> where T : IComparable<T>
    {
        #region CRUDs
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
        #endregion
    }
}
