﻿using System;
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
                if (prmCapacity < 0)
                {
                    prmCapacity = 0;
                }
                if (prmCapacity == 0)
                {
                    prmCapacity = 100;
                    attTotalCapacity = 100;
                    attGrowingFactor = 100;
                }
                attItems = new T[prmCapacity];
                attTotalCapacity = prmCapacity;
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
            if (prmItemsCount == 0)
            {
                return false;
            }
            prmItem = attItems[0];
            Array.Copy(attItems, 1, attItems, 0, prmItemsCount - 1);
            prmItemsCount--;
            return true;
        }
        public bool opPush(T prmItem)
        {
            if (prmItemsCount == attTotalCapacity)
            {
                return false;
            }
            attItems[prmItemsCount] = prmItem;
            prmItemsCount++;
            return true;
        }
        #endregion 
        #endregion
    }
}
