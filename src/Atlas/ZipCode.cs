using System;
using System.Linq;

namespace Ritter.Atlas
{
    public sealed class ZipCode
    {
        public string Id { get; set; }

        public string StateCode { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }

        public float Elevation { get; set; }

        public int TimeZone { get; set; }

        public string PrimaryCity { get; set; }

        public string ScfCode
        {
            get { return new string((Id ?? string.Empty).Take(3).ToArray()); }
        }
    }
}
