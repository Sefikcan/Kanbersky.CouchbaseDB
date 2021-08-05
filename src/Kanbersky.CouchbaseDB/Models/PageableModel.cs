using System.Collections.Generic;

namespace Kanbersky.CouchbaseDB.Models
{
    /// <summary>
    /// Pageable Model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageableModel<T>
    {
        /// <summary>
        /// Data Items
        /// </summary>
        public IList<T> Items { get; set; }

        /// <summary>
        /// Page Number
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Page Size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total Page Count
        /// </summary>
        public int TotalPageCount { get; set; }

        /// <summary>
        /// Total Item Count
        /// </summary>
        public int TotalItemCount { get; set; }
    }
}
