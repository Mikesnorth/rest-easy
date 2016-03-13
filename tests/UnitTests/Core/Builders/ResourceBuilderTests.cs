using Shouldly;
using NUnit.Framework;
using RestEasy.Core.Builders;

namespace RestEasy.UnitTests.Core.Builders {

    [TestFixture]
    public class ResourceBuilderTests {

        [Test]
        public void Builder_should_create_instance_configured_for_the_given_resource_type() {
            var builderInstance = new ResourceBuilder().For<TestResource>();
            builderInstance.ShouldBeAssignableTo<IResourceBuilderInstance<TestResource>>();
        }

    }

}