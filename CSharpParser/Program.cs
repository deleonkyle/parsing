using System;
using CSharpParser.Models;
using CSharpParser.Services;

namespace CSharpParser
{
    class Program
    {
        static void Main(string[] args)
        {
            // File paths
            string inputFile = "parse.txt";
            string outputFile = "parsed_data.json";
            
            // Create service instances
            FileParser fileParser = new FileParser();
            JsonService jsonService = new JsonService();
            
            try
            {
                // Extract data from the input file
                Console.WriteLine($"Parsing file: {inputFile}");
                ParsedData extractedData = fileParser.ExtractDataFromFile(inputFile);
                
                // Save the data to a JSON file
                jsonService.SaveToJsonFile(extractedData, outputFile);
                
                // Print the JSON data
                Console.WriteLine("\nExtracted data:");
                Console.WriteLine(jsonService.SerializeToJson(extractedData));
                Console.WriteLine($"\nData has been saved to {outputFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}