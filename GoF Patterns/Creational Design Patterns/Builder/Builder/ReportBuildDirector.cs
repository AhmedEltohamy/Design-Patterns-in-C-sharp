namespace Builder
{
    internal class ReportBuildDirector
    {
        private readonly IReportBuilder _reportBuilder;

        public ReportBuildDirector(IReportBuilder reportBuilder)
        {
            if (reportBuilder is null)
                throw new ArgumentNullException(nameof(reportBuilder));
            _reportBuilder = reportBuilder;
        }

        public Report BuildReport()
        {
            _reportBuilder.SetType();
            _reportBuilder.SetHeader();
            _reportBuilder.SetContent();
            _reportBuilder.SetFooter();
            return _reportBuilder.GetReport();
        }
    }
}
