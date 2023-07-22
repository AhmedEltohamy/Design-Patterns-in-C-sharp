using Bridge.Entities;

var now = DateTime.Now;

var license1 = new TwoDaysMovieLicense("pursuit of happiness", now, new NoDiscount());
var license2 = new LifeLongMovieLicense("pursuit of happiness", now, new NoDiscount());
Console.WriteLine(license1);
Console.WriteLine(license2);

var license3 = new TwoDaysMovieLicense("pursuit of happiness", now, new MilitaryDiscount());
var license4 = new LifeLongMovieLicense("pursuit of happiness", now, new MilitaryDiscount());
Console.WriteLine(license3);
Console.WriteLine(license4);

var license5 = new TwoDaysMovieLicense("pursuit of happiness", now, new SeniorDiscount());
var license6 = new LifeLongMovieLicense("pursuit of happiness", now, new SeniorDiscount());
Console.WriteLine(license5);
Console.WriteLine(license6);

Console.ReadKey();