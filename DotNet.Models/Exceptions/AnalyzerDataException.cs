using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Models.Exceptions
{
    public class AnalyzerDataException : ApplicationException
    {
        public AnalyzerDataException(string message)
            : base(message)
        {
        }
    }
}
