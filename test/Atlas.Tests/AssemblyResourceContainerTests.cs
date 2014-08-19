using System.IO;
using System.Text;
using Xunit;

namespace Ritter.Atlas
{
    public class AssemblyResourceContainerTests
    {
        [Fact]
        public void Load_WhenAssemblyDoesNotContainResource_ReturnsNullTextReader()
        {
            var fakeAssembly = new FakeAssembly();

            var target = ResourceContainer.FromAssembly(fakeAssembly);

            var actual = target.Load(null);

            Assert.Same(TextReader.Null, actual);
        }

        [Fact]
        public void Load_WhenAssemblyContainsResource_DoesNotReturnNullTextReader()
        {
            const string ResourceName = "Foobar";

            var expected = new MemoryStream(Encoding.ASCII.GetBytes(ResourceName));

            var fakeAssembly = new FakeAssembly();
            fakeAssembly.Resources.Add(ResourceName, expected);

            var target = ResourceContainer.FromAssembly(fakeAssembly);

            var actual = target.Load(ResourceName);

            Assert.Equal(ResourceName, actual.ReadToEnd());
        }

        [Fact]
        public void FromAssembly_CachesInstances()
        {
            var fakeAssembly = new FakeAssembly();

            var expected = ResourceContainer.FromAssembly(fakeAssembly);

            var actual = ResourceContainer.FromAssembly(fakeAssembly);

            Assert.Same(expected, actual);
        }
    }
}
