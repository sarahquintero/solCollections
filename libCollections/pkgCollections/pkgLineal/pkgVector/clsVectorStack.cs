using System;
using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServicies.pkgCollections.pkgLineal.pkgVector.pkgADT;

namespace pkgServicies.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorStack<T> : clsADTVector<T>, iStack<T> where T : IComparable<T>
    {
        #region Builders
        public clsVectorStack()
        {

        }
        public clsVectorStack(int prmCapacity) : base(prmCapacity)
        {
            try
            {
                if (attLength < 0) attLength = 0;
                attItems = new T[prmCapacity];
            }
            catch
            {
                attTotalCapacity = 100;
                attMaxCapacity = int.MaxValue / 16;
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
                return false;
            }
            prmItem = attItems[prmItemsCount - 1];
            return true;
        }

        public bool opPop(ref T prmItem)
        {
            if (prmItemsCount == 0)
            {
                return false;
            }
            prmItem = attItems[prmItemsCount - 1];
            prmItemsCount--;

            return true;
        }

        public bool opPush(T prmItem)
        {
            try
            {
                if (prmItemsCount >= attTotalCapacity)
                {
                    return false;
                }
                else
                {
                    for (int i = prmItemsCount; i > 0; i--)
                    {
                        attItems[i] = attItems[i - 1];
                    }
                    attItems[0] = prmItem;
                    prmItemsCount++;
                    attLength++;
                    return true;
                }
            }
            catch
            {
                return false;
            }
            //attItems[0] = prmItem;
            //attLength++;
            //return true;
        }
        #endregion
    }
}
