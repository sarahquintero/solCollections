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

        }
        protected clsADTVector(int prmCapacity)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Attributes
        protected int attCapacity = 100;
        protected T[] attItems = new T[100];
        protected bool attItsFlexible = false;
        protected int attGrowingFactor = 100;
        #endregion

        #region Getters
        public int opGetCapacity()
        {
            return attCapacity;
        }
        #endregion
    }
}
