using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServicies.pkgCollections.pkgLineal.pkgVector.pkgADT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorList<T> : clsADTVector<T> , iList<T> where T : IComparable<T>
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
        public bool opAdd(ref T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opExists(T Item)
        {
            throw new NotImplementedException();
        }

        public int opFind(T Item)
        {
            throw new NotImplementedException();
        }

        public bool opInsert(ref int Idx, T prmItem)
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
