using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgInterfaces
{
    interface iADTVector<T> where T : IComparable<T>
    {
        int opGetCapacity();
    }
}
