using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgInterfaces
{
    public interface iADTVector<T> where T : IComparable<T>
    {
        #region Getters
        int opGetTotalCapacity();
        int opGetAvailableCapacity();
        int opGetGrowingFactor();
        #endregion
        #region Setters
        bool opSetGrowingFactor(int prmValue);
        bool opSetCapacity(int prmValue);
        #endregion
        #region Query
        bool opItsFull();
        bool opItsFlexible();
        #endregion
    }
}
