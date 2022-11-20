using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenCdsi.Schedule;
using OpenCdsi;
using System.Collections.Generic;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class SupportingDataTests
    {
        const int ANTIGEN_COUNT = 26;
        const string SUPPORTING_DATA_VERSION = "4.38";

        [TestMethod]
        public void CheckVersionNumber() 
        {
            Assert.AreEqual(SUPPORTING_DATA_VERSION, Metadata.SupportingDataVersion);
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
            Assert.IsInstanceOfType(SupportingData.Vaccines, typeof(IEnumerable<scheduleSupportingDataCvxMap>));
        }

        [TestMethod]
        public void CanGetCvxDataByCvx()
        {
            Assert.IsInstanceOfType(SupportingData.Vaccines.Get("01"), typeof(scheduleSupportingDataCvxMap));
        }

        [TestMethod]
        public void CanReadLiveVirusConflictData()
        {
            Assert.IsInstanceOfType(SupportingData.LiveVirusConflicts, typeof(IEnumerable<scheduleSupportingDataLiveVirusConflict>));
        }

        [TestMethod]
        public void CanReadObservationData()
        {
            Assert.IsInstanceOfType(SupportingData.Observations, typeof(IEnumerable<scheduleSupportingDataObservation>));
        }

        [TestMethod]
        public void CanGetdObservationDataByCode()
        {
            Assert.IsInstanceOfType(SupportingData.Observations.Get(1), typeof(scheduleSupportingDataObservation));
        }

        [TestMethod]
        public void CanReadVaccineGroupData()
        {  
            Assert.IsInstanceOfType(SupportingData.VaccineGroups, typeof(IEnumerable<scheduleSupportingDataVaccineGroup>));
        }
    }
}
