using System;
using LuckyTickets.BL;
using LuckyTickets.BL.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LuckyTickets.Test.BL.Tests.Utilities.Tests
{
    [TestClass]
    public class AlgorythmTypeValidatorTests
    {
        AlgorythmTypeValidator validator = new AlgorythmTypeValidator();
        LuckyTIcketAlgorithmsArrComparer arrComparer = new LuckyTIcketAlgorithmsArrComparer();
        [TestMethod]
        public void Insert_WrongString_EnmptyAlgorithmContainerExpected()
        {
            //arrange
            ILuckyTicketCounterAlgorithm[] current;
            ILuckyTicketCounterAlgorithm[] expected = new ILuckyTicketCounterAlgorithm[] { };
            string algorithmName = "algorithm";
            //Act
            current = validator.GetAlgorythmType(algorithmName);
            
            //Assert
            CollectionAssert.AreEqual(expected, current);

        }

        [TestMethod]
        public void Insert_MoskowString_MoskowAlgorythmExpected()
        {
            //arrange
            ILuckyTicketCounterAlgorithm[] actual;
            ILuckyTicketCounterAlgorithm[] expected = new ILuckyTicketCounterAlgorithm[] { new MoskowAlgorithm() as ILuckyTicketCounterAlgorithm };
            string algorithmName = "moskow";

            //Act
            actual = validator.GetAlgorythmType(algorithmName);

            //Assert
            CollectionAssert.AreEqual(expected, actual, arrComparer);
        }

        [TestMethod]
        public void Insert_PiterString_PiterAlgorythmExpected()
        {
            //arrange
            ILuckyTicketCounterAlgorithm[] actual;
            ILuckyTicketCounterAlgorithm[] expected = new ILuckyTicketCounterAlgorithm[] { new PiterAlgorithm() };
            string algorithmName = "piter";
            //Act
            actual = validator.GetAlgorythmType(algorithmName);

            //Assert
            CollectionAssert.AreEqual(expected, actual, arrComparer);

        }

        [TestMethod]
        public void Insert_PiterMoskowString_PiterAndMoskowAlgorythmsExpected()
        {
            //arrange
            ILuckyTicketCounterAlgorithm[] actual;
            ILuckyTicketCounterAlgorithm[] expected = new ILuckyTicketCounterAlgorithm[] { new MoskowAlgorithm(), new PiterAlgorithm() };
            string algorithmName = "piter ADS moskow";

            //Act
            actual = validator.GetAlgorythmType(algorithmName);

            //Assert
            CollectionAssert.AreEqual(expected, actual, arrComparer);

        }
        [TestMethod]
        public void Insert_oneString_PiterAndMoskowAlgorythmsExpected()
        {
            //arrange
            ILuckyTicketCounterAlgorithm[] actual;
            ILuckyTicketCounterAlgorithm[] expected = new ILuckyTicketCounterAlgorithm[] { new MoskowAlgorithm(), new PiterAlgorithm() };
            string algorithmName = "piterADS moskow";

            //Act
            actual = validator.GetAlgorythmType(algorithmName);

            //Assert
            CollectionAssert.AreEqual(expected, actual, arrComparer);

        }
    }
}
