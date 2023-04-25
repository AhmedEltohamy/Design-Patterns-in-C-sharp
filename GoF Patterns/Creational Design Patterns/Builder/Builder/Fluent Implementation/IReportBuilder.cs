using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.Fluent_Implementation
{
    internal interface IReportBuilder
    {
        IReportBuilder SetType();
        IReportBuilder SetHeader();
        IReportBuilder SetContent();
        IReportBuilder SetFooter();
        Report GetReport();
    }
}
