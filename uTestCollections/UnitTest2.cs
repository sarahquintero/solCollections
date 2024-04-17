using Microsoft.VisualStudio.TestTools.UnitTesting;
using pkgServicies.pkgCollections.pkgLineal.pkgVector;

namespace uTestCollections
{
    [TestClass]
    public class uTestVectorQueue
    {
        private clsVectorQueue<int> testMyQueue;
        private int[] testExpectedItems;
        private int testExpectedItem;
        //cambiar push
        #region BuildersTests
        [TestMethod]
        public void testDefaultConstructor()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>();
            #endregion
            #region Test & Assert
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(100, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testValidCapacityConstructor()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>(100);
            #endregion
            #region Test & Assert
            Assert.AreEqual(100, testMyQueue.opGetTotalCapacity());
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            CollectionAssert.AreEqual(new int[100], testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testNegativeCapacityConstructor()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>(-1);
            #endregion
            #region Test & Assert
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(100, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testOverFlowCapacityConstructor()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>(int.MaxValue);
            #endregion
            #region Test & Assert
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(100, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[100], testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testBehindMaxCapacityConstructor()
        {
            #region Setup
            testMyQueue = new clsVectorQueue<int>(clsVectorQueue<int>.opGetMaxCapacity() - 1);
            #endregion
            #region Test & Assert
            Assert.AreEqual(0, testMyQueue.opGetLength());
            Assert.IsFalse(testMyQueue.opItsOrderedAscending());
            Assert.IsFalse(testMyQueue.opItsOrderedDescending());
            Assert.AreEqual(100, testMyQueue.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[clsVectorQueue<int>.opGetMaxCapacity() - 1], testMyQueue.opToArray());
            Assert.IsFalse(testMyQueue.opItsFlexible());
            Assert.AreEqual(100, testMyQueue.opGetGrowingFactor());
            #endregion
        }
        #endregion
    }
}