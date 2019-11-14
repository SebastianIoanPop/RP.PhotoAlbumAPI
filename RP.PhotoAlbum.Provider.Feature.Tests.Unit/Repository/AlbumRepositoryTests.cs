using System;
using NSubstitute;
using RestSharp;
using RP.PhotoAlbum.Provider.Feature.Repository;
using Xunit;

namespace RP.PhotoAlbum.Provider.Feature.Tests.Unit.Repository
{
    public class AlbumRepositoryTests
    {
        private IRestClient _mockClient;

        private AlbumRepository _subject;

        public AlbumRepositoryTests()
        {
            _mockClient = Substitute.For<IRestClient>();

            _subject = new AlbumRepository(_mockClient);
        }

        [Fact]
        public async void GetAsync_Always_ExecuteClientAsyncRequest()
        {
            // Act
            await _subject.GetAsync(new Random().Next());

            // Assert
            _mockClient.Received(1).ExecuteAsync(Arg.Any<IRestRequest>(), Arg.Any<Action<IRestResponse>>());
        }
    }
}
