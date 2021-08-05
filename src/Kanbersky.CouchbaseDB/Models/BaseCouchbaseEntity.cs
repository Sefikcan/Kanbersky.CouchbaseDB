using System;

namespace Kanbersky.CouchbaseDB.Models
{
    public abstract class BaseCouchbaseEntity
    {
        public BaseCouchbaseEntity()
        {
            CreatedDate = new DateTime();
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }

        public DateTime CreatedDate { get; private set; }
    }
}
