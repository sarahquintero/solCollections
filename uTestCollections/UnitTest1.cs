using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            CollectionAssert.
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

            #endregion
        }
        [TestMethod]
        public void testOverFlowCapacityConstructor()
        {
            #region Setup

            #endregion
            #region Test & Assert

            #endregion
    }
    }
}
