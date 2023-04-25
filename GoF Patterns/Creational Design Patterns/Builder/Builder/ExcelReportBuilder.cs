namespace Builder
{
    internal class ExcelReportBuilder : IReportBuilder
    {
        private readonly Report _report;

        public ExcelReportBuilder() => _report = new Report();

        public Report GetReport() => _report;

        public void SetContent() => _report.Content = "Excel Content Section";

        public void SetFooter() => _report.Footer = "Excel Footer";

        public void SetHeader() => _report.Header = "Excel Header";

        public void SetType() => _report.Type = "Excel";
    }
}
