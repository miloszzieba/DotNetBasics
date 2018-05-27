using DotNet.Models.Exceptions;
using DotNet.Models.Warning;
using DotNet.Services.Analyzares;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services
{
    public class BookWarningManager
    {
        private readonly string _logPath;
        private List<IAnalyzator> _analyzators;

        public BookWarningManager(List<IAnalyzator> analyzators, string logPath)
        {
            this._logPath = logPath;
            this._analyzators = analyzators;
        }

        public List<BookWarning> Warn()
        {
            var warnings = new List<BookWarning>();

            foreach (var analyzator in _analyzators)
            {
                try
                {
                    var result = analyzator.Analyze();
                    warnings.AddRange(result);
                }
                catch (AnalyzerDataException exception)
                {
                    var text = String.Format("{0}{1} - Message: {2}, StackTrace: {3}", Environment.NewLine, DateTime.Now, exception.Message, exception.StackTrace);
                    File.AppendAllText(_logPath, text);
                }
            }

            return warnings;
        }
    }
}
