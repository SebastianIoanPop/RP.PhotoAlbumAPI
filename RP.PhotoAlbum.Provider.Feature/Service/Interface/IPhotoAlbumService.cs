using System.Collections.Generic;
using System.Threading.Tasks;
using RP.PhotoAlbum.Provider.Feature.Domain;

namespace RP.PhotoAlbum.Provider.Feature.Service.Interface
{
    public interface IPhotoAlbumService
    {
        Task<IEnumerable<Album>> GetAsync(int? albumId);
    }
}
