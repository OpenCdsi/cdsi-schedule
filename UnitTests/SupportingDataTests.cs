using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cdsi.SupportingData;

namespace Cdsi.UnitTests
{
    [TestClass]
    public class SupportingDataTests
    {
        [TestMethod]
        public void AntigenNames()
        {
            var names = Library.Antigen.Keys;
            Assert.AreEqual(23, names.Count);
        }

        [TestMethod]
        public void CanReadAntigenData()
        {
            var key = "Cholera";
            var data = Library.Antigen[key];
            Assert.AreEqual(key, data.series[0].targetDisease);
        }

        [TestMethod]
        public void CanReadcheduleData()
        {
            var data = Library.Schedule;
            Assert.IsInstanceOfType(data, typeof(scheduleSupportingData));
        }
    }
}
