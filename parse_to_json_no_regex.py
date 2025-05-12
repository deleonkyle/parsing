import json

def extract_data_from_file(file_path):
    # Initialize data dictionary
    data = {
        "company_name": "",
        "customer": "",
        "control_number": "",
        "quantity": "",
        "address": ""
    }
    
    # Read the file line by line
    with open(file_path, 'r') as file:
        lines = file.readlines()
    
    # Extract company name from line 1 (centered text)
    if len(lines) > 1:
        company_line = lines[1].strip()
        data["company_name"] = company_line.strip()
    
    # Extract customer, control number, quantity and address from lines 4-5
    if len(lines) > 4:
        # Extract customer from line 4
        customer_line = lines[4].strip()
        if "CUSTOMER:" in customer_line:
            customer_part = customer_line.split("CUSTOMER:")[1].split("CONTROL NUMBER:")[0]
            data["customer"] = customer_part.strip()
        
        # Extract control number from line 4
        if "CONTROL NUMBER:" in customer_line:
            control_part = customer_line.split("CONTROL NUMBER:")[1]
            data["control_number"] = control_part.strip()
    
    if len(lines) > 5:
        # Extract quantity from line 5
        quantity_line = lines[5].strip()
        if "QUANTITY :" in quantity_line:
            quantity_part = quantity_line.split("QUANTITY :")[1].split("ADDRESS :")[0]
            data["quantity"] = quantity_part.strip()
        
        # Extract address from line 5
        if "ADDRESS :" in quantity_line:
            address_part = quantity_line.split("ADDRESS :")[1]
            data["address"] = address_part.strip()
    
    return data

def main():
    # File paths
    input_file = "parse.txt"
    output_file = "parsed_data.json"
    
    # Extract data
    extracted_data = extract_data_from_file(input_file)
    
    # Save to JSON file
    with open(output_file, 'w') as json_file:
        json.dump(extracted_data, json_file, indent=4)
    
    # Print the JSON data
    print("Extracted data:")
    print(json.dumps(extracted_data, indent=4))
    print(f"\nData has been saved to {output_file}")

if __name__ == "__main__":
    main()