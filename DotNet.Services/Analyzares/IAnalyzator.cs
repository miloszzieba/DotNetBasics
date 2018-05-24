using DotNet.Models;
using DotNet.Models.Warning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.Services.Analyzares
{
    public interface IAnalyzator
    {
        List<BookWarning> Analyze();
    }
}
