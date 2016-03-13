using System;
using NUnit.Framework;
using Shouldly;

namespace RestEasy.UnitTests.Core {

    [TestFixture]
    public class ResourceTests {

        private const string ResourceName = "self";

        private readonly Uri _resourceUri = new Uri("http://domain.com/resources/5");

        [Test]
        public void An_ArgumentException_should_be_thrown_when_an_invalid_resourceName_is_given_for_a_link() {
            var resource = new TestResource();
            Should.Throw<ArgumentException>(() => resource.AddLink(string.Empty, _resourceUri));
        }

        [Test]
        public void An_ArgumentException_should_be_thrown_when_an_invalid_resourceUri_is_given_for_a_link() {
            var resource = new TestResource();
            Should.Throw<ArgumentException>(() => resource.AddLink(ResourceName, null));
        }

        [Test]
        public void An_InvalidOperationException_should_be_thrown_if_a_link_for_the_same_resouce_is_added_multiple_times() {
            var resource = new TestResource();
            resource.AddLink(ResourceName, _resourceUri);
            Should.Throw<InvalidOperationException>(() => resource.AddLink(ResourceName, _resourceUri));
        }

        [Test]
        public void Valid_links_should_be_added_to_the_resource_instance() {
            var resource = new TestResource();
            resource.AddLink(ResourceName, _resourceUri);
            resource.ResourceLinks.ShouldContain(x => x.Key == ResourceName);
        }
        
    }
    
}