using DotNet.DAL;
using DotNet.Models.Warning;
using DotNet.Services.Analyzares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services
{
    public class BookWarningManager
    {
        private List<IAnalyzator> _analyzators;

        public BookWarningManager(List<IAnalyzator> analyzators)
        {
            this._analyzators = analyzators;
        }

        public List<BookWarning> Warn()
        {
            var warnings = new List<BookWarning>();

            //Przeanalizować dane
            foreach (var analyzator in _analyzators)
            {
                var result = analyzator.Analyze();
                warnings.AddRange(result);
            }

            return warnings;
        }
    }
}
