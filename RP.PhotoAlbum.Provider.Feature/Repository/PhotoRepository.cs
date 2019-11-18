using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RP.PhotoAlbum.Provider.Feature.Domain;
using RP.PhotoAlbum.Provider.Feature.Extensions;
using RP.PhotoAlbum.Provider.Feature.Repository.Interface;

namespace RP.PhotoAlbum.Provider.Feature.Repository
{
    public class PhotoRepository : IPhotoRepository
    {
        private const string PATH_TO_PHOTOS = "photos";

        private readonly IRestClient _client;

        public PhotoRepository(IRestClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Photo>> GetAllAsync()
        {
            return await _client.RunAsListAsync<Photo>(PATH_TO_PHOTOS);
        }
    }
}
