using System.Collections.Generic;
using OpenCdsi.SupportingData;

namespace OpenCdsi
{
    public static partial class Data
    {
        public static scheduleSupportingData Schedule { get; } = Factories.CreateSupportingData();

        public static IDictionary<string, antigenSupportingData> Antigen { get; } = Factories.CreateAntigenMap();
    }
}
