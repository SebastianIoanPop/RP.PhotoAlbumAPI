using System;
using NSubstitute;
using RP.PhotoAlbum.Provider.Feature.Service.Interface;
using RP.PhotoAlbumAPI.Controllers;
using Xunit;

namespace RP.PhotoAlbumAPI.Tests.Unit.Controllers
{
    public class PhotoAlbumControllerTests
    {
        private IPhotoAlbumService _mockPhotoAlbumService;
        private PhotoAlbumController _subject;

        public PhotoAlbumControllerTests()
        {
            _mockPhotoAlbumService = Substitute.For<IPhotoAlbumService>();

            _subject = new PhotoAlbumController(_mockPhotoAlbumService);
        }

        [Fact]
        public void Get_Always_CallsTheService()
        {
            // Act
            _ = _subject.Get(null);

            // Assert
            _mockPhotoAlbumService.Received(1).GetAsync(null);
        }

        [Fact]
        public void Get_Always_CallsTheServiceWithCorrectParameter()
        {
            // Arrange
            var randomInt = new Random().Next();

            // Act
            _ = _subject.Get(randomInt);

            // Assert
            _mockPhotoAlbumService.Received(1).GetAsync(randomInt);
        }
    }
}
