using System.Collections.Generic;

namespace RP.PhotoAlbum.Provider.Feature.Domain
{
    public class Album
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
