import re
import json

def parse_file(file_path):
    """Parse the data from the given file and return as a dictionary."""
    with open(file_path, 'r') as file:
        content = file.read()
    
    # Extract company name (centered at the top)
    company_match = re.search(r'={80,}\s+([^\n]+?)\s+={80,}', content)
    company_name = company_match.group(1).strip() if company_match else 'Unknown'
    
    # Extract customer name
    customer_match = re.search(r'CUSTOMER:\s*([^\s]+)', content)
    customer_name = customer_match.group(1).strip() if customer_match else 'Unknown'
    
    # Extract control number
    control_match = re.search(r'CONTROL NUMBER:\s*([^\s\n]+)', content)
    control_number = control_match.group(1).strip() if control_match else 'Unknown'
    
    # Extract quantity
    quantity_match = re.search(r'QUANTITY\s*:\s*(\d+)', content)
    quantity = int(quantity_match.group(1)) if quantity_match else 0
    
    # Extract address
    address_match = re.search(r'ADDRESS\s*:\s*([^\n]+)', content)
    address = address_match.group(1).strip() if address_match else 'Unknown'
    
    # Create a dictionary with the extracted data
    data = {
        'company_name': company_name,
        'customer': {
            'name': customer_name,
            'control_number': control_number,
            'quantity': quantity,
            'address': address
        }
    }
    
    return data

def save_to_json(data, output_file):
    """Save the data to a JSON file."""
    with open(output_file, 'w') as file:
        json.dump(data, file, indent=4)
    print(f"Data successfully saved to {output_file}")
    print("JSON content:")
    print(json.dumps(data, indent=4))

def main():
    input_file = 'parse.txt'
    output_file = 'parsed_data.json'
    
    try:
        data = parse_file(input_file)
        save_to_json(data, output_file)
    except Exception as e:
        print(f"Error: {e}")

if __name__ == '__main__':
    main()