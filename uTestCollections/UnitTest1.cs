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
            Assert.AreEqual(0, testMyStack.opGetLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
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
            Assert.AreEqual(0, testMyStack.opGetLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
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
            Assert.AreEqual(0, testMyStack.opGetLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
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
            Assert.AreEqual(0, testMyStack.opGetLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
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
            testMyStack = new clsVectorStack<int>(clsVectorStack<int>.opGetMaxCapacity());
            Assert.AreEqual(0, testMyStack.opGetLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(clsVectorStack<int>.opGetMaxCapacity(), testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(new int[clsVectorStack<int>.opGetMaxCapacity()], testMyStack.opToArray);
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
            Assert.AreEqual(0, testMyStack.opGetLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
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
            Assert.AreEqual(1, testMyStack.opGetLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
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
            Assert.AreEqual(1, testMyStack.opGetLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
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
            testMyStack = new clsVectorStack<int>();
            testExpectedItems = new int[100];
            testExpectedItems[0] = 123;
            testMyStack.opToItems(testExpectedItems, 1);
            testExpectedItems = new int[100];
            testExpectedItems[0] = 456;
            testExpectedItems[1] = 123;
            #endregion
            #region Test & Assert
            Assert.isTrue(testMyStack.opPush(456));
            Assert.AreEqual(2, testMyStack.opGetLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(100, testMyStack.opGetTotalCapacity());
            CollectionAssert.AreEqual(testExpectedItems, testMyStack.opToArray());
            Assert.IsFalse(testMyStack.opItsFlexible());
            Assert.AreEqual(100, testMyStack.opGetGrowingFactor());
            Assert.AreEqual(98, testMyStack.opGetAvailableCapacity());
            #endregion
        }
        [TestMethod]
        public void testPushNextItemWithHugeFullFlexibleCollection()
        {
            #region Setup
            testMyStack = new clsVectorStack<int>();
            testMyStack.opToItems(new int[clsVectorStack<int>.opGetMaxCapacity() - 1]);
            testMyStack.opSetFlexible();
            testExpectedItems = new int[clsVectorStack<int>.opGetMaxCapacity()];
            testExpectedItems[0] = 777;
            #endregion
            #region Test & Assert
            Assert.isTrue(testMyStack.opPush(777));
            Assert.AreEqual(clsVectorStack<int>.opGetMaxCapacity(), testMyStack.opGetLenght());
            Assert.IsFalse(testMyStack.opItsOrderedAscending());
            Assert.IsFalse(testMyStack.opItsOrderedDescending());
            Assert.AreEqual(clsVectorStack<int>.opGetMaxCapacity(),testMyStack.opGetTotalCapacity());
            #endregion
        }
    }
}
