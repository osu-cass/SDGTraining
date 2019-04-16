using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplePro.Dal.Extensions
{
    public abstract class CacheItemBase
    {
        private Guid m_key = Guid.NewGuid();

        public Guid Key
        {
            get
            {
                return m_key;
            }
        }

        public abstract Type ItemType { get; }
        public DateTime CacheDate { get; protected set; }
        public TimeSpan CacheLength { get; protected set; }
    }
}
