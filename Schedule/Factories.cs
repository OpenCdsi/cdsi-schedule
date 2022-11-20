using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace OpenCdsi.Schedule
{
    public static class Factories
    {
        private const string ScheduleResourceName = "OpenCdsi.Schedule.resources.ScheduleSupportingData.xml";
       private static readonly Regex AntigenResourceNameRegex = new Regex("OpenCdsi.Schedule.resources.AntigenSupportingData-\\s*([\\w\\s]*)-508.xml");

        public static IDictionary<string, antigenSupportingData> ReadAntigenData()
        {
            var deserializer = new XmlSerializer(typeof(antigenSupportingData));
            var assembly = Assembly.GetAssembly(typeof(Metadata));

            return assembly.GetManifestResourceNames()
                  .Select(x => Tuple.Create(x, AntigenResourceNameRegex.Match(x)))
                  .Where(x => x.Item2.Success)
                  .Select(x => assembly.GetManifestResourceStream(x.Item1))
                  .Select(x => (antigenSupportingData)deserializer.Deserialize(x))
                  .Select(x => KeyValuePair.Create(x.series[0].targetDisease, x))
                  .ToDictionary(x=>x.Key,x=>x.Value);
        }

        public static scheduleSupportingData ReadScheduleData()
        {
            var assembly = Assembly.GetAssembly(typeof(Metadata));
            var resource = assembly.GetManifestResourceStream(ScheduleResourceName);
            var deserializer = new XmlSerializer(typeof(scheduleSupportingData));
            return (scheduleSupportingData)deserializer.Deserialize(resource);
        }
    }
}
