namespace Builder.Fluent_Implementation
{
    internal class ExcelReportBuilder : IReportBuilder
    {
        private readonly Report _report;

        public ExcelReportBuilder() => _report = new Report();

        public Report GetReport() => _report;

        public IReportBuilder SetContent()
        {
            _report.Content = "Excel Content Section";
            return this;
        }

        public IReportBuilder SetFooter()
        {
            _report.Footer = "Excel Footer";
            return this;
        }

        public IReportBuilder SetHeader()
        {
            _report.Header = "Excel Header";
            return this;
        }

        public IReportBuilder SetType()
        {
            _report.Type = "Excel";
            return this;
        }
    }
}
