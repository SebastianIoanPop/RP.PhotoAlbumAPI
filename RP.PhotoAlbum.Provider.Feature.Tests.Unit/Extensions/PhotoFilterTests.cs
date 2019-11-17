using System.Collections.Generic;
using RP.PhotoAlbum.Provider.Feature.Domain;
using RP.PhotoAlbum.Provider.Feature.Extensions;
using Shouldly;

namespace RP.PhotoAlbum.Provider.Feature.Tests.Unit.Extensions
{
    public class PhotoFilterTests
    {
        public void FilterPhotos_Always_ShouldGroupPhotosToAlbums()
        {
            // Arrange
            var photos = new List<Photo>
            {
                new Photo
                {
                    AlbumId = 1,
                    Id = 1
                },
                new Photo
                {
                    AlbumId = 1,
                    Id = 2
                },
                new Photo
                {
                    AlbumId = 2,
                    Id = 3
                },
                 new Photo
                {
                    AlbumId = 1,
                    Id = 4
                }
            };

            var albums = new List<Album>
            {
                new Album
                {
                    Id = 1,
                },
                new Album
                {
                    Id = 2
                }
            };

            // Act
            foreach (var album in albums)
            {
                album.FilterPhotos(photos);
            }

            // Assert
            foreach (var album in albums)
            {
                album.Photos.ShouldNotContain(photo => photo.AlbumId != album.Id);
            }
        }
    }
}
