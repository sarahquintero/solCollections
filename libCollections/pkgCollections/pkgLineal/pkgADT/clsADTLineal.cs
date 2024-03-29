﻿using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgADT
{
    public class clsADTLineal<T>: iADTLineal<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attLength = 0;
        protected bool attItsOrderedAscending = false;
        protected bool attItsOrderedDescending = false;
        private int prmItemsCount = 0;
        private T[] prmArray;
        #endregion
        #region Getters
        public int opGetLength()
        {
            return attLength;
        }
        #endregion
        #region Serialize/Deserialize
        public virtual T[] opToArray()
        {
            throw new NotImplementedException();
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
        #endregion
        #region CRUDs
        public bool opModify(int prmIndex, T prmItem)
        {
            if (prmIndex >= 0 && prmIndex < prmItemsCount)
            {
                prmArray[prmIndex] = prmItem;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool opRetrieve(int prmIndex, ref T prmItem)
        {
            if (prmIndex >= 0 && prmIndex < prmItemsCount)
            {
                prmItem = prmArray[prmIndex];
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
            prmArray.Reverse();
            return true;
        }
        public int opGetLength(T prmItem)
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
        public bool opItsEmpty()
        {
            throw new NotImplementedException();
        }
        public bool opItsValid(int prmIndex)
        {
            throw new NotImplementedException();
        }
        public bool opItsOrderedAscending()
        {
            for (int i = 0; i < (attLength - 1); i++)
            {
                if (prmArray[i].CompareTo(prmArray[i + 1]) > 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool opItsOrderedDescending()
        {
            for (int i = 0; i < prmArray.Length - 1; i++)
            {
                if (prmArray[i].CompareTo(prmArray[i + 1]) < 0)
                {
                    return false;
                }
            }
            return true;
        }
        public bool opItsValid()
        {
            throw new NotImplementedException();
        }
        //public bool opSetCapacity(int prmValue)
        //{
        //    attTotalCapacity = prmValue;
        //   return true;
        //}
        #endregion
    }
}
