using FluentAssertions;
using Microsoft.Xna.Framework.Content;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Yen.Content;
using Yen.Exceptions.Content;
using Yen.UnitTests.Mocks;

namespace Yen.UnitTests.Content
{
    public class ContentRepositoryTests
    {
        [Fact]
        public void GetContent_OnRegisteredContent_ShouldReturnContent()
        {
            //Arrange
            var id = Guid.Empty;
            var contentSourceMock = CreateContentSourceMock(new[] { new ContentMock(id) });

            var sut = new ContentRepository(contentSourceMock.Object);

            //Act
            sut.GetContent(id);

            //Arrange
            sut.Should().NotBeNull();
        }

        [Fact]
        public void GetContent_OnNotRegisteredContent_ShouldThrowException()
        {
            //Arrange
            var id = Guid.Empty;
            var contentSourceMock = CreateContentSourceMock();

            var sut = new ContentRepository(contentSourceMock.Object);

            //Act & Assert
            Assert.Throws<ContentsNotRegisteredException>(() => sut.GetContent(id));

            //Arrange
            sut.Should().NotBeNull();
        }

        [Fact]
        public void Load_ShouldLoadAllUsedUnloadedContents()
        {
            //Arrange
            var notUsedContentUnloaded = new ContentMock(Guid.NewGuid(), false);
            var usedContentUnloaded = new ContentMock(Guid.NewGuid(), false);
            var usedContentLoaded = new ContentMock(Guid.NewGuid(), true);

            var contentSourceMock = CreateContentSourceMock(new[] { notUsedContentUnloaded, usedContentUnloaded, usedContentLoaded });

            var sut = new ContentRepository(contentSourceMock.Object);
            sut.AddUsage(usedContentUnloaded.Id);
            sut.AddUsage(usedContentLoaded.Id);

            //Act
            sut.Load(new LoadContext(null));

            //Assert
            notUsedContentUnloaded.LoadCount.CallsCount.Should().Be(0);
            usedContentUnloaded.LoadCount.CallsCount.Should().Be(1);
            usedContentLoaded.LoadCount.CallsCount.Should().Be(0);
        }

        [Fact]
        public void Unload_ShouldUnloadAllUnusedLoadedContents()
        {
            //Arrange
            var notUsedContentUnloaded = new ContentMock(Guid.NewGuid(), false);
            var unusedContentLoaded = new ContentMock(Guid.NewGuid(), true);
            var usedContentLoaded = new ContentMock(Guid.NewGuid(), true);

            var contentSourceMock = CreateContentSourceMock(new[] { notUsedContentUnloaded, unusedContentLoaded, usedContentLoaded });

            var sut = new ContentRepository(contentSourceMock.Object);
            sut.AddUsage(usedContentLoaded.Id);

            //Act
            sut.Unload();

            //Assert
            notUsedContentUnloaded.UnloadCount.CallsCount.Should().Be(0);
            unusedContentLoaded.UnloadCount.CallsCount.Should().Be(1);
            usedContentLoaded.UnloadCount.CallsCount.Should().Be(0);
        }

        private Mock<IContentSource> CreateContentSourceMock(ContentMock[] contents = null)
        {
            if (contents is null)
                contents = Array.Empty<ContentMock>();

            var mock = new Mock<IContentSource>(MockBehavior.Strict);
            mock.SetupGet(x => x.Contents)
                .Returns(contents);

            return mock;
        }
    }
}
