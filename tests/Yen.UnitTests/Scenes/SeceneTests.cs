using FluentAssertions;
using System;
using Xunit;
using Yen.Scenes;
using Yen.UnitTests.Mocks;

namespace Yen.UnitTests.Scenes
{
    public class SeceneTests
    {
        [Fact]
        public void Update_ShouldUpdateAllGameObjects()
        {
            //Arrange
            var gameObject1 = new GameObjectMock();
            var gameObject2 = new GameObjectMock();

            var sut = new Scene(Guid.Empty, new[] { gameObject1, gameObject2 });

            //Act
            sut.Update(new UpdateContext(null));

            //Assert
            gameObject1.UpdateCounter.CallsCount.Should().Be(1);
            gameObject2.UpdateCounter.CallsCount.Should().Be(1);
        }

        [Fact]
        public void Draw_ShouldDrawAllGameObjects()
        {
            //Arrange
            var gameObject1 = new GameObjectMock();
            var gameObject2 = new GameObjectMock();

            var sut = new Scene(Guid.Empty, new[] { gameObject1, gameObject2 });

            //Act
            sut.Draw(new DrawContext(null, null));

            //Assert
            gameObject1.DrawCounter.CallsCount.Should().Be(1);
            gameObject2.DrawCounter.CallsCount.Should().Be(1);
        }

        [Fact]
        public void OnLoad_ShouldLoadAllGameObjects()
        {
            //Arrange
            var gameObject1 = new GameObjectMock();
            var gameObject2 = new GameObjectMock();

            var sut = new Scene(Guid.Empty, new[] { gameObject1, gameObject2 });

            //Act
            sut.OnLoad(new OnLoadContext(null, null));

            //Assert
            gameObject1.OnloadCounter.CallsCount.Should().Be(1);
            gameObject2.OnloadCounter.CallsCount.Should().Be(1);
        }

        [Fact]
        public void Register_ShouldRegisterAllGameObjects()
        {
            //Arrange
            var gameObject1 = new GameObjectMock();
            var gameObject2 = new GameObjectMock();

            var sut = new Scene(Guid.Empty, new[] { gameObject1, gameObject2 });

            //Act
            sut.Register(new RegistrationContext(null));

            //Assert
            gameObject1.RegisterCounter.CallsCount.Should().Be(1);
            gameObject2.RegisterCounter.CallsCount.Should().Be(1);
        }

        [Fact]
        public void Deregister_ShouldDeregisterAllGameObjects()
        {
            //Arrange
            var gameObject1 = new GameObjectMock();
            var gameObject2 = new GameObjectMock();

            var sut = new Scene(Guid.Empty, new[] { gameObject1, gameObject2 });

            //Act
            sut.Deregister(new RegistrationContext(null));

            //Assert
            gameObject1.DeregisterCounter.CallsCount.Should().Be(1);
            gameObject2.DeregisterCounter.CallsCount.Should().Be(1);
        }
    }
}
