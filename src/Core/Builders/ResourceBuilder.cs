namespace RestEasy.Core.Builders {

    public class ResourceBuilder : IResourceBuilder {

        #region IResourceBuilder Implementation

        public IResourceBuilderInstance<TResource> For<TResource>() where TResource : Resource, new() {
            return new ResourceBuilderInstance<TResource>();
        }

        #endregion

    }

}