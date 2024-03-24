// See https://aka.ms/new-console-template for more information
using FileAdapters.Infrastucture.Models;
using FileAdapters.Infrastucture.Services;
using FileAdapters.Infrastucture.Services.Base;
using FileAdapters.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Configuration;


//Dependany Injection
var serviceProvider = new ServiceCollection()
                  .AddLogging(cl => cl.AddSimpleConsole())
                  .AddSingleton<INameSorterService, NameSorterService>()
                  .AddSingleton<IFileParser<Person>, NameFileParser>()
                  .AddSingleton<INameFileService<Person>, NameFileService>()
                  .AddSingleton<INameService, NameService>()
                  .BuildServiceProvider();

var sorterName = serviceProvider.GetService<INameSorterService>();


//Assuming source file is in directory SortProccess in assembly or from comment prompt arguments.
string path = Path.Combine(Directory.GetCurrentDirectory(), "SortProccess");

var resourceName = !args.Any() ? $"FileAdapters.SortProccess.{ConfigurationManager.AppSettings["SourceFileName"]}" : Path.Combine(path, args[0]);


// Sorted file will export to SortProccess folder in working directory.
var destination = Path.Combine(path, ConfigurationManager.AppSettings["DestinationFileName"]);


Console.WriteLine("------Name Sorter-----" + Environment.NewLine);

Console.WriteLine($"Source : {resourceName}");
try
{
    await sorterName.GenerateSortedFileAsync(resourceName, destination);
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"{ex.FileName} is not found.");
}
catch (ArgumentNullException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception)
{
    Console.WriteLine("Oops! Something went wrong.");
}

Console.WriteLine();
Console.WriteLine($"Please check {destination}");