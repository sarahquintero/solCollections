using pkgServicies.pkgCollections.pkgNodes;
using System;

namespace pkgServicies.pkgCollections.pkgLineal.pkgInterfaces
{
    public interface iADTDoubleLinked<T> where T : IComparable<T>
    {
        clsDoubleLinkedNode<T> opGetFirst();
        clsDoubleLinkedNode<T> opGetMiddle();
        clsDoubleLinkedNode<T> opGetLast();
        bool opSetFirst(clsDoubleLinkedNode<T> prmNode);
        bool opSetMiddle(clsDoubleLinkedNode<T> prmNode);
        bool opSetLast(clsDoubleLinkedNode<T> prmNode);
    }
}
