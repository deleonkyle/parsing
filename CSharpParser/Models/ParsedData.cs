namespace CSharpParser.Models
{
    /// <summary>
    /// Model class representing the parsed data from the input file
    /// </summary>
    public class ParsedData
    {
        /// <summary>
        /// The company name extracted from the file
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// The customer name extracted from the file
        /// </summary>
        public string Customer { get; set; } = string.Empty;

        /// <summary>
        /// The control number extracted from the file
        /// </summary>
        public string ControlNumber { get; set; } = string.Empty;

        /// <summary>
        /// The quantity value extracted from the file
        /// </summary>
        public string Quantity { get; set; } = string.Empty;

        /// <summary>
        /// The address extracted from the file
        /// </summary>
        public string Address { get; set; } = string.Empty;
    }
}