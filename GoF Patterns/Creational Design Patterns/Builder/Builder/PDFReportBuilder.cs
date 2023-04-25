namespace Builder
{
    internal class PDFReportBuilder : IReportBuilder
    {
        private readonly Report _report;

        public PDFReportBuilder() => _report = new Report();

        public Report GetReport() => _report;

        public void SetContent() => _report.Content = "PDF Content Section";

        public void SetFooter() => _report.Footer = "PDF Footer";

        public void SetHeader() => _report.Header = "PDF Header";

        public void SetType() => _report.Type = "PDF";
    }
}
