﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdsi.UnitTests
{
    internal class DoseTestEnv
    {
        public IEnumerable<IAntigenDose> Doses { get; set; }
        public IEnumerable<ITargetDose> Targets { get; set; }

        public DoseTestEnv(string testcaseId, string antigenName)
        {
            Doses = GetAntigenDosesFromTestcase(testcaseId);
            Targets = GetTargetDosesFromSupportingData(antigenName);
        }

        private static IEnumerable<IAntigenDose> GetAntigenDosesFromTestcase(string testcaseId)
        {
            var testcase = Library.Testcases[testcaseId];
            var doses = testcase.Doses
                .Select(x => x.ToEhr())
                .SelectMany(x => x.AsAntigenDoses())
                .OrderBy(x => x.AntigenName)
                .ThenBy(x => x.AdministeredDose.DateAdministered);

            return doses;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="antigenName"></param>
        /// <returns></returns>
        /// <remarks>Fetches the first series from the antigen data. More elaborate tests might
        /// need to select a risk series or a different standard series.</remarks>
        private static IEnumerable<ITargetDose> GetTargetDosesFromSupportingData(string antigenName)
        {
            var series = SupportingData.Antigen[antigenName].series[0].ToModel();
            return series.TargetDoses;
        }
    }
}
