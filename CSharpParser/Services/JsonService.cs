using System;
using System.IO;
using System.Text.Json;
using CSharpParser.Models;

namespace CSharpParser.Services
{
    /// <summary>
    /// Service class for JSON operations
    /// </summary>
    public class JsonService
    {
        private readonly JsonSerializerOptions _options;

        public JsonService()
        {
            // Configure JSON serialization options
            _options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
        }

        /// <summary>
        /// Serializes the parsed data to a JSON string
        /// </summary>
        /// <param name="data">The data to serialize</param>
        /// <returns>A JSON string representation of the data</returns>
        public string SerializeToJson(ParsedData data)
        {
            return JsonSerializer.Serialize(data, _options);
        }

        /// <summary>
        /// Saves the parsed data to a JSON file
        /// </summary>
        /// <param name="data">The data to save</param>
        /// <param name="filePath">The path where the JSON file will be saved</param>
        public void SaveToJsonFile(ParsedData data, string filePath)
        {
            try
            {
                string jsonString = SerializeToJson(data);
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving JSON file: {ex.Message}");
                // In a production environment, you might want to log this error or handle it differently
            }
        }

        /// <summary>
        /// Deserializes a JSON string to a ParsedData object
        /// </summary>
        /// <param name="jsonString">The JSON string to deserialize</param>
        /// <returns>A ParsedData object</returns>
        public ParsedData DeserializeFromJson(string jsonString)
        {
            return JsonSerializer.Deserialize<ParsedData>(jsonString, _options) ?? new ParsedData();
        }

        /// <summary>
        /// Loads a ParsedData object from a JSON file
        /// </summary>
        /// <param name="filePath">The path to the JSON file</param>
        /// <returns>A ParsedData object</returns>
        public ParsedData LoadFromJsonFile(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                return DeserializeFromJson(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON file: {ex.Message}");
                // In a production environment, you might want to log this error or handle it differently
                return new ParsedData();
            }
        }
    }
}