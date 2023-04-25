using Builder;

var pdfBuilder = new PDFReportBuilder();
var excelBuilder = new ExcelReportBuilder();

var director = new ReportBuildDirector(pdfBuilder);
var pdfReport = director.BuildReport();

director = new ReportBuildDirector(excelBuilder);
var excelReport = director.BuildReport();


Console.WriteLine("/***************************** Report 1 ***********************************/");
pdfReport.DisplayReport();

Console.WriteLine();

Console.WriteLine("/***************************** Report 2 ***********************************/");
excelReport.DisplayReport();

Console.WriteLine();

Console.WriteLine("/***************************** Report 3 ***********************************/");
var excelFluentBuilder = new Builder.Fluent_Implementation.ExcelReportBuilder();
excelReport = excelFluentBuilder.SetType()
                                .SetHeader()
                                .SetContent()
                                .SetFooter()
                                .GetReport();

excelReport.DisplayReport();