using System.Collections.Generic;
using System.Threading.Tasks;
using RP.PhotoAlbum.Provider.Feature.Domain;

namespace RP.PhotoAlbum.Provider.Feature.Repository.Interface
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<Album>> GetAsync(int? UserId);
    }
}
