using System.Collections.Generic;
using System.Linq;

namespace OpenCdsi.Schedule
{
    public static class ScheduleDataHelpers
    {
        public static IEnumerable<scheduleSupportingDataLiveVirusConflict> Get(this IEnumerable<scheduleSupportingDataLiveVirusConflict> store, string idx)
        {
            return store.Where(item => item.current.cvx == idx);
        }
        public static IEnumerable<scheduleSupportingDataLiveVirusConflict> Get(this IEnumerable<scheduleSupportingDataLiveVirusConflict> store, int idx)
        {
            return store.Where(item => int.Parse(item.current.cvx) == idx);
        }
        public static scheduleSupportingDataVaccineGroup Get(this IEnumerable<scheduleSupportingDataVaccineGroup> store, string idx)
        {
            return store.FirstOrDefault(item => item.name == idx);
        }
        public static IEnumerable<string> Antigens(this scheduleSupportingDataVaccineGroup store)
        {
            return Cdsi._schedule.vaccineGroupToAntigenMap
                .Where(item => item.name == store.name)
                .SelectMany(item => item.antigen);
        }
        public static scheduleSupportingDataCvxMap Get(this IEnumerable<scheduleSupportingDataCvxMap> store, string idx)
        {
            return store.FirstOrDefault(item => item.cvx == idx);
        }
        public static scheduleSupportingDataCvxMap Get(this IEnumerable<scheduleSupportingDataCvxMap> store, int idx)
        {
            return store.FirstOrDefault(item => int.Parse(item.cvx) == idx);
        }
        public static IEnumerable<scheduleSupportingDataCvxMapAssociation> Assocations(this scheduleSupportingDataCvxMap store)
        {
            return store.association;
        }
        public static scheduleSupportingDataCvxMapAssociation Assocations(this scheduleSupportingDataCvxMap store, string idx)
        {
            return store.association.FirstOrDefault(item => item.antigen == idx);
        }
        public static scheduleSupportingDataObservation Get(this IEnumerable<scheduleSupportingDataObservation> store, string idx)
        {
            return store.FirstOrDefault(item => item.observationCode == idx);
        }
        public static scheduleSupportingDataObservation Get(this IEnumerable<scheduleSupportingDataObservation> store, int idx)
        {
            return store.FirstOrDefault(item => int.Parse(item.observationCode) == idx);
        }
        public static antigenSupportingData Get(this IReadOnlyDictionary<string, antigenSupportingData> store, string idx)
        {
            if (store.TryGetValue(idx, out antigenSupportingData value))
                return value;
            else
                return default;
        }
    }
}
