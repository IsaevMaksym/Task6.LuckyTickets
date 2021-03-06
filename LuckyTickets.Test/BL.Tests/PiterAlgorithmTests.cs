﻿using System;
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
        [DataRow(012252, true)]
        [DataRow(015221, false)]     
        [DataRow(0, true)]
        [DataRow(000000000, true)]
        public void IsTicketLuckyTest(int num, bool IsTicketLuckyExpected)
        {
            //Arrange
            Ticket t = new Ticket((uint)num);
            bool actualResult;

            //Act
            actualResult = counterAlgorithm.IsTicketLucky(t);

            //Assert
            Assert.AreEqual(IsTicketLuckyExpected, actualResult);
        }
    }
}
