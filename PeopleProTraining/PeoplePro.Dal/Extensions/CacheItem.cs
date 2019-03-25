using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplePro.Dal.Extensions
{
    public class CacheItem<T> : CacheItemBase
    {
        #region Members

        public delegate T RefreshDelegate();

        #endregion

        #region Constructors

        public CacheItem(int cacheTimeInMinutes, T objectToCache) : this(new TimeSpan(0, cacheTimeInMinutes, 0), objectToCache, null) { }

        public CacheItem(T objectToCache) : this(TimeSpan.MaxValue, objectToCache, null) { }

        public CacheItem(int cacheTimeInMinutes, RefreshDelegate del)
        {
            base.CacheLength = new TimeSpan(0, cacheTimeInMinutes, 0);
            this.BaseItem = del();
            this.RefreshMethod = del;
            base.CacheDate = DateTime.Now;
        }

        public CacheItem(TimeSpan cacheSpan, T objectToCache, RefreshDelegate del)
        {
            base.CacheDate = DateTime.Now;
            base.CacheLength = cacheSpan;
            this.BaseItem = objectToCache;
            this.RefreshMethod = del;
        }

        #endregion

        #region Overrides

        public override Type ItemType
        {
            get
            {
                return typeof(T);
            }
        }

        #endregion

        #region Properties

        private T BaseItem { get; set; }
        public RefreshDelegate RefreshMethod { get; set; }

        public bool IsExpired
        {
            get
            {
                return DateTime.Now > (this.CacheDate.Add(this.CacheLength));
            }
        }

        #endregion

        #region Methods

        public T GetItem()
        {
            if (this.IsExpired)
            {
                this.Refresh();
            }

            return this.BaseItem;
        }

        public void Refresh()
        {
            if (this.RefreshMethod == null)
            {
                throw new NullReferenceException("Cannot refresh cache if CacheItem.RefreshMethod is null");
            }
            else
            {
                this.BaseItem = this.RefreshMethod();
                this.CacheDate = DateTime.Now;
            }
        }

        #endregion
    }
}
