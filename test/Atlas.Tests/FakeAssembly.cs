using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Ritter.Atlas
{
    public class FakeAssembly : Assembly
    {
        public FakeAssembly()
        {
            Resources = new Dictionary<string, Stream>();
        }

        public IDictionary<string, Stream> Resources { get; private set; }

        public override string[] GetManifestResourceNames()
        {
            return Resources.Keys.ToArray();
        }

        public override Stream GetManifestResourceStream(string name)
        {
            return Resources[name];
        }
    }
}