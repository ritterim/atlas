using System.IO;
using System.Linq;
using System.Reflection;

namespace Ritter.Atlas
{
    internal static class AssemblyExtensions
    {
        public static bool TryGetManifestResourceStream(this Assembly assembly, string name, out Stream stream)
        {
            if (!string.IsNullOrEmpty(name) && assembly.GetManifestResourceNames().Any(x => x == name))
            {
                stream = assembly.GetManifestResourceStream(name);
                return true;
            }

            stream = Stream.Null;
            return false;
        }
    }
}
