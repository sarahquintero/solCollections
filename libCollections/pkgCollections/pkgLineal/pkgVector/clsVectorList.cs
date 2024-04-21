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
            attItems = new T[prmCapacity];
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
