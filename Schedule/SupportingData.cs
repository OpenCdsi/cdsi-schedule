using System.Collections.Generic;
using OpenCdsi.Schedule;

namespace System
{
    public partial class Cdsi
    {
        public static class Schedule
        {
            internal static scheduleSupportingData _schedule = Factories.ReadScheduleData();

            internal static IDictionary<string, antigenSupportingData> _antigens = Factories.ReadAntigenData();
            public static IEnumerable<scheduleSupportingDataLiveVirusConflict> LiveVirusConflicts => _schedule.liveVirusConflicts;
            public static IEnumerable<scheduleSupportingDataVaccineGroup> VaccineGroups => _schedule.vaccineGroups;
            public static IEnumerable<scheduleSupportingDataCvxMap> Vaccines => _schedule.cvxToAntigenMap;
            public static IEnumerable<scheduleSupportingDataObservation> Observations => _schedule.observations;
            public static IDictionary<string, antigenSupportingData> Antigens => _antigens;
        }
    }
}