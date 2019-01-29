using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LuckyTickets.BL;
using Moq;

namespace LuckyTickets.Test.BL.Tests
{

    [TestClass]
    public class PiterAlgorithmTests
    {
        ILuckyTicketCounterAlgorithm counterAlgorithm = new PiterAlgorithm();

        [TestMethod]
        [DataRow(015222, new byte[] { 0, 1, 5, 2, 2, 2 }, true)]
        [DataRow(015221, new byte[] { 0, 1, 5, 2, 2, 1 }, false)]

        public void TestMethod1(int num, byte[] digits, bool IsTicketLuckyExpected)
        {
            //Arrange
            Ticket t = new Ticket((uint)num, digits);
            bool actualResult;
            //Act
            actualResult = counterAlgorithm.IsTicketLucky(t);

            //Assert
            Assert.AreEqual(IsTicketLuckyExpected, actualResult);
        }
    }
}
