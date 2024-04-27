using System;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgLineal.pkgVector.pkgADT;

namespace pkgServices.pkgCollections.pkgLineal.pkgVector
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
                if (prmCapacity < 0) prmCapacity = 0;
                if (prmCapacity == 0)
                {
                    prmCapacity = 100;
                    attTotalCapacity = 100;
                    attGrowingFactor = 100;
                }
                if (prmCapacity == attMaxCapacity - 1)
                {
                    attTotalCapacity = prmCapacity;
                    //attLength = (attMaxCapacity - 1);
                }
                attItems = new T[prmCapacity];
                attTotalCapacity = prmCapacity;
            }
            catch
            {
                attTotalCapacity = 100;
                attMaxCapacity = int.MaxValue / 16;//134217727
                attItems = new T[100];
                attItsFlexible = false;
                attGrowingFactor = 100;
            }
        }
        #endregion
        #region CRUDs
        public bool opPeek(ref T prmItem)
        {
            if (attLength == 0)
            {
                prmItem = default;
                return false;
            }
            else
            {
                prmItem = attItems[attLength - 1];
                return true;
            }
        }
        public bool opPop(ref T prmItem)
        {
            if (attLength == 0)
            {
                return false;
            }
            prmItem = attItems[0];
            for (int i = attLength; i >= 1; i--)
            {
                attItems[i] = attItems[i - 1];
            }
            attLength--;
            return true;
            //prmItem = attItems[0];
            //Array.Copy(attItems, 1, attItems, 0, attLength - 1);
            //attLength--;
            //return true;
        }
        public bool opPush(T prmItem)
        {
            if (attLength == attTotalCapacity)
            {
                return false;
            }
            if (attMaxCapacity == attTotalCapacity)
            {
                //if (attItsFlexible == false) attLength = attMaxCapacity - 1;
                //attLength = attTotalCapacity;
                attItems[attTotalCapacity-1] = prmItem;
                attLength++;
                return true;
            }
            attItems[attLength] = prmItem;
            attLength  ++;
            return true;
        }
        public T opFirst()
        {
            return attItems[0];
        }
        #endregion 
        #endregion
    }
}
