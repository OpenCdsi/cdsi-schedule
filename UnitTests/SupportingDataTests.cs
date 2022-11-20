using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCdsi;
using OpenCdsi.Schedule;
using System.Collections.Generic;

namespace OpenCdsi.UnitTests
{
    [TestClass]
    public class SupportingDataTests
    {
        const int ANTIGEN_COUNT = 26;
        const string RESOURCCE_VERSION = "4.38";

        [TestMethod]
        public void CheckVersionNumber() 
        {
            Assert.AreEqual(RESOURCCE_VERSION, Metadata.ResourceVersion);
        }
        
        [TestMethod]
        public void AntigenNames()
        {
            Assert.AreEqual(ANTIGEN_COUNT, SupportingData.Antigens.Count);
        }

        [TestMethod]
        public void CanReadAntigenData()
        {
            var key = "Cholera";
            var data = SupportingData.Antigens[key];
            Assert.AreEqual(key, data.series[0].targetDisease);
        }

        [TestMethod]
        public void CanGetAntigenData()
        {
            var key = "Cholera";
            var data = SupportingData.Antigens.Get(key);
            Assert.AreEqual(key, data.series[0].targetDisease);
        }

        [TestMethod]
        public void GettingUnknownAntigenDataReturnsDefault()
        {
            var key = "CoronaWithLime";
            var data = SupportingData.Antigens.Get(key);
            Assert.AreEqual(default, data);
        }

        [TestMethod]
        public void CanReadCvxData()
        {
            Assert.IsInstanceOfType(SupportingData.Schedule.Vaccines, typeof(IEnumerable<scheduleSupportingDataCvxMap>));
        }

        [TestMethod]
        public void CanGetCvxDataByCvx()
        {
            Assert.IsInstanceOfType(SupportingData.Schedule.Vaccines.Get("01"), typeof(scheduleSupportingDataCvxMap));
        }

        [TestMethod]
        public void CanReadLiveVirusConflictData()
        {
            Assert.IsInstanceOfType(SupportingData.Schedule.LiveVirusConflicts, typeof(IEnumerable<scheduleSupportingDataLiveVirusConflict>));
        }

        [TestMethod]
        public void CanReadObservationData()
        {
            Assert.IsInstanceOfType(SupportingData.Schedule.Observations, typeof(IEnumerable<scheduleSupportingDataObservation>));
        }

        [TestMethod]
        public void CanGetdObservationDataByCode()
        {
            Assert.IsInstanceOfType(SupportingData.Schedule.Observations.Get(1), typeof(scheduleSupportingDataObservation));
        }

        [TestMethod]
        public void CanReadVaccineGroupData()
        {  
            Assert.IsInstanceOfType(SupportingData.Schedule.VaccineGroups, typeof(IEnumerable<scheduleSupportingDataVaccineGroup>));
        }
    }
}
