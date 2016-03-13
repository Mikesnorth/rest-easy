using System.Collections.Generic;
using RestEasy.Core;

namespace RestEasy.UnitTests.Core {

    internal class TestResource : Resource {

        public IDictionary<string, string> ResourceLinks => Links;

        public int Id { get; set; }

    }

}