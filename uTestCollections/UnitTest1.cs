using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using pkgServices.pkgCollections.pkglineal.pkgVector;

namespace uTestCollections
{
    [TestClass]
    public class uTestVectorStack
    {
        [TestMethod]
        private clsVectorStack<int> testMyStack;

        [TestMethod]
        public void testDefaultConstructor()
        {
            #region Setup

            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>();
            Assert.AreEqual(0, testMyStack.opLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetCapacity());
            CollectionAssert.AreEqual(new int[100], testMyStack.opToArray);
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testValidCapacityConstructor()
        {
            #region Setup

            #endregion
            #region Test & Assert

            #endregion
        }
        [TestMethod]
        public void testNegativeCapacityConstructor()
        {
            #region Setup

            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>(-1);
            Assert.AreEqual(0, testMyStack.opLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetCapacity());
            CollectionAssert.AreEqual(new int[100], testMyStack.opToArray);
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testOverFlowCapacityConstructor()
        {
            #region Setup

            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>(int.MaxValue);
            Assert.AreEqual(0, testMyStack.opLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetCapacity());
            CollectionAssert.AreEqual(new int[100], testMyStack.opToArray);
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testZeroCapacityConstructor()
        {
            #region Setup

            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>(0);
            Assert.AreEqual(0, testMyStack.opLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetCapacity());
            CollectionAssert.AreEqual(new int[100], testMyStack.opToArray);
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testMaxCapacityConstructor()
        {
            #region Setup

            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>(int.MaxValue/16);
            Assert.AreEqual(0, testMyStack.opLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(int.MaxValue / 16, testMyStack.opGetCapacity());
            CollectionAssert.AreEqual(new int[int.MaxValue / 16], testMyStack.opToArray);
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(0, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testBehindMaxCapacityConstructor()
        {
            #region Setup

            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>(int.MaxValue / 16-1);
            Assert.AreEqual(0, testMyStack.opLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetCapacity());
            CollectionAssert.AreEqual(new int[100], testMyStack.opToArray);
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testBeyondCapacityConstructor()
        {
            #region Setup

            #endregion
            #region Test & Assert
            testMyStack = new clsVectorStack<int>(int.MaxValue / 16+1);
            Assert.AreEqual(1, testMyStack.opLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetCapacity());
            CollectionAssert.AreEqual(new int[100], testMyStack.opToArray);
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            #endregion
        }
        [TestMethod]
        public void testPushFirstItem()
        {
            #region Setup

            #endregion
            #region Test & Assert
            Assert.isTrue(testMyStack.opPush(123));
            Assert.AreEqual(1, testMyStack.opLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetCapacity());
            CollectionAssert.AreEqual(new int[100], testMyStack.opToArray);
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(123, testMyStack.opToArray()[0]);
            Assert.AreEqual(99, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPushSecondItem()
        {
            #region Setup

            #endregion
            #region Test & Assert
            Assert.isTrue(testMyStack.opPush(123));
            Assert.AreEqual(1, testMyStack.opLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetCapacity());
            CollectionAssert.AreEqual(new int[100], testMyStack.opToArray);
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(123, testMyStack.opToArray()[0]);
            Assert.AreEqual(99, testMyStack.opGetAvailableCapacity());
            #endregion
        }
    }
}
