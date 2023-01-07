using Godot;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PurpleCable
{
    public abstract class ResourceDictionary<TKey, TResource> : KeyedCollection<TKey, TResource>
        where TResource : Resource
    {
        #region Initialisation

        protected ResourceDictionary(string path)
            : this(Resources.LoadAll<TResource>(path))
        { }

        protected ResourceDictionary(IEnumerable<TResource> resources)
        {
            foreach (TResource resource in resources)
            {
                Add(resource);
            }
        }

        #endregion

        #region Methods

        public TResource Get(TKey key)
            => (Contains(key) ? this[key] : null);

        public TResource GetRandom()
            => this.ToArray().GetRandom();

        public TResource[] GetItems()
            => this.ToArray();

        #endregion
    }
}
