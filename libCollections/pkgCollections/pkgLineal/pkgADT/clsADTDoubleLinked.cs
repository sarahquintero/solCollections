using pkgServicies.pkgCollections.pkgNodes;
using System;
using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;

namespace pkgServicies.pkgCollections.pkgLineal.pkgADT
{
    public class clsADTDoubleLinked<T> : clsADTLineal<T>, iADTDoubleLinked<T> where T : IComparable<T>
    {
        #region Attributes
        protected clsDoubleLinkedNode<T> attFirst;
        protected clsDoubleLinkedNode<T> attMiddle;
        protected clsDoubleLinkedNode<T> attLast;
        #endregion
        #region Operations
        #region Builders
        protected clsADTDoubleLinked()
        {
        }
        #endregion
        #region Getters
        public clsDoubleLinkedNode<T> opGetFirst()
        {
            throw new NotImplementedException();
        }
        public clsDoubleLinkedNode<T> opGetLast()
        {
            throw new NotImplementedException();
        }
        public clsDoubleLinkedNode<T> opGetMiddle()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Setters
        public bool opSetFirst(clsDoubleLinkedNode<T> prmNode)
        {
            throw new NotImplementedException();
        }
        public bool opSetLast(clsDoubleLinkedNode<T> prmNode)
        {
            throw new NotImplementedException();
        }
        public bool opSetMiddle(clsDoubleLinkedNode<T> prmNode)
        {
            throw new NotImplementedException();
        }
        #endregion 
        #endregion
    }
}
