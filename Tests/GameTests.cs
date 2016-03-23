using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProjectFDM;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace Tests
{
    [TestClass]
    public class GameTests
    {
        //[TestInitialize()]
        //public void Initialize()
        //{
        //    DecathonGame decgame = new DecathonGame();
        //}


        [TestMethod]
        public void TestMethodGetOneTenReturnsAnIntFromBetweenOneAndTen()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            //Act
            int thenumber = decgame.GetOneTen();

            //Assert
            Assert.IsTrue(thenumber > 0 && thenumber <= 10);
        }

        [TestMethod]
        public void TestMethodLotteryReturnsAListOfSixUniqueInts()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            List<int> lottolist = decgame.Lottery();
            IEnumerable<int> lottodistinct = lottolist.Distinct();
            //Act

            int distinctcount = lottodistinct.Count();

            //Assert
            Assert.AreEqual(distinctcount, lottolist.Count());
        }

        [TestMethod]
        public void TestMethodLotteryReturnsASortedList()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            List<int> lottolist = decgame.Lottery();
            List<int> listsorted = new List<int>();
            //Act
            listsorted = lottolist.OrderBy(v => v).ToList();

            //Assert
            CollectionAssert.AreEqual(listsorted, lottolist);
        }
        //dec win won't add if getoneresultisodd
        //decwin will add to context when result is even
        //decwin will add value from context to another in context


        [TestMethod]
        public void TestMethodUserLotteryReturnsASortedList()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            List<int> lottolist = decgame.Userlottery(8, 2, 3, 50, 7, 14);
            List<int> listsorted = new List<int>();
            //Act
            listsorted = lottolist.OrderBy(v => v).ToList();

            //Assert
            CollectionAssert.AreEqual(listsorted, lottolist);
        }

        public void TestMethodUserLottoValidateReturnsFalseWhenGivenANumberOverFifty()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            //Act

            //Assert
            Assert.AreEqual(false, decgame.userlottovalidate(24, 4, 1, 2, 3, 60));
        }

        public void TestMethodUserLottoValidateReturnsFalseWhenGivenDuplicateNumbers()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            //Act

            //Assert
            Assert.AreEqual(false, decgame.userlottovalidate(24, 24, 1, 2, 3, 40));
        }

        public void TestMethodUserLottoValidateReturnsTrueWhenGivenSixUniqueNumbersBetweenOneAndFifty()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            //Act

            //Assert
            Assert.AreEqual(false, decgame.userlottovalidate(24, 24, 1, 2, 3, 40));
        }
        //lotteryresult returns true for matching lists and false otherwise

        public void TestMethodLotteryResultReturnsTrueWhenTheListsAreEqual()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            List<int> listone = new List<int>();
            List<int> listtwo = new List<int>();
            //Act

            //Assert
            Assert.AreEqual(true, decgame.Lotteryresult(listone, listtwo));
        }

        public void TestMethodLotteryResultReturnsFalseWhenTheListsAreNotEqual()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            List<int> listone = new List<int>();
            List<int> listtwo = new List<int>();
            //Act
            listtwo.Add(1);
            //Assert
            Assert.AreEqual(false, decgame.Lotteryresult(listone, listtwo));
        }

        [TestMethod]
        public void TestMethodLotteryReturnsAListOfLengthSix()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();

            //Act
            List<int> thenumbers = decgame.Lottery();

            //Assert
            Assert.IsTrue(thenumbers.Count == 6);
        }

        [TestMethod]
        public void TestMethodUserLotteryReturnsAListOfLengthSix()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();

            //Act
            List<int> thenumbers = decgame.Userlottery(1, 2, 3, 4, 5, 6);

            //Assert
            Assert.IsTrue(thenumbers.Count == 6);
        }

        [TestMethod]
        public void TestMethodMatcherReturnsZeroWhenGivenAnEmptyList()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            List<int> listone = new List<int>();
            List<int> listtwo = new List<int>();
            //Act
            int finalnumber = decgame.Matcher(listone, listtwo);

            //Assert
            Assert.AreEqual(0, finalnumber);
        }

        [TestMethod]
        public void TestMethodMatcherReturnsZeroWhenGivenListsWithNoCommonalities()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            List<int> listone = new List<int>();
            List<int> listtwo = new List<int>();
            listone.Add(3);
            listone.Add(4);
            listone.Add(99);
            listtwo.Add(7);
            //Act
            int finalnumber = decgame.Matcher(listone, listtwo);

            //Assert
            Assert.AreEqual(0, finalnumber);
        }

        [TestMethod]
        public void TestMethodMatcherReturnsOneWhenGivenTwoListsWithOneCommonality()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            List<int> listone = new List<int>();
            List<int> listtwo = new List<int>();
            listone.Add(3);
            listone.Add(4);
            listone.Add(99);
            listtwo.Add(3);
            //Act
            int finalnumber = decgame.Matcher(listone, listtwo);

            //Assert
            Assert.AreEqual(1, finalnumber);
        }

        [TestMethod]
        public void TestMethodMatcherReturnsTwoWhenGivenTwoListsWithTwoCommonalities()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            List<int> listone = new List<int>();
            List<int> listtwo = new List<int>();
            listone.Add(3);
            listone.Add(4);
            listone.Add(99);
            listtwo.Add(3);
            listtwo.Add(4);
            //Act
            int finalnumber = decgame.Matcher(listone, listtwo);

            //Assert
            Assert.AreEqual(2, finalnumber);
        }

        [TestMethod]
        public void TestMethodLuckyNumberReturnsSixDistinctNumbers()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();
            List<int> lnlist = decgame.LuckyNumber();
            //Act
            IEnumerable<int> luckydistinct = lnlist.Distinct();
            //Act

            int distinctcount = luckydistinct.Count();

            //Assert
            Assert.AreEqual(7, distinctcount);

        }

        [TestMethod]
        public void TestMethodLuckyNumberReturnsAListOfLengthNine()
        {
            //Arrange
            DecathonGame decgame = new DecathonGame();

            //Act
            List<int> lnlist = decgame.LuckyNumber();
            //Assert
            Assert.AreEqual(9, lnlist.Count());
        }


        //lottowin adds or calls on context when matchcount is greater than or equal to four
        //lotto win adds a quarter of payout to account for match of 4
        //lottowin adds a third of payout to account for match of 5
        //lottowin adds full payout to account for match of 6

        //luckynwin adds payout to account if user number occurs 3 or more times


        //----------------Joe's tests:
        [TestMethod]
        public void Test_Bet_ReturnsNotNull_WhenCalled()
        {
            //Arrange
            BetClass BetObj = new BetClass();
            //Act
            List<string> result = BetObj.Bet(50, 5);
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Test_Bet_ReturnsInvalidInputMessage_IfNumberBidIsOutOfRange0And100()
        {
            //Arrange
            BetClass BetObj = new BetClass();
            string expected = "+++invalid input+++";
            //Act
            List<string> result1 = BetObj.Bet(101, 5);
            List<string> result2 = BetObj.Bet(-1, 5);
            //Assert
            Assert.AreEqual(expected, result1[0]);
            Assert.AreEqual(expected, result2[0]);
        }
        //---------------

    }
}
