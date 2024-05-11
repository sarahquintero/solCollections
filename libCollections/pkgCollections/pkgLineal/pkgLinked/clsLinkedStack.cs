using pkgServices.pkgCollections.pkgLineal.pkgADT;
using pkgServices.pkgCollections.pkgLineal.pkgInterfaces;
using pkgServices.pkgCollections.pkgNodes;
using System;
using System.Xml.Linq;

namespace pkgServices.pkgCollections.pkgLineal.pkgLinked
{
    public class clsLinkedStack<T> : clsADTLinked<T>, iStack<T> where T : IComparable<T>
    {
        #region Builders
        public clsLinkedStack()
        {
            attLength = 0;
            attItems = null;
        }
        public clsLinkedStack(int prmCapacity)
        {
            try
            {
                if (prmCapacity < 0)
                {
                    prmCapacity = 100;
                    attTotalCapacity = 100;
                }
                if (prmCapacity == 0)
                {
                    prmCapacity = 100;
                    attTotalCapacity = 100;
                }
                if (attLength < 0) attLength = 0;
                attItems = new T[prmCapacity];
            }
            catch
            {
                attTotalCapacity = 100;
                attMaxCapacity = int.MaxValue / 16;
                attItems = new T[100];
            }
        }
        #endregion
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
            clsLinkedNode<T> newNode = new clsLinkedNode<T>(prmItem);   
            if (attFirst == null)
            {
                attLength ++;
                T[] array = new T[attLength];
                attItems = array;
                attItems[0] = newNode.opGetItem();
                attFirst = newNode;
                return true;
            }
            attLength++;
            T[] prmArray = new T[attLength];
            prmArray[0] = newNode.opGetItem();
            for (int i = 0; i < attLength-1; i++)
            {
                prmArray[i + 1] = attItems[i];
            }
            attItems = prmArray;
            attFirst = newNode;
            return true;
        }
        public T opGetItemAtIndex()
        {
            return attItems[2];
        }
    }
}
