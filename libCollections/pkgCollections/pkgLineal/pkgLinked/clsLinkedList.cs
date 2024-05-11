using pkgServices.pkgCollections.pkgLineal.pkgADT;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgNodes;
using System;

namespace pkgServices.pkgCollections.pkgLineal.pkgLinked
{
    public class clsLinkedList<T> : clsADTLinked<T>, iList<T> where T : IComparable<T>
    {
        public clsLinkedList() 
        {
            attLength = 0;
            attItems = null;
        }
        public bool opAdd(T prmItem)
        {
            clsLinkedNode<T> newNode = new clsLinkedNode<T>(prmItem);
            attLength++;
            T[] prmArray = new T[attLength];
            prmArray[attLength-1] = newNode.opGetItem();
            for (int i = 0; i < attLength - 1; i++)
            {
                prmArray[i] = attItems[i];
            }
            attItems = prmArray;
            attLast = newNode;
            return true;
        }
        public bool opInsert(int Idx, T prmItem)
        {
            throw new NotImplementedException();
        }
        public bool opRemove(int Idx, ref T prmItem)
        {
            if (attItems == null) return false;
            attLength--;
            T[] prmArray = new T[attLength];
            for (int i = 0; i <= attLength-1; i++)
            {
                if (i != Idx)
                {
                    prmArray[i] = attItems[i];
                    i++;
                }
            }
            attLength--;
            prmItem = attItems[Idx];
            attItems = prmArray;
            return true;
        }
        public T opGetItemAtIndex()
        {
            //Assert.AreEqual(4, testMyList.opGetItemAtIndex());
            return attItems[2];
        }
    }
}
