using Xunit;

namespace Ritter.Atlas
{
    public class ZipCodeTests
    {
        [Fact]
        public void ScfCode_CanDeriveFromZipCode()
        {
            var zipcode = new ZipCode { Id = "17011" };
            Assert.Equal("170", zipcode.ScfCode);
        }

        [Fact]
        public void ScfCode_NoErrorOnNullId()
        {
            var zipcode = new ZipCode { Id = null };
            Assert.Equal(string.Empty, zipcode.ScfCode);
        }
    }
}