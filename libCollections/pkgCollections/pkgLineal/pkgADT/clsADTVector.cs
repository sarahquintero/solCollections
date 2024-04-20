using pkgServicies.pkgCollections.pkgLineal.pkgADT;
using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using System;
using System.Collections.Generic;

namespace pkgServicies.pkgCollections.pkgLineal.pkgVector.pkgADT
{
    public class clsADTVector<T> : clsADTLinked<T>, iADTVector<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attTotalCapacity = 100;
        protected static int attMaxCapacity = int.MaxValue / 16;
        protected T[] attItems = new T[100];
        protected bool attItsFlexible = false;
        protected int attGrowingFactor = 100;
        //private int attLenght;
        #endregion
        #region Operations
        #region Builders
        protected clsADTVector()
        {

        }
        protected clsADTVector(int prmCapacity)
        {
            try
            {
                if (prmCapacity == attMaxCapacity) attGrowingFactor = 0;
                attTotalCapacity = prmCapacity;
                attItems = new T[prmCapacity];
            }
            catch (Exception e)
            {
                base.attLength = 0;
                attItsOrderedAscending = false;
                attItsOrderedDescending = false;
                attTotalCapacity = 100;
                attItems = new T[100];
                attItsFlexible = false;
                attGrowingFactor = 100;
            }
        }
        #endregion
        #region Getters
        public int opGetTotalCapacity()
        {
            return attTotalCapacity;
        }
        public int opGetGrowingFactor()
        {
            if (attItsFlexible)
            {
                return attMaxCapacity / attTotalCapacity;
            }
            else
            {
                return attGrowingFactor;
            }
        }
        public int opGetAvailableCapacity()
        {
            int attLength = attItems.Length;
            int attItemsCount = 0;
            if (attItems[0] != null) attItemsCount++;
            return attLength - attItemsCount;
        }
        public static int opGetMaxCapacity()
        {
            return attMaxCapacity;
        }
        #endregion
        #region Setters
        public bool opSetGrowingFactor(int prmValue)
        {
            attGrowingFactor = prmValue;
            return true;
        }
        public bool opSetCapacity(int prmValue)
        {
            attTotalCapacity = prmValue;
            return true;
        }
        public bool opSetFlexible()
        {
            attItsFlexible = true;
            return true;
        }
        public bool opSetInflexible()
        {
            attItsFlexible = false;
            return false;
        }
        #endregion
        #region Query
        public bool opItsFull()
        {
            throw new NotImplementedException();
        }
        public bool opItsFlexible()
        {
            if (typeof(T).GetInterface(nameof(ICollection<T>)) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #region Serialize/Deserialize
        public override T[] opToArray()
        {
            return attItems;
        }
        public override bool opToItems(T[] prmArray)
        {
            try
            {
                attItems = prmArray;
                attTotalCapacity = prmArray.Length;
                base.attLength = attItems.Length;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public override bool opToItems(T[] prmArray, int prmItemsCount)
        {
            attItems = prmArray;
            attTotalCapacity = prmArray.Length;
            attLength = prmItemsCount;
            return true;
        }
        #endregion
        #endregion
    }
}
