using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgVector.pkgADT
{
    public class clsADTVector<T>: clsADTLineal<T>, iADTVector<T> where T: IComparable<T>
    {
        #region Builders
        protected clsADTVector()
        {
            try
            {
                if(prmCapacity == attMaxCapacity) attGrowingFactor = 0;
                attCapacity = prmCapacity;
                attItems = new T(prmCapacity);
            }
            catch (Exception e)
            {
                attLenght = 0;
                attItsOrderedAscending = false;
                attItsOrderedDescending = false;
                attCapacity = 100;
                attItems = new T[100];
                attItsFlexible = false;
                attGrowingFactor = 100;
            }
            
        }
        protected clsADTVector(int prmCapacity)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Attributes
        protected int attCapacity = 100;
        protected int attMaxCapacity = int.MaxValue/16;
        protected T[] attItems = new T[100];
        protected bool attItsFlexible = false;
        protected int attGrowingFactor = 100;
        #endregion
        #region Getters
        public int opGetCapacity()
        {
            return attCapacity;
        }
        public int opGetGrowingFactor()
        {
            return attGrowingFactor;
        }
        public int opGetAvailableCapacity()
        {
            throw new NotImplementedException;
        }
        public int opGetMaxCapacity()
        {
            return attMaxCapacity;
        }
        #endregion
        #region Setters
        public void opSetCapacity(int prmItem)
        {
            attCapacity = prmItem;
        }
        public void opSetMaxCapacity(int prmItem)
        {
            attMaxCapacity = prmItem;
        }
        public void opSetItems(int attIdx, int prmItem)
        {
            if (attIdx >= 0 && attIdx < )
            {

            }
        }

        #endregion
    }
}
