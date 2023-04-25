namespace Builder
{
    internal interface IReportBuilder
    {
        void SetType();
        void SetHeader();
        void SetContent();
        void SetFooter();
        Report GetReport();
    }
}
