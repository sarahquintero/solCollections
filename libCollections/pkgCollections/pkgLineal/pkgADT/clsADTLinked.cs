using pkgServicies.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServicies.pkgCollections.pkgNodes;
using System;

namespace pkgServicies.pkgCollections.pkgLineal.pkgADT
{
    public class clsADTLinked<T> : clsADTLineal<T>, iADTLinked<T> where T : IComparable<T>
    {
        #region Attributes
        protected pkgServicies.pkgCollections.pkgNodes.clsLinkedNode<T> attFirst = null;
        protected pkgServicies.pkgCollections.pkgNodes.clsLinkedNode<T> attMiddle = null;
        protected pkgServicies.pkgCollections.pkgNodes.clsLinkedNode<T> attLast = null;
        #endregion
        #region Operations
        #region Builders
        protected clsADTLinked() { }
        #endregion
        #region Getters
        public clsLinkedNode<T> opGetFirst()
        {
            throw new NotImplementedException();
        }
        public clsLinkedNode<T> opGetLast()
        {
            throw new NotImplementedException();
        }
        public clsLinkedNode<T> opGetMiddle()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Setters
        public bool opSetFirst(clsLinkedNode<T> prmNode)
        {
            throw new NotImplementedException();
        }
        public bool opSetLast(clsLinkedNode<T> prmNode)
        {
            throw new NotImplementedException();
        }
        public bool opSetMiddle(clsLinkedNode<T> prmNode)
        {
            throw new NotImplementedException();
        }
        #endregion 
        #endregion
    }
}
