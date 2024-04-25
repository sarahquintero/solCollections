using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgLineal.pkgVector.pkgADT;
using System;
using System.ComponentModel;
using System.Linq;

namespace pkgServices.pkgCollections.pkgLineal.pkgADT
{
    public class clsADTLineal<T>: iADTLineal<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attLength = 0;
        protected bool attItsOrderedAscending = false;
        protected bool attItsOrderedDescending = false;
        //protected int prmItemsCount = 0;
        protected T[] prmArray = new T[100];
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
                T[] prmArray = new T[attLength];
            }
            catch (Exception e)
            {
                T[] prmArray = new T[attLength];
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
            T[] prmArray = new T[attLength];
            for (int i = 1; i < attLength; i++)
            {
                if (prmArray[i].CompareTo(prmArray[i - 1]) >= 0)
                {
                    attItsOrderedAscending = true;
                    return attItsOrderedAscending;
                }
            }
            attItsOrderedAscending = false;
            return attItsOrderedAscending;
        }
        public bool opItsOrderedDescending()
        {
            T[] prmArray = new T[attLength];
            for (int i = 1; i < attLength; i++)
            {
                if (prmArray[i].CompareTo(prmArray[i - 1]) >= 0)
                {
                    attItsOrderedAscending = true;
                    return attItsOrderedDescending;
                }
            }
            attItsOrderedDescending = false;
            return attItsOrderedDescending;
        }
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
        public bool opModify(int prmIdx, T prmItem)
        {
            int prmItemsCount = 0;
            T[] prmArray = new T[attLength];
            if (prmIdx >= 0 && prmIdx < prmItemsCount)
            {
                prmArray[prmIdx] = prmItem;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool opRetrieve(int prmIdx, ref T prmItem)
        {
            int prmItemsCount = 0;
            T[] prmArray = new T[attLength];
            if (prmIdx >= 0 && prmIdx < prmItemsCount)
            {
                prmItem = prmArray[prmIdx];
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
