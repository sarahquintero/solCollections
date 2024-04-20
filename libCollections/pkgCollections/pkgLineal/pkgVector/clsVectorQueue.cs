using System;
using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServicies.pkgCollections.pkgLineal.pkgVector.pkgADT;

namespace pkgServicies.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorQueue<T> : clsADTVector<T>, iQueue<T> where T : IComparable<T>
    {
        #region Attributes
        //protected T[] attItems = new T[100];
        #endregion
        #region Operations
        #region Builders
        public clsVectorQueue()
        {

        }
        public clsVectorQueue(int prmCapacity)
        {
            try
            {
                if (prmCapacity == attMaxCapacity) attGrowingFactor = 0;
                if (prmCapacity < 0)
                {
                    prmCapacity = 0;
                }
                else
                {
                    attItems = new T[prmCapacity];
                    attTotalCapacity = prmCapacity;
                }
            }
            catch
            {
                attTotalCapacity = 100;
                attMaxCapacity = int.MaxValue / 16;//134,217,727.9375
                attItems = new T[100];
                attItsFlexible = false;
                attGrowingFactor = 100;
            }
        }
        #endregion
        #region CRUDs
        public bool opPeek(ref T prmItem)
        {
            if (prmItemsCount == 0)
            {
                // La cola está vacía, no hay elementos para consultar
                return false;
            }

            prmItem = attItems[0];  // Obtiene el primer elemento de la cola
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
        #endregion
    }
}
