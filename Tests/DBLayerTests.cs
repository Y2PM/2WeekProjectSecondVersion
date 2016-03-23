using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBLayer.Create;
using DBLayer;
using Moq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using DBLayer.Delete;

namespace Tests
{
    [TestClass]
    public class DBLayerTests
    {
        [TestMethod]
        public void Test_CreateGameMethod_CreatesAGame_WhenGivenAGameToCreate()
        {
            //Arrange

            Mock<GroupProjectEntities> MockGroupProjectEntities = new Mock<GroupProjectEntities>();
            CreateGame CreateGameObject = new CreateGame(MockGroupProjectEntities.Object);
            var mockSet = new Mock<DbSet<Game>>();

            //Initial Pretend Data:
            var data = new List<Game>
            {
                new Game { name = "Game1", payout=1 },
                new Game { name="Game2", payout=2 }
            }.AsQueryable();

            //Making a Mockset:
            mockSet.As<IQueryable<Game>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Game>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Game>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Game>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            Game game = new Game() { name = "Game3", payout = 3 };

            MockGroupProjectEntities.Setup(c => c.Games).Returns(mockSet.Object);
            //Act
            CreateGameObject.CreateGameMethod(game);
            //Assert
            MockGroupProjectEntities.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_CreateMemberMethod_CreatesAMember_WhenGivenAMemberToCreate()
        {
            //Arrange
            Mock<GroupProjectEntities> MockGroupProjectEntities = new Mock<GroupProjectEntities>();
            CreateMember CreateMemberObject = new CreateMember(MockGroupProjectEntities.Object);
            var mockSet = new Mock<DbSet<Member>>(); 

            //Initial Pretend Data:
            var data = new List<Member>
            {
                new Member {m_name="James", m_username="ragingbull", m_password="password123"},//,m_account= 0
                new Member {m_name= "Michael", m_username="rocky",m_password= "password12"}
            }.AsQueryable();

            //Making a Mockset:
            mockSet.As<IQueryable<Member>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Member>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Member>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Member>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            Member member = new Member() { m_name = "Camel", m_username = "Camel13", m_password = "CamelPassword" };

            MockGroupProjectEntities.Setup(c => c.Members).Returns(mockSet.Object);
            //Act
            CreateMemberObject.CreateMemberMethod(member);
            //Assert
            MockGroupProjectEntities.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_DeleteGameMethod_DeletesAGame_WhenGivenAGameID()
        {
            //Arrange
            Mock<GroupProjectEntities> MockGroupProjectEntities = new Mock<GroupProjectEntities>();
            DeleteGame DeleteGameObject = new DeleteGame(MockGroupProjectEntities.Object);
            var mockSet = new Mock<DbSet<Game>>();

            //Initial Pretend Data:
            var data = new List<Game>
            {
                new Game {name="Game1",payout=11,game_id=1},
                new Game {name="Game2",payout=22,game_id=2}
            }.AsQueryable();

            //Making a Mockset:
            mockSet.As<IQueryable<Game>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Game>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Game>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Game>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            int GameID = 2;

            MockGroupProjectEntities.Setup(c => c.Games).Returns(mockSet.Object);
            //Act
            DeleteGameObject.DeleteGameMethod(GameID);
            //Assert
            MockGroupProjectEntities.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_DeleteMemberMethod_DeletesAMember_WhenGivenAMemberID()
        {
            //Arrange
            Mock<GroupProjectEntities> MockGroupProjectEntities = new Mock<GroupProjectEntities>();
            DeleteMember DeleteMemberObject = new DeleteMember(MockGroupProjectEntities.Object);
            var mockSet = new Mock<DbSet<Member>>();

            //Initial Pretend Data:
            var data = new List<Member>
            {
                new Member {m_name="James", m_username="ragingbull", m_password="password123",member_id= 1},
                new Member {m_name= "Michael", m_username="rocky",m_password= "password12",member_id= 2}
            }.AsQueryable();

            //Making a Mockset:
            mockSet.As<IQueryable<Member>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Member>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Member>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Member>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            int memberID = 2;

            MockGroupProjectEntities.Setup(c => c.Members).Returns(mockSet.Object);
            //Act
            DeleteMemberObject.DeleteMemberMethod(memberID);
            //Assert
            MockGroupProjectEntities.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Test_ReadAllGames_ReturnsAListOfGames_WhenCalled()
        {
            //Arrange

            //Act

            //Assert

        }
    }
}
