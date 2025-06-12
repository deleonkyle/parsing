# C# File Parser

This is a C# implementation of a parser that extracts structured data from a specific text file format and saves it as JSON.

## Project Structure

The project follows a clean separation of concerns with the following components:

### Models

- `ParsedData.cs` - Defines the data model that represents the extracted information.

### Services

- `FileParser.cs` - Contains the logic for parsing the text file and extracting structured data.
- `JsonService.cs` - Handles JSON serialization, deserialization, and file operations.

### Program

- `Program.cs` - The entry point of the application that coordinates the parsing and saving process.

## How to Use

1. Place your input file named `parse.txt` in the same directory as the executable.
2. Run the application.
3. The parsed data will be saved to `parsed_data.json` in the same directory.

## Building and Running

```bash
# Navigate to the project directory
cd CSharpParser

# Build the project
dotnet build

# Run the application
dotnet run
```

## Requirements

- .NET 6.0 SDK or later

## Input File Format

The application expects an input file with the following format:

```
========================================================================================================
                                                                                  COMPANY NAME
========================================================================================================

CUSTOMER: CUSTOMER_NAME                                                                CONTROL NUMBER: CONTROL_NUMBER
QUANTITY : QUANTITY_VALUE                                                              ADDRESS : ADDRESS_VALUE
========================================================================================================
```

The parser extracts the following information:
- Company Name (from line 2)
- Customer Name (from line 5)
- Control Number (from line 5)
- Quantity (from line 6)
- Address (from line 6)