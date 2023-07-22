using Composite.Entities;

var root = new DirectoryItem("Root");
var fileInsideRoot = new FileItem("File Inside Root", 8);
root.AddItem(fileInsideRoot);

var folder1 = new DirectoryItem("Folder 1");
var fileInsideFolder1 = new FileItem("File Inside Folder 1", 5);
folder1.AddItem(fileInsideFolder1);
root.AddItem(folder1);

var folder2 = new DirectoryItem("Folder 2");
var fileInsideFolder2 = new FileItem("File Inside Folder 2", 3);
folder2.AddItem(fileInsideFolder2);
root.AddItem(folder2);


var folder3 = new DirectoryItem("Folder 3");
var fileInsideFolder3 = new FileItem("File Inside Folder 3", 10);
folder3.AddItem(fileInsideFolder3);
folder2.AddItem(folder3);

Console.WriteLine($"{root.Name} Size in MB: {root.GetSizeInMB()}");
Console.WriteLine($"{fileInsideRoot.Name} Size in MB: {fileInsideRoot.GetSizeInMB()}");
Console.WriteLine($"{folder1.Name} Size in MB: {folder1.GetSizeInMB()}");
Console.WriteLine($"{folder2.Name} Size in MB: {folder2.GetSizeInMB()}");
Console.WriteLine($"{folder3.Name} Size in MB: {folder3.GetSizeInMB()}");

Console.ReadKey();