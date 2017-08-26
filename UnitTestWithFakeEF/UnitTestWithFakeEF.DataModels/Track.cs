using System;

namespace UnitTestWithFakeEF.DataModels
{
    public class Track
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Length { get; set; }
        public int TrackOrder { get; set; }
        
        public virtual Album Album { get; set; }

        public virtual Artist Artist { get; set; }
    }
}