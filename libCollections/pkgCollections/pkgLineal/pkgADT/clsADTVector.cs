using pkgServices.pkgCollections.pkgLineal.pkgADT;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using System;
using System.Collections.Generic;

namespace pkgServices.pkgCollections.pkgLineal.pkgVector.pkgADT
{
    public class clsADTVector<T> : clsADTLineal<T>, iADTVector<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attTotalCapacity = 100;
        //protected static int attMaxCapacity = int.MaxValue / 16;
        //protected T[] attItems = new T[100];
        protected bool attItsFlexible = false;
        protected int attGrowingFactor = 100;
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
            if(attTotalCapacity > int.MaxValue / 16) 
            { 
                attTotalCapacity = 100;
                return attTotalCapacity;
            }
            if (attTotalCapacity < 0)
            {
                attTotalCapacity = 100;
                return attTotalCapacity;
            }
            if (attTotalCapacity == attMaxCapacity)
            {
                attTotalCapacity = attMaxCapacity;
                return attTotalCapacity;
            }
            return attTotalCapacity;
        }
        public int opGetAvailableCapacity()
        {
            return attTotalCapacity - attLength;
            //int attLength = attItems.Length;
            //int attItemsCount = 0;
            //if (attItems[0] != null) attItemsCount++;
            //return attLength - attItemsCount;
        }
        public int opGetGrowingFactor()
        {
            if (attItsFlexible)
            {
                attGrowingFactor = attMaxCapacity / attTotalCapacity;
                return attGrowingFactor;
            }
            else
            {
                if (attMaxCapacity == attTotalCapacity)
                {
                    attGrowingFactor = 0;
                    return attGrowingFactor;
                }
                if ((attMaxCapacity - 1) == attTotalCapacity)
                {
                    attGrowingFactor = 1;
                    return attGrowingFactor;
                }
                if (attTotalCapacity > 0)
                {
                    attGrowingFactor = 100;
                    return attGrowingFactor;
                }
                attGrowingFactor = attTotalCapacity - attLength;
                return attGrowingFactor;
            }
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
            T[] result = new T[attTotalCapacity];
            for (int i = 0; i < attTotalCapacity; i++)
            {
                result[i] = attItems[i];
            }
            return result;
            //return attItems;
        }
        public override bool opToItems(T[] prmArray)
        {
            if (prmArray.Length <= attMaxCapacity)
            {
                attItems = prmArray;
                attLength = attItems.Length;
                attTotalCapacity = attItems.Length;
                if (attMaxCapacity - attLength < 100)
                {
                    attGrowingFactor = attMaxCapacity - attLength;
                }
                attItsOrderedAscending = false;
                attItsOrderedDescending = false;
                return true;
            }
            return false;
        }
        public override bool opToItems(T[] prmArray, int prmItemsCount)
        {
            try
            {
                attItems = prmArray;
                attTotalCapacity = prmArray.Length;
                attLength = prmItemsCount;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            //attItems = prmArray;
            //attTotalCapacity = prmArray.Length;
            //attLength = prmItemsCount;
            //return true;
        }
        #endregion
        #endregion
    }
}
