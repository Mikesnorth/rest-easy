namespace RestEasy.Core.Builders {

    /// <summary>
    /// Contract definition for base resource builder.
    /// </summary>
    public interface IResourceBuilder {

        /// <summary>
        /// Creates an instance of IResourceBuilderInstance configured to build
        /// a resource of type TResource.
        /// </summary>
        /// <typeparam name="TResource">The type of resource to construct.</typeparam>
        /// <returns>Returns a configured instance of IResourceBuilderInstance.</returns>
        IResourceBuilderInstance<TResource> For<TResource>() where TResource : Resource, new();

    }

}