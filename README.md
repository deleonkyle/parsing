# Parse Text to JSON

This project contains a Python script that parses structured text data from a file and converts it into JSON format.

## How It Works

The `parse_to_json.py` script reads data from `parse.txt` and extracts the following information:

- Company Name: Extracted from the centered text at the top
- Customer Name: Extracted from the "CUSTOMER:" field
- Control Number: Extracted from the "CONTROL NUMBER:" field
- Quantity: Extracted from the "QUANTITY:" field
- Address: Extracted from the "ADDRESS:" field

The script uses regular expressions to identify and extract these data points from the formatted text file.

## How to Use

1. Make sure you have Python installed on your system
2. Place your data file as `parse.txt` in the same directory as the script
3. Run the script:

```
python parse_to_json.py
```

4. The script will generate a file called `parsed_data.json` with the extracted data
5. The JSON content will also be printed to the console

## Customization

You can modify the script to:

- Parse additional fields by adding new regular expressions
- Change the input or output file names in the `main()` function
- Adjust the JSON structure by modifying the `data` dictionary

## Example

Input file format:
```
========================================================================================================
                                                                                  COMPANY NAME
========================================================================================================

CUSTOMER: LEKAYA                                                                			CONTROL NUMBER: TP3224
QUANTITY : 3894                                                                                   	ADDRESS : 123 St. 
========================================================================================================
```

Output JSON:
```json
{
    "company_name": "COMPANY NAME",
    "customer": {
        "name": "LEKAYA",
        "control_number": "TP3224",
        "quantity": 3894,
        "address": "123 St."
    }
}
```