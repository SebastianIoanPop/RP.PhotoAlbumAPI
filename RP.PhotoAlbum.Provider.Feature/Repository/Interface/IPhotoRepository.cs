using System.Collections.Generic;
using System.Threading.Tasks;
using RP.PhotoAlbum.Provider.Feature.Domain;

namespace RP.PhotoAlbum.Provider.Feature.Repository.Interface
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetAllAsync();
    }
}
