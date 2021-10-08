using FluentAssertions;
using Microsoft.Xna.Framework;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Yen.Content;
using Yen.UnitTests.Mocks.Components;

namespace Yen.UnitTests
{
    public class GameObjectTests
    {
        [Fact]
        public void Update_ShouldCallUpdateOnAllLogicComponents()
        {
            //Arrange
            var logicComponent1 = new LogicComponentMock();
            var logicComponent2 = new LogicComponentMock();

            var gameObject = new GameObject(Vector2.Zero, new[] { logicComponent1, logicComponent2 });

            //Act
            gameObject.Update(new UpdateContext(null));

            //Assert
            logicComponent1.UpdateCounter.CallsCount.Should().Be(1);
            logicComponent2.UpdateCounter.CallsCount.Should().Be(1);
        }

        [Fact]
        public void OnLoad_ShouldCallOnloadOnAllLoadableComponents()
        {
            //Arrange
            var ids = new HashSet<Guid> { Guid.Empty };
            var loadableComponent1 = new LoadableComponentMock(ids);
            var loadableComponent2 = new LoadableComponentMock(ids);

            var gameObject = new GameObject(Vector2.Zero, new[] { loadableComponent1, loadableComponent2 });

            //Act
            gameObject.OnLoad(new OnLoadContext(null, null));

            //Assert
            loadableComponent1.OnLoadCounter.CallsCount.Should().Be(1);
            loadableComponent2.OnLoadCounter.CallsCount.Should().Be(1);
        }

        [Fact]
        public void Draw_ShouldCallDrawOnAllGraphicsComponents()
        {
            //Arrange
            var graphicsComponent1 = new GraphicsComponentMock();
            var graphicsComponent2 = new GraphicsComponentMock();

            var gameObject = new GameObject(Vector2.Zero, new[] { graphicsComponent1, graphicsComponent2 });

            //Act
            gameObject.Draw(new DrawContext(null, null));

            //Assert
            graphicsComponent1.DrawCounter.CallsCount.Should().Be(1);
            graphicsComponent2.DrawCounter.CallsCount.Should().Be(1);
        }

        [Fact]
        public void Register_ShouldAddLoadableContentUsagesToContentRepository()
        {
            //Arrange
            var ids = new HashSet<Guid> { Guid.Empty };
            var loadableComponent1 = new LoadableComponentMock(ids);
            var loadableComponent2 = new LoadableComponentMock(ids);

            var gameObject = new GameObject(Vector2.Zero, new[] { loadableComponent1, loadableComponent2 });

            var contentRepositoryMock = new Mock<IContentRepository>(MockBehavior.Strict);
            contentRepositoryMock.Setup(x => x.AddUsages(ids))
                .Verifiable();

            //Act
            gameObject.Register(new RegistrationContext(contentRepositoryMock.Object));

            //Assert
            contentRepositoryMock.Verify(x => x.AddUsages(ids), Times.Exactly(2));
        }

        [Fact]
        public void Deregister_ShouldRemoveLoadableContentUsagesFromContentRepository()
        {
            //Arrange
            var ids = new HashSet<Guid> { Guid.Empty };
            var loadableComponent1 = new LoadableComponentMock(ids);
            var loadableComponent2 = new LoadableComponentMock(ids);

            var gameObject = new GameObject(Vector2.Zero, new[] { loadableComponent1, loadableComponent2 });

            var contentRepositoryMock = new Mock<IContentRepository>(MockBehavior.Strict);
            contentRepositoryMock.Setup(x => x.RemoveUsages(ids))
                .Verifiable();

            //Act
            gameObject.Deregister(new RegistrationContext(contentRepositoryMock.Object));

            //Assert
            contentRepositoryMock.Verify(x => x.RemoveUsages(ids), Times.Exactly(2));
        }
    }
}
