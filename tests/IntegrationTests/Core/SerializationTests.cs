using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using RestEasy.Core;
using Shouldly;

namespace RestEasy.IntegrationTests.Core {

    [TestFixture]
    public class SerializationTests {

        private const string ResourceName = "self";

        private static readonly Uri ResourceUri = new Uri("http://domain.com/resources/5");

        private readonly string _serializedJson = $"{{\"_links\":{{\"{ResourceName}\":\"{ResourceUri}\"}}}}";

        [Test]
        public void Resource_links_should_be_preserved_when_serialized_to_JSON() {

            var resource = new TestResource();
            resource.AddLink(ResourceName, ResourceUri);

            var json = JsonConvert.SerializeObject(resource);
            json.ShouldBe(_serializedJson);

        }

        [Test]
        public void Resource_links_should_be_preserved_when_deserialized_from_JSON() {

            var resource = JsonConvert.DeserializeObject<TestResource>(_serializedJson);
            resource.ResourceLinks.ShouldContain(x => x.Key == ResourceName);

        }

    }

    internal class TestResource : Resource {
        [JsonIgnore]
        public IDictionary<string, string> ResourceLinks => Links;
    }

}