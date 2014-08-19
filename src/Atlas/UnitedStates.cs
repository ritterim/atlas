using System.Collections.Generic;

namespace Ritter.Atlas
{
    public static class UnitedStates
    {
        private static readonly GeographyProvider Provider = 
            new GeographyProvider(ResourceContainer.FromAssembly(typeof(UnitedStates).Assembly));

        public static IEnumerable<State> States()
        {
            return Provider.States();
        }

        public static IEnumerable<County> Counties()
        {
            return Provider.Counties();
        }

        public static IEnumerable<ZipCode> ZipCodes()
        {
            return Provider.ZipCodes();
        }
    }
}
