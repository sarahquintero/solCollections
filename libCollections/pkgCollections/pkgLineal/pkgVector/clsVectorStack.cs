﻿using System;
using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgLineal.pkgVector
{
    public class clsVectorStack<T> : clsADTVector<T>, iStack<T> where T : IComparable<T>
    {
        #region CRUDs
		public bool opPeek(ref T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opPop(ref T prmItem)
        {
            throw new NotImplementedException();
        }

        public bool opPush(T prmItem)
        {
            throw new NotImplementedException();
        } 
	#endregion

        #region Builders
		public clsVectorStack(int prmCapacity)
        {
            throw new NotImplementedException();
        }

        public clsVectorStack()
        {
            throw new NotImplementedException();+
        } 
	#endregion
    }
}
