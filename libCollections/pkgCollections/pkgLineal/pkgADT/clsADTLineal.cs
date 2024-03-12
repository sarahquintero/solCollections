using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgADT
{
    class clsADTLineal<T>: pkgServicies.pkgCollections.pkgLineal.pkgInterfaces.iADTLineal<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attLenght = 0;
        protected bool attItsOrderedAscending = false;
        protected bool attItsOrderedDescending = false;
        #endregion
        #region Getters
        public int opGetLenght()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Query
        public bool opItsEmpty()
        {
            throw new NotImplementedException();
        }

        public int opFind(T prmItem)
        {
            throw new NotImplementedException();
        }

        public int opExists(T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opIsValid()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Serialize/DesSerialize
        public T[] opToArray()
        {
            throw new NotImplementedException();
        }

        public String opToString()
        {
            throw new NotImplementedException();
        }

        public bool opToItems(T[] prmArray)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region CRUDs
        public bool opModify(int prmIdx, T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opRetrieve(int prmIdx, ref T prmItem)
    {
            throw new NotImplementedException();
        }

        public bool opReverse()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
