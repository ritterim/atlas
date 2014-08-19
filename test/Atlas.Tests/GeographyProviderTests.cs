using System;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace Ritter.Atlas
{
    public class GeographyProviderTests
    {
        private const string ZipCodeHeader =
            "\"StateCode\",\"Id\",\"Latitude\",\"Longitude\",\"SCFCode\",\"TimeZone\"";

        [Fact]
        public void ZipCodes_MapsPropertiesCorrectly()
        {
            var data = ZipCodeHeader + Environment.NewLine + "\"AK\",\"99678\",\"59.17348\",\"-160.71555\",\"996\",\"-9\"";

            var fakeAssembly = new FakeAssembly();
            fakeAssembly.Resources.Add("Ritter.Atlas.Resources.ZipCodes.csv", new MemoryStream(Encoding.UTF8.GetBytes(data)));

            var fakeResources = ResourceContainer.FromAssembly(fakeAssembly);

            var target = new GeographyProvider(fakeResources);

            var actual = target.ZipCodes().Single();

            Assert.Equal("99678", actual.Id);
        }
    }
}
