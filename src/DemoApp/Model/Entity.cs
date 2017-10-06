using System;

namespace DemoApp.Model
{
    public class Entity<TId>
        where TId : struct
    {
        public TId Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}