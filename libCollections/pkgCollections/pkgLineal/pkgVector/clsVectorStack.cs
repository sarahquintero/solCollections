using System;
using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorStack<T> : pkgADT.clsADTVector<T>, iStack<T> where T : IComparable<T>
    {
        #region Builders
        public clsVectorStack(int prmCapacity) : base(prmCapacity)
        {
            attItems = new T[prmCapacity];
        }
        public clsVectorStack()
        {
            attTotalCapacity = 100;
            attMaxCapacity = int.MaxValue / 16;
            attItems = new T[100];
            attItsFlexible = false;
            attGrowingFactor = 100;
        }
        #endregion
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
            attItems[0] = prmItem;
            attLength++;
            return true;
        }
        #endregion
    }
}
