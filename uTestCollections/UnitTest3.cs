using Microsoft.VisualStudio.TestTools.UnitTesting;
using pkgServicies.pkgCollections.pkgLineal.pkgVector;
using System;

namespace uTestCollections
{
    [TestClass]
    public class uTestVectorList
    {
        private clsVectorList<int> testMyList;
        [TestMethod]
        public void testDefaultConstructor()
        {
            #region Setup
            testMyList = new clsVectorList<int>();
            #endregion
            #region Test & Assert
            Assert.AreEqual(0, testMyList.opGetLength());
            Assert.IsFalse(testMyList.opItsOrderedAscending());
            Assert.IsFalse(testMyList.opItsOrderedDescending());
            Assert.AreEqual(100, testMyList.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyList.opToArray());
            Assert.IsFalse(testMyList.opItsFlexible());
            Assert.AreEqual(100, testMyList.opGetGrowingFactor());
            #endregion
        }
    }
}
