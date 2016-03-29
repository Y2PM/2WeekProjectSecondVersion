using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBLayer.Create;
using DBLayer;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using DBLayer.Delete;
using DBLayer.Read;
using DBLayer.Update;

namespace Tests
{
    [TestClass]
    public class DBLayerTests
    {
        Mock<DbSet<Member>> mockSetMember;
        IQueryable<DBLayer.Member> dataMember;
        Mock<DbSet<Game>> mockSetGame;
        IQueryable<DBLayer.Game> dataGame;
        Mock<GroupProjectEntities> MockGroupProjectEntities;

        [TestInitialize]
        public void TestInitialize()
        {
            #region MemberRegion
            MockGroupProjectEntities = new Mock<GroupProjectEntities>();
            mockSetMember = new Mock<DbSet<Member>>();

            //Initial Pretend Data:
            dataMember = new List<Member>
            {
                new Member {m_name="James", m_username="ragingbull", m_password="password123", member_id= 1},
                new Member {m_name= "Michael", m_username="rocky", m_password="password12", member_id= 2},
                new Member {m_name = "Camel", m_username = "Camel13", m_password = "CamelPassword", member_id= 3}
            }.AsQueryable();

            //Making a Mockset:
            mockSetMember.As<IQueryable<Member>>().Setup(m => m.Provider).Returns(dataMember.Provider);
            mockSetMember.As<IQueryable<Member>>().Setup(m => m.Expression).Returns(dataMember.Expression);
            mockSetMember.As<IQueryable<Member>>().Setup(m => m.ElementType).Returns(dataMember.ElementType);
            mockSetMember.As<IQueryable<Member>>().Setup(m => m.GetEnumerator()).Returns(() => dataMember.GetEnumerator());

            MockGroupProjectEntities.Setup(c => c.Members).Returns(mockSetMember.Object);
            #endregion

            #region GameRegion
            mockSetGame = new Mock<DbSet<Game>>();

            //Initial Pretend Data:
            dataGame = new List<Game>
            {
                new Game {name="Game1",payout=11,game_id=1},
                new Game {name="Game2",payout=22,game_id=2}
            }.AsQueryable();

            //Making a Mockset:
            mockSetGame.As<IQueryable<Game>>().Setup(m => m.Provider).Returns(dataGame.Provider);
            mockSetGame.As<IQueryable<Game>>().Setup(m => m.Expression).Returns(dataGame.Expression);
            mockSetGame.As<IQueryable<Game>>().Setup(m => m.ElementType).Returns(dataGame.ElementType);
            mockSetGame.As<IQueryable<Game>>().Setup(m => m.GetEnumerator()).Returns(() => dataGame.GetEnumerator());

            MockGroupProjectEntities.Setup(c => c.Games).Returns(mockSetGame.Object);
            #endregion
        }

        [TestMethod]
        public void Test_CreateGameMethod_CreatesAGame_WhenGivenAGameToCreate()
        {
            //Arrange
            CreateGame CreateGameObject = new CreateGame(MockGroupProjectEntities.Object);
            Game game = new Game() { name = "Game3", payout = 3 };
            //Act
            CreateGameObject.CreateGameMethod(game);
            //Assert
            MockGroupProjectEntities.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_CreateMemberMethod_CreatesAMember_WhenGivenAMemberToCreate()
        {
            //Arrange
            CreateMember CreateMemberObject = new CreateMember(MockGroupProjectEntities.Object);
            Member member = new Member() { m_name = "Camel", m_username = "Camel13", m_password = "CamelPassword" };
            //Act
            CreateMemberObject.CreateMemberMethod(member);
            //Assert
            MockGroupProjectEntities.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_DeleteGameMethod_DeletesAGame_WhenGivenAGameID()
        {
            //Arrange
            DeleteGame DeleteGameObject = new DeleteGame(MockGroupProjectEntities.Object);
            int GameID = 2;
            //Act
            DeleteGameObject.DeleteGameMethod(GameID);
            //Assert
            MockGroupProjectEntities.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_DeleteMemberMethod_DeletesAMember_WhenGivenAMemberID()
        {
            //Arrange
            DeleteMember DeleteMemberObject = new DeleteMember(MockGroupProjectEntities.Object);
            int memberID = 2;
            //Act
            DeleteMemberObject.DeleteMemberMethod(memberID);
            //Assert
            MockGroupProjectEntities.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_ReadAllGames_ReturnsAListOfGames_WhenCalled()
        {
            //Arrange
            ReadGame ReadGameObject = new ReadGame(MockGroupProjectEntities.Object);
            //Act
            List<Game> result = ReadGameObject.ReadAllGames();
            //Assert
            CollectionAssert.AreEqual(dataGame.ToList(), result);
        }

        [TestMethod]
        public void Test_ReadSpecificGame_ReturnsASpecificGame_WhenGivenID()
        {
            //Arrange
            ReadGame ReadGameObject = new ReadGame(MockGroupProjectEntities.Object);
            //Act
            Game result = ReadGameObject.ReadSpecificGame(2);
            //Assert
            Assert.AreEqual(dataGame.ToList().ElementAt(1), result);
        }

        [TestMethod]
        public void Test_ReadGamePayout_ReturnsGamePayout_WhenGivenGameName()
        {
            //Arrange
            ReadGame ReadGameObject = new ReadGame(MockGroupProjectEntities.Object);
            string GameName = "Game1";
            //Act
            decimal result = ReadGameObject.ReadGamePayout(GameName);
            //Assert
            Assert.AreEqual(dataGame.ToList().ElementAt(0).payout, result);
        }

        [TestMethod]
        public void Test_ReadAllMembers_ReturnsAListOfMembers_WhenCalled()
        {
            //Arrange
            ReadMember ReadMemberObject = new ReadMember(MockGroupProjectEntities.Object);
            //Act
            List<Member> result = ReadMemberObject.ReadAllMembers();
            //Assert
            CollectionAssert.AreEqual(dataMember.ToList(), result);
        }

        [TestMethod]
        public void Test_ReadSpecificMember_ReadsSpecificMember_WhenGivenID()
        {
            //Arrange
            ReadMember ReadMemberObject = new ReadMember(MockGroupProjectEntities.Object);
            //Act
            Member result = ReadMemberObject.ReadSpecificMember(3);
            //Assert
            Assert.AreEqual(dataMember.ToList().ElementAt(2), result);
        }

        [TestMethod]
        public void Test_UpdateGameMethod_UpdatesAGame_WhenGivenAGameToUpdate()
        {
            //Arrange
            UpdateGame UpdateGameObject = new UpdateGame(MockGroupProjectEntities.Object);
            Game updatedGame = new Game() { name = "Game2", payout = 23, game_id = 2 };
            //Act
            UpdateGameObject.UpdateGameMethod(updatedGame);
            //Assert
            Assert.AreEqual(dataGame.ToList().ElementAt(1).payout, 23);
        }

        [TestMethod]
        public void Test_UpdateMemberMethod_UpdatesMember_WhenGivenUpdatedMember()
        {
            //Arrange
            UpdateMember UpdateMemberObject = new UpdateMember(MockGroupProjectEntities.Object);
            Member updatedMember = new Member() { m_name = "Camel", m_username = "Camel13", m_password = "PasswordCamelCamel", member_id = 3 };
            //Act
            UpdateMemberObject.UpdateMemberMethod(updatedMember);
            //Assert
            Assert.AreEqual(dataMember.ToList().ElementAt(2).m_password, "PasswordCamelCamel");
        }
    }
}
