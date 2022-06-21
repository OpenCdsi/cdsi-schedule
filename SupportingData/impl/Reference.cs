using System.Collections.Generic;
using Cdsi.SupportingData;

namespace Cdsi
{
    public static partial class Data
    {
        public static scheduleSupportingData Schedule { get; } = Factories.CreateSupportingData();

        public static IDictionary<string, antigenSupportingData> Antigen { get; } = Factories.CreateAntigenMap();
    }
}
