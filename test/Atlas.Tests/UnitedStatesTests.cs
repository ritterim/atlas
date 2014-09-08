using Xunit;

namespace Ritter.Atlas
{
    public class UnitedStatesTests
    {
        [Fact]
        public void States_IsNotEmpty()
        {
            Assert.NotEmpty(UnitedStates.States());
        }

        [Fact]
        public void Counties_IsNotEmpty()
        {
            Assert.NotEmpty(UnitedStates.Counties());
        }

        [Fact]
        public void CountyZipCodes_IsNotEmpty()
        {
            Assert.NotEmpty(UnitedStates.CountyZipCodes());
        }

        [Fact]
        public void ZipCodes_IsNotEmpty()
        {
            Assert.NotEmpty(UnitedStates.ZipCodes());
        }
    }
}
