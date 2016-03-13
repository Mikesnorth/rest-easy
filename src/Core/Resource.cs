using System;
using EnsureThat;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestEasy.Core {

    public abstract class Resource {

        [JsonProperty("_links")]
        protected readonly IDictionary<string, string> Links;

        protected Resource() {
            Links = new Dictionary<string, string>();
        }

        public void AddLink(string resourceName, Uri resourceUri) {

            Ensure.That(resourceName).IsNotNullOrEmpty();
            Ensure.That(resourceUri).IsNotNull();

            if (Links.ContainsKey(resourceName)) {
                throw new InvalidOperationException($"A link to resource \"{resourceName}\" has already been added.");
            }

            Links.Add(resourceName, resourceUri.AbsoluteUri);

        }

    }

}