
using LuckyTickets.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LuckyTickets.Test.BL.Tests
{
    /// <summary>
    /// Summary description for MoskowAlgorithmTests
    /// </summary>
    [TestClass]
    public class MoskowAlgorithmTests
    {
        ILuckyTicketCounterAlgorithm counterAlgorithm = new MoskowAlgorithm();

        [TestMethod]
        [DataRow(015222, true)]
        [DataRow(015221, false)]
        [DataRow(0, true)]
        [DataRow(12121212, true)]
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
