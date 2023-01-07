using Godot;
using System.Collections.Generic;

namespace PurpleCable
{
    public class NamedResourceDictionary<TResource> : ResourceDictionary<string, TResource>
        where TResource : Resource
    {
        #region Initialisation

        public NamedResourceDictionary(string path)
            : base(path)
        { }

        public NamedResourceDictionary(IEnumerable<TResource> resources)
            : base(resources)
        { }

        #endregion

        #region Methods

        protected override string GetKeyForItem(TResource item)
        {
            return item.ResourceName;
        }

        #endregion
    }
}
