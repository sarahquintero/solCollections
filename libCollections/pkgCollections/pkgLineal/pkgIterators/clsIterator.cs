﻿using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using System;

namespace pkgServicies.pkgCollections.pkgLineal.pkgIterators
{
    public class clsIterator<T> : iIterator<T> where T : IComparable<T>
    {
        #region Attributes
        protected int attLength = 0;
        protected int attCurrentIdx;
        protected T attCurrentItem; 
        #endregion
        #region Operations
        public bool opGoFirst()
        {
            throw new NotImplementedException();
        }

        public bool opGoPrevious()
        {
            throw new NotImplementedException();
        }

        public bool opGoMiddle()
        {
            throw new NotImplementedException();
        }

        public bool opGoNext()
        {
            throw new NotImplementedException();
        }

        public bool opGoLast()
        {
            throw new NotImplementedException();
        }

        public int opGetCurrentIdx()
        {
            throw new NotImplementedException();
        }

        public T opGetCurrentItem()
        {
            throw new NotImplementedException();
        }

        public bool opGo(int prmIdx)
        {
            throw new NotImplementedException();
        }

        public bool opIsValid(int prmIdx)
        {
            throw new NotImplementedException();
        }

        public bool SetCurrentItem(T prmContent)
        {
            throw new NotImplementedException();
        }

        public bool opIsThereNext()
        {
            throw new NotImplementedException();
        }

        public bool IsTherePrevious()
        {
            throw new NotImplementedException();
        }

        public int opGetLenght()
        {
            throw new NotImplementedException();
        }

        public void opGoBack()
        {
            throw new NotImplementedException();
        }

        public void opGoForward()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
