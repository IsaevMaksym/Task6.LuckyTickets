using System;
using LuckyTickets.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LuckyTickets.Test.BL.Tests
{
    [TestClass]
    public class TicketCounterTests
    {
        [TestMethod]
        [DataRow(0, 1)]
        [DataRow(1000, 1)]
        [DataRow(1001, 2)]
        public void CountTicketsMoskowAlgorithmTest(int maxlimit, int expectedCount)
        {
            TicketCounter counter = new TicketCounter();
            int actualTicketCounts;

            //Act
            actualTicketCounts = counter.CountTickets((uint)maxlimit);

            //Assert
            Assert.AreEqual(expectedCount, actualTicketCounts);
        }

        [TestMethod]
        [DataRow(0 ,1)]
        [DataRow(112, 2)]
        public void CountTicketsPiterAlgorithmTest(int maxlimit, int expectedCount)
        {
            TicketCounter counter = new TicketCounter(new PiterAlgorithm());
            int actualTicketCounts;

            //Act
            actualTicketCounts = counter.CountTickets((uint)maxlimit);

            //Assert
            Assert.AreEqual(expectedCount, actualTicketCounts);
        }

    }
}
