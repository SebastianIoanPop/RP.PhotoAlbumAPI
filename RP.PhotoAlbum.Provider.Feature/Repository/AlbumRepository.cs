using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RP.PhotoAlbum.Provider.Feature.Domain;
using RP.PhotoAlbum.Provider.Feature.Extensions;
using RP.PhotoAlbum.Provider.Feature.Repository.Interface;

namespace RP.PhotoAlbum.Provider.Feature.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private const string PATH_TO_ALBUMS = "albums";

        private readonly IRestClient _client;

        public AlbumRepository(IRestClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Album>> GetAsync(int? userId)
        {
            var albums = await GetAllAsync();

            if (userId.HasValue)
            {
                return albums.Where(item => item.UserId.Equals(userId.Value)).ToList();
            }

            return albums;
        }

        private async Task<IEnumerable<Album>> GetAllAsync() => await _client.RunAsListAsync<Album>(PATH_TO_ALBUMS);
    }
}
