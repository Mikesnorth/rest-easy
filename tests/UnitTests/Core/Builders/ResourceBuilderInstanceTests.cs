using System;
using System.Reflection;
using NUnit.Framework;
using RestEasy.Core;
using RestEasy.Core.Builders;
using Shouldly;

namespace RestEasy.UnitTests.Core.Builders {

    [TestFixture]

    public class ResourceBuilderInstanceTests {

        private const string ResourceName = "self";

        private readonly Uri _resourceUri = new Uri("http://domain.com/resources/5");

        [Test]
        public void Links_should_be_added_to_a_resource() {

            var builder = new ResourceBuilder().For<TestResource>();
            builder.WithLink(ResourceName, _resourceUri);

            var resource = GetResource(builder);
            resource.ResourceLinks.ShouldContain(x => x.Key == ResourceName);

        }

        [Test]
        public void Build_should_return_a_resource_with_all_links_defined() {

            var builder = new ResourceBuilder().For<TestResource>();
            builder.WithLink(ResourceName, _resourceUri);

            var resource = builder.Build();
            resource.ResourceLinks.ShouldContain(x => x.Key == ResourceName);

        }

        [Test]
        public void Translation_action_should_be_correctly_applied_to_the_constructed_resource() {

            const int resourceId = 1234;
            var builder = new ResourceBuilder().For<TestResource>();

            var resource = builder.Build(x => x.Id = resourceId);
            resource.Id.ShouldBe(resourceId);

        }

        private static TResource GetResource<TResource>(IResourceBuilderInstance<TResource> resourceBuilderInstance) where TResource : Resource, new() {
            var resourceField = resourceBuilderInstance.GetType().GetField("_resource", BindingFlags.Instance | BindingFlags.NonPublic);
            if (resourceField == null) return new TResource();
            return (TResource) resourceField.GetValue(resourceBuilderInstance);
        }

    }

}