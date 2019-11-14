using System;
using System.Collections.Generic;
using System.Linq;
using NSubstitute;
using RP.PhotoAlbum.Provider.Feature.Domain;
using RP.PhotoAlbum.Provider.Feature.Repository.Interface;
using RP.PhotoAlbum.Provider.Feature.Service;
using Shouldly;
using Xunit;

namespace RP.PhotoAlbum.Provider.Feature.Tests.Unit.Service
{
    public class PhotoAlbumServiceTests
    {
        private IAlbumRepository _mockAlbumRepository;
        private IPhotoRepository _mockPhotoRepository;

        private PhotoAlbumService _subject;

        public PhotoAlbumServiceTests()
        {
            _mockAlbumRepository = Substitute.For<IAlbumRepository>();
            _mockPhotoRepository = Substitute.For<IPhotoRepository>();

            _subject = new PhotoAlbumService(_mockAlbumRepository, _mockPhotoRepository);
        }

        [Fact]
        public async void GetAsync_UserIdNull_NonePassedToAlbumRepository()
        {
            // Act
            await _subject.GetAsync(null);

            // Assert
            _mockAlbumRepository.Received(1).GetAsync(null);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(-5)]
        public async void GetAsync_Always_CallsAlbumRepositoryWithPassedId(int passedUserId)
        {
            // Act
            await _subject.GetAsync(passedUserId);

            // Assert
            _mockAlbumRepository.Received(1).GetAsync(passedUserId);
        }

        [Fact]
        public async void GetAsync_Always_CallsPhotoRepository()
        {
            // Act
            await _subject.GetAsync(new Random().Next());

            // Assert
            _mockPhotoRepository.Received(1).GetAllAsync();
        }

        [Fact]
        public async void GetAsync_Always_MergesPhotosIntoAlbums()
        {
            // Arrange
            MockRepositoryReturn(new List<Album>
            {
                new Album
                {
                    Id = 1
                },
                new Album
                {
                    Id = 2
                }
            });

            MockRepositoryReturn(new List<Photo>
            {
                new Photo
                {
                    AlbumId = 1,
                    Title = "Memories"
                },
                new Photo
                {
                    AlbumId = 1,
                    Title = "Some other photo"
                },
                new Photo
                {
                    AlbumId = 2,
                    Title = "The text is irrelevant"
                }
            });

            // Act
            var result = await _subject.GetAsync(new Random().Next());

            // Assert
            result.Count().ShouldBe(2);
            result.ShouldContain(album => album.Photos.TrueForAll(photo => photo.AlbumId.Equals(album.Id)));
            result.ShouldNotContain(album => album.Photos.Any(photo => !photo.AlbumId.Equals(album.Id)));
        }

        [Fact]
        public async void GetAsync_WhenNoPhotosForAlbum_ReturnAlbumWithEmptyPhotoCollection()
        {
            // Arrange
            MockRepositoryReturn(new List<Album> {
                new Album {
                    Id = 1
                }
            });

            // Act
            var result = await _subject.GetAsync(new Random().Next());

            // Assert
            result.Count().ShouldBe(1);
            result.First().Photos.ShouldNotBeNull();
            result.First().Photos.ShouldBeEmpty();
        }

        [Fact]
        public async void GetAsync_WhenPhotosDontHaveAlbums_DontReturnPhotosInResult()
        {
            // Arrange
            MockRepositoryReturn(new List<Photo>
            {
                new Photo
                {
                    AlbumId = 3
                }
            });

            // Act
            var result = await _subject.GetAsync(new Random().Next());

            // Assert
            result.Count().ShouldBe(0);
        }

        private void MockRepositoryReturn(List<Album> mockedAlbums)
        {
            _mockAlbumRepository.GetAsync(Arg.Any<int>()).Returns(mockedAlbums);
        }

        private void MockRepositoryReturn(List<Photo> mockedPhotos)
        {
            _mockPhotoRepository.GetAllAsync().Returns(mockedPhotos);
        }
    }
}
