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
            "StateCode,Id,Latitude,Longitude,Elevation,TimeZone,PrimaryCity";

        [Fact]
        public void ZipCodes_MapsPropertiesCorrectly()
        {
            var data = ZipCodeHeader + Environment.NewLine + "NY,00501,40.815400,-73.045600,25,-5 ,HOLTSVILLE";

            var fakeAssembly = new FakeAssembly();
            fakeAssembly.Resources.Add("Ritter.Atlas.Resources.ZipCodes.csv", new MemoryStream(Encoding.UTF8.GetBytes(data)));

            var fakeResources = ResourceContainer.FromAssembly(fakeAssembly);

            var target = new GeographyProvider(fakeResources);

            var actual = target.ZipCodes().Single();

            Assert.Equal("00501", actual.Id);
            Assert.Equal("NY", actual.StateCode);
            Assert.Equal(40.815400f, actual.Latitude);
            Assert.Equal(-73.045600f, actual.Longitude);
            Assert.Equal(-5, actual.TimeZone);
            Assert.Equal("HOLTSVILLE", actual.PrimaryCity);
        }
    }
}
