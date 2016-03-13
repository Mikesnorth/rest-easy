using System;

namespace RestEasy.Core.Builders {

    /// <summary>
    /// Contract definition for resource builder instance.
    /// </summary>
    /// <typeparam name="TResource">The type of resource the builder will construct.</typeparam>
    public interface IResourceBuilderInstance<out TResource> where TResource : Resource, new() {

        /// <summary>
        /// Constructs a resource of type TResource based on the current level
        /// of configuration. The new resource will be run through the translation
        /// action, if specified.
        /// </summary>
        /// <param name="translation">The translation function for the resource.</param>
        /// <returns>Returns a resource of type TResource.</returns>
        TResource Build(Action<TResource> translation = null);

        /// <summary>
        /// Adds a new link URI to the builder's configuration to eventually be
        /// added to the final resource.
        /// </summary>
        /// <param name="resourceName">The name of the link resource (i.e. "self").</param>
        /// <param name="resourceUri">The URI for the link resource.</param>
        /// <returns>Returns the current IResourceBuilderInstance.</returns>
        IResourceBuilderInstance<TResource> WithLink(string resourceName, Uri resourceUri);
        
    }

}