using RP.PhotoAlbum.Provider.Feature.Domain;
using System.Collections.Generic;
using System.Linq;

namespace RP.PhotoAlbum.Provider.Feature.Extensions
{
    /// <note>
    /// This is a simple PhotoFilter using LINQ
    /// An alternative to this would be to break the photos into a map where the KEY would be the albumId and the VALUE the list of photos of the album
    /// This alternative would be much more efficient if processing large lists as the filtering will only happen once
    /// </note>
    public static class PhotoFilter
    {
        public static void FilterPhotos(this Album album, IEnumerable<Photo> photos)
        {
            album.Photos = photos.Where(item => item.AlbumId.Equals(album.Id)).ToList();
        }
    }
}
