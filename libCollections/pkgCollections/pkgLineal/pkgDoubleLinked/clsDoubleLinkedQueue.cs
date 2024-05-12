﻿using pkgServices.pkgCollections.pkgLineal.pkgADT;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgDoubleLinked
{
    public class clsDoubleLinkedQueue<T> : clsADTDoubleLinked<T>, iQueue<T> where T : IComparable<T>
    {
        public clsDoubleLinkedQueue() 
        {
            attLength = 0;
            attItems = null;
        }
        #region CRUDs
        public bool opPeek(ref T prmItem)
        {
            if (attItems == null) return false;
            prmItem = attItems[0];
            return true;
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
