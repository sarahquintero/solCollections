using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgVector.pkgADT
{
    class clsADTVector<T>: clsADTLineal<T>, iADTVector<T> where T: IComparable<T>
    {
        protected int attCapacity;
        protected T[] Items;

        public int opGetCapacity()
        {
            throw new NotImplementedException();
        }
    }
}
