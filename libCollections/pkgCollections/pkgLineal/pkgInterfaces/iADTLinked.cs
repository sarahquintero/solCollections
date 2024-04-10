using pkgServicies.pkgCollections.pkgNodes;
using System;

namespace pkgServicies.pkgCollections.pkgLineal.pkgInterfaces
{
    public interface iADTLinked<T> where T : IComparable<T>
    {
        clsLinkedNode<T> opGetFirst();
        clsLinkedNode<T> opGetMiddle();
        clsLinkedNode<T> opGetLast();
        bool opSetFirst(clsLinkedNode<T> prmNode);
        bool opSetMiddle(clsLinkedNode<T> prmNode);
        bool opSetLast(clsLinkedNode<T> prmNode);
    }
}
