namespace Builder
{
    internal class Report
    {
        public string Type { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string Footer { get; set; }

        public void DisplayReport()
        {
            Console.WriteLine($"Type : {Type}");
            Console.WriteLine($"Header : {Header}");
            Console.WriteLine($"Content : {Content}");
            Console.WriteLine($"Footer : {Footer}");
        }
    }
}
