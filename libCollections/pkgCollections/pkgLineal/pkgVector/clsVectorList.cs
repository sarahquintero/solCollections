using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgLineal.pkgVector.pkgADT;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorList<T> : clsADTVector<T>, iList<T> where T : IComparable<T>
    {
        #region Attributes
        //protected T[] attItems = new T[100]; 
        #endregion
        #region Builders
        public clsVectorList()
        {

        }
        public clsVectorList(int prmCapacity)
        {
            try
            {
                if (prmCapacity < 0)
                {
                    prmCapacity = 100;
                    attTotalCapacity = 100;
                }
                if (prmCapacity == 0)
                {
                    prmCapacity = 100;
                    attTotalCapacity = 100;
                    attGrowingFactor = 100;
                }
                if (prmCapacity == attMaxCapacity)
                {
                    prmCapacity = attMaxCapacity;
                    attTotalCapacity = attMaxCapacity;
                    attGrowingFactor = 0;
                }
                if (prmCapacity == (attMaxCapacity - 1))
                {
                    attGrowingFactor = 1;
                    attTotalCapacity = (attMaxCapacity - 1);
                }

                if (attLength < 0) attLength = 0;
                attItems = new T[prmCapacity];
                attTotalCapacity = prmCapacity;
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
        public bool opAdd(T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opInsert(int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opRemove(int Idx, ref T prmItem)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Query
        public bool opModify(ref int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opRemove(ref int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
