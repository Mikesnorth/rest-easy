using System;

namespace RestEasy.Core.Builders {

    public class ResourceBuilderInstance<TResource> : IResourceBuilderInstance<TResource> where TResource : Resource, new() {

        #region Private Members

        private readonly TResource _resource;

        #endregion

        #region Constructors / Destructors

        public ResourceBuilderInstance() {
            _resource = new TResource();
        }

        #endregion

        #region IResourceBuilderInstance<TResource> Implementation

        public TResource Build(Action<TResource> translation = null) {
            translation?.Invoke(_resource);
            return _resource;
        }

        public IResourceBuilderInstance<TResource> WithLink(string resourceName, Uri resourceUri) {
            _resource.AddLink(resourceName, resourceUri);
            return this;
        }

        #endregion

    }

}