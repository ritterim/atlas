using System.Collections.Concurrent;
using System.IO;
using System.Reflection;

namespace Ritter.Atlas
{
    public class ResourceContainer
    {
        private static readonly ConcurrentDictionary<Assembly, ResourceContainer> AssemblyCache =
            new ConcurrentDictionary<Assembly, ResourceContainer>();

        public static ResourceContainer FromAssembly(Assembly assembly)
        {
            return AssemblyCache.GetOrAdd(assembly, x => new ResourceContainer(x));
        }

        private ResourceContainer(Assembly assembly)
        {
            Assembly = assembly;
        }

        public Assembly Assembly { get; private set; }

        public TextReader Load(string name)
        {
            Stream stream;
            if (Assembly.TryGetManifestResourceStream(name, out stream))
            {
                return new StreamReader(stream);
            }

            return TextReader.Null;
        }
    }
}
