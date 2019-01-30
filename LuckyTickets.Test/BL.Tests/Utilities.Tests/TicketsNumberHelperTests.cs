using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuckyTickets.BL.Utilities;

namespace LuckyTickets.Test.BL.Tests.Utilities.Tests
{
    [TestClass]
    public class TicketsNumberHelperTests
    {
        [TestMethod]
        [DataRow(123456, new byte[] { 1, 2, 3, 4, 5, 6 })]
        [DataRow(56, new byte[] { 0, 0, 0, 0, 5, 6 })]
        [DataRow( 0, new byte[] { 0, 0, 0, 0, 0, 0 })]

        public void GetDigitsOfNumTest(int number, byte[] expected)
        {
            //Arrange
            TicketsNumberHelper helper = new TicketsNumberHelper();
            byte[] actual;

            //Act
            actual = helper.getDigitsOfNum((uint)number);

            //Assert
            CollectionAssert.AreEqual(expected, actual);

        }
    }
}
