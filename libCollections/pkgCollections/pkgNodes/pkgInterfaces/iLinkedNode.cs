using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pkgServicies.pkgCollections.pkgNodes.pkgInterfaces
{
    public interface iLinkedNode<T> where T : IComparable<T>
    {
        clsLinkedNode<T> opGetNext();
        bool opSetNext(clsLinkedNode<T> prmNode);
    }
}
