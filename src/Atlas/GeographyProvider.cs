using System.Collections.Generic;
using CsvHelper;

namespace Ritter.Atlas
{
    public class GeographyProvider
    {
        public GeographyProvider(ResourceContainer resourceContainer)
        {
            Resources = resourceContainer;
        }

        public ResourceContainer Resources { get; private set; }

        public IEnumerable<State> States()
        {
            return ParseResource<State>("Ritter.Atlas.Resources.States.csv");
        }

        public IEnumerable<County> Counties()
        {
            return ParseResource<County>("Ritter.Atlas.Resources.Counties.csv");
        }

        public IEnumerable<CountyZipCode> CountyZipCodes()
        {
            return ParseResource<CountyZipCode>("Ritter.Atlas.Resources.CountyZipCodes.csv");
        }

        public IEnumerable<ZipCode> ZipCodes()
        {
            return ParseResource<ZipCode>("Ritter.Atlas.Resources.ZipCodes.csv");
        }

        protected virtual IEnumerable<T> ParseResource<T>(string name)
        {
            using (var textReader = Resources.Load(name))
            using (var csvReader = new CsvReader(textReader))
            {
                while (csvReader.Read())
                {
                    yield return csvReader.GetRecord<T>();
                }
            }
        }
    }
}
