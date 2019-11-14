using System;
using NSubstitute;
using RestSharp;
using RP.PhotoAlbum.Provider.Feature.Repository;
using Xunit;

namespace RP.PhotoAlbum.Provider.Feature.Tests.Unit.Repository
{
    public class PhotoRepositoryTests
    {
        private IRestClient _mockClient;

        private PhotoRepository _subject;

        public PhotoRepositoryTests()
        {
            _mockClient = Substitute.For<IRestClient>();

            _subject = new AlbumRepository(_mockClient);
        }

        [Fact]
        public async void GetAllAsync_Always_ExecuteClientAsyncRequest()
        {
            // Act
            await _subject.GetAllAsync();

            // Assert
            _mockClient.Received(1).ExecuteAsync(Arg.Any<IRestRequest>(), Arg.Any<Action<IRestResponse>>());
        }
    }
}
