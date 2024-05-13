﻿using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgLineal.pkgIterators;
using pkgServices.pkgCollections.pkgLineal.pkgLinked;
using System;
using System.Collections.Generic;
using System.Linq;

namespace pkgServices.pkgCollections.pkgLineal.pkgADT
{
    public class clsADTLineal<T>: clsIterator<T>, iADTLineal<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attTotalCapacity = 100;
        protected bool attItsOrderedAscending = false;
        protected bool attItsOrderedDescending = false;
        protected static int attMaxCapacity = int.MaxValue / 16;
        protected T[] attItems = new T[100];
        #endregion
        #region Builders
        public clsADTLineal()
        {
        }
        public clsADTLineal(int attLength)
        {
            try
            {
                if (attLength < 0) attLength = 0;
                T[]attItems = new T[attLength];
            }
            catch
            {
                T[] attItems = new T[attLength];
                attLength = 0;
                attItsOrderedAscending = false;
                attItsOrderedDescending = false;
            }
        }
        #endregion
        #region Operations
        #region Query
        public bool opItsEmpty()
        {
            throw new NotImplementedException();
        }
        public int opFind(T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opExists(T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opItsOrderedAscending()
        {
            if (attItems == null) return false;
            if (attItems.All(item => item.Equals(default(T))))
            {
                return false;
            }
            HashSet<T> uniqueElements = new HashSet<T>();
            for (int i = 0; i < attLength; i++)
            {
                if (EqualityComparer<T>.Default.Equals(attItems[i], default(T)))
                {
                    return false;
                }
                if (!uniqueElements.Add(attItems[i]))
                {
                    return false;
                }
            }
            for (int i = 1; i < attLength; i++)
            {
                if (Comparer<T>.Default.Compare(attItems[i], attItems[i - 1]) <= 0)
                {
                    return false;
                }
            }
            return false;
        }
        public bool opItsOrderedDescending()
        {
            if (attItems == null) return false;
            if (attItems.All(item => item.Equals(default(T))))
            {
                return false;
            }
            HashSet<T> uniqueElements = new HashSet<T>();
            for (int i = 0; i < attLength; i++)
            {
                if (EqualityComparer<T>.Default.Equals(attItems[i], default(T)))
                {
                    return false;
                }
                if (!uniqueElements.Add(attItems[i]))
                {
                    return false;
                }
            }
            for (int i = 1; i < attLength; i++)
            {
                if (Comparer<T>.Default.Compare(attItems[i], attItems[i - 1]) >= 0)
                {
                    return false;
                }
            }
            return false;
        }
        #endregion
        #region Getters
        public int opGetLength()
        {
            return attLength;
        }
        public static int opGetMaxCapacity()
        {
            return attMaxCapacity;
        }
        #endregion
        #region Serialize/Deserialize
        public virtual T[] opToArray()
        {
            if (attItems == null)
            {
                return null;
            }
            if (attLength == 0) 
            {
                T[] prmArray = new T[100];
                for (int i = 0; i < 100; i++)
                {
                    prmArray[i] = attItems[i];
                }
                return prmArray;
            }
            if (attLength != attItems.Length)
            {
                T[] array = new T[attLength+1];
                for (int i = 0; i < attLength+1; i++)
                {
                    array[i] = attItems[i];
                }
                return array;
            }
            T[] result = new T[attLength];
            for (int i = 0; i < attLength; i++)
            {
                result[i] = attItems[i];
            }
            return result;
        }
        public String opToString()
        {
            throw new NotImplementedException();
        }
        public virtual bool opToItems(T[] prmArray)
        {
            throw new NotImplementedException();
        }
        public virtual bool opToItems(T[] prmArray, int prmItemsCount)
        {
            throw new NotImplementedException();
        }
        //bool opToItems(T[] prmArray, bool prmItsOrderedAscending);
        #endregion
        #region CRUDs
        public virtual bool opModify(int prmIdx, T prmItem)
        {
            if (!opGo(prmIdx)) return false;
            return opSetCurrentItem(prmItem);
        }
        public virtual bool opRetrieve(int prmIdx, ref T prmItem)
        {
            if (attItems == null) return false;
            if (prmIdx >= 0 && prmIdx < attLength)
            {
                prmItem = attItems[prmIdx];
                return true;
            }
            else
            {
                prmItem = default(T);
                return false;
            }
        }
        public bool opReverse()
        {
            T[] prmArray = new T[attLength];
            prmArray.Reverse();
            return true;
        }
        public int opGetLength(T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opItsValid(int prmIndex)
        {
            throw new NotImplementedException();
        }
        public bool opItsValid()
        {
            throw new NotImplementedException();
        }
        #endregion 
        #endregion
    }
}
