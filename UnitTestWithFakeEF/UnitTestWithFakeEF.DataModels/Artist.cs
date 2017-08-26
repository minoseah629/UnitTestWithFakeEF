using System.Collections.Generic;

namespace UnitTestWithFakeEF.DataModels
{
    public class Artist
    {
        public Artist()
        {
            Albums = new HashSet<Album>();
            Tracks = new HashSet<Track>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
        public virtual ICollection<Track> Tracks { get; set; }
    }
}