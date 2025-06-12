using System;
using System.IO;
using System.Linq;
using CSharpParser.Models;

namespace CSharpParser.Services
{
    /// <summary>
    /// Service class for parsing text files into structured data
    /// </summary>
    public class FileParser
    {
        /// <summary>
        /// Extracts data from the specified file and returns a ParsedData object
        /// </summary>
        /// <param name="filePath">Path to the file to be parsed</param>
        /// <returns>A ParsedData object containing the extracted information</returns>
        public ParsedData ExtractDataFromFile(string filePath)
        {
            // Initialize data object
            var data = new ParsedData();
            
            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);
                
                // Extract company name from line 1 (centered text)
                if (lines.Length > 1)
                {
                    data.CompanyName = lines[1].Trim();
                }
                
                // Extract customer, control number, quantity and address from lines 4-5
                if (lines.Length > 4)
                {
                    // Extract customer from line 4
                    string customerLine = lines[4].Trim();
                    if (customerLine.Contains("CUSTOMER:"))
                    {
                        string[] customerParts = customerLine.Split(new[] { "CUSTOMER:" }, StringSplitOptions.None);
                        if (customerParts.Length > 1)
                        {
                            string customerPart = customerParts[1];
                            if (customerPart.Contains("CONTROL NUMBER:"))
                            {
                                data.Customer = customerPart.Split(new[] { "CONTROL NUMBER:" }, StringSplitOptions.None)[0].Trim();
                            }
                            else
                            {
                                data.Customer = customerPart.Trim();
                            }
                        }
                    }
                    
                    // Extract control number from line 4
                    if (customerLine.Contains("CONTROL NUMBER:"))
                    {
                        string[] controlParts = customerLine.Split(new[] { "CONTROL NUMBER:" }, StringSplitOptions.None);
                        if (controlParts.Length > 1)
                        {
                            data.ControlNumber = controlParts[1].Trim();
                        }
                    }
                }
                
                if (lines.Length > 5)
                {
                    // Extract quantity from line 5
                    string quantityLine = lines[5].Trim();
                    if (quantityLine.Contains("QUANTITY :"))
                    {
                        string[] quantityParts = quantityLine.Split(new[] { "QUANTITY :" }, StringSplitOptions.None);
                        if (quantityParts.Length > 1)
                        {
                            string quantityPart = quantityParts[1];
                            if (quantityPart.Contains("ADDRESS :"))
                            {
                                data.Quantity = quantityPart.Split(new[] { "ADDRESS :" }, StringSplitOptions.None)[0].Trim();
                            }
                            else
                            {
                                data.Quantity = quantityPart.Trim();
                            }
                        }
                    }
                    
                    // Extract address from line 5
                    if (quantityLine.Contains("ADDRESS :"))
                    {
                        string[] addressParts = quantityLine.Split(new[] { "ADDRESS :" }, StringSplitOptions.None);
                        if (addressParts.Length > 1)
                        {
                            data.Address = addressParts[1].Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing file: {ex.Message}");
                // In a production environment, you might want to log this error or handle it differently
            }
            
            return data;
        }
    }
}