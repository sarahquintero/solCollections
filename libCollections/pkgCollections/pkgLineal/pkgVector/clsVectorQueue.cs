using System;
using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pkgServicies.pkgCollections.pkgLineal.pkgVector.pkgADT;

namespace pkgServicies.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorQueue<T> : clsADTVector<T>, iQueue<T> where T : IComparable<T>
    {
        #region Attributes
        //protected T[] attItems = new T[100];
        #region Builders
        protected clsVectorQueue()
        {

        }
        protected clsVectorQueue(int prmCapacity)
        {
            attItems = new T[prmCapacity];
        }
        #endregion
        #endregion
        #region CRUDs
        public bool opPeek(ref T prmItem)
        {
            return true;
        }
        public bool opPop(ref T prmItem)
        {
            return true;
        }
        public bool opPush(T prmItem)
        {
            return true;
        } 
        #endregion
    }
}
