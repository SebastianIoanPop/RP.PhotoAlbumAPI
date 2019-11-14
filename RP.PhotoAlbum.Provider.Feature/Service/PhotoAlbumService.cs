using System.Collections.Generic;
using System.Threading.Tasks;
using RP.PhotoAlbum.Provider.Feature.Domain;
using RP.PhotoAlbum.Provider.Feature.Extensions;
using RP.PhotoAlbum.Provider.Feature.Repository.Interface;
using RP.PhotoAlbum.Provider.Feature.Service.Interface;

namespace RP.PhotoAlbum.Provider.Feature.Service
{
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IPhotoRepository _photoRepository;

        public PhotoAlbumService(IAlbumRepository albumRepository, IPhotoRepository photoRepository)
        {
            _albumRepository = albumRepository;
            _photoRepository = photoRepository;
        }

        public async Task<IEnumerable<Album>> GetAsync(int? userId)
        {
            var albums = await _albumRepository.GetAsync(userId);
            var photos = await _photoRepository.GetAllAsync();

            foreach (var album in albums)
            {
                album.FilterPhotos(photos);
            }

            return albums;
        }
    }
}
