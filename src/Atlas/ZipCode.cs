using System;

namespace Ritter.Atlas
{
    public sealed class ZipCode
    {
        public string Id { get; set; }

        public string StateCode { get; set; }

        public float Latitude { get; set; }

        public float Longitude { get; set; }
    }
}
