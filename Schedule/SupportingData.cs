using System.Collections.Generic;
using OpenCdsi.Schedule;

namespace OpenCdsi
{
    public class SupportingData
    {
        internal static scheduleSupportingData _schedule = Factories.ReadScheduleData();

        internal static IDictionary<string, antigenSupportingData> _antigens = Factories.ReadAntigenData();

        public class Schedule
        {

            public static IEnumerable<scheduleSupportingDataLiveVirusConflict> LiveVirusConflicts => _schedule.liveVirusConflicts;
            public static IEnumerable<scheduleSupportingDataVaccineGroup> VaccineGroups => _schedule.vaccineGroups;
            public static IEnumerable<scheduleSupportingDataCvxMap> Vaccines => _schedule.cvxToAntigenMap;
            public static IEnumerable<scheduleSupportingDataObservation> Observations => _schedule.observations;
        }
        public static string ResourceVersion => Metadata.ResourceVersion;
        public static IReadOnlyDictionary<string, antigenSupportingData> Antigens => (IReadOnlyDictionary<string, antigenSupportingData>)_antigens;
    }
}
