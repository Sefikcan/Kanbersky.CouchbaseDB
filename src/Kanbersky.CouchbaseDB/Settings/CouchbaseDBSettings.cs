using System.Collections.Generic;

namespace Kanbersky.CouchbaseDB.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public class CouchbaseDBSettings
    {
        /// <summary>
        /// ctor
        /// </summary>
        public CouchbaseDBSettings()
        {
            Servers = new List<string>();
        }

        /// <summary>
        /// Servers
        /// </summary>
        public List<string> Servers { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// UseSsl
        /// </summary>
        public bool UseSsl { get; set; }
    }
}
