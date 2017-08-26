using System.Collections.Generic;

namespace UnitTestWithFakeEF.DataModels
{
    public class Album
    {
        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        public int Id { get; set; }

        public string Title { get; set; }
        
        public int Order { get; set; }

        public virtual Artist Artist { get; set; }
        
        public virtual ICollection<Track> Tracks { get; set; }
    }
}