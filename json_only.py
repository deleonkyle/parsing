import json

def create_sample_data():
    """Create a sample data structure to demonstrate JSON serialization."""
    data = {
        'company_name': 'Example Company',
        'customer': {
            'name': 'John Doe',
            'control_number': 'CTL123456',
            'quantity': 100,
            'address': '123 Main Street, Anytown, USA'
        },
        'products': [
            {
                'id': 'P001',
                'name': 'Widget A',
                'price': 19.99
            },
            {
                'id': 'P002',
                'name': 'Widget B',
                'price': 29.99
            }
        ],
        'is_active': True,
        'notes': None
    }
    return data

def save_to_json(data, output_file):
    """Save the data to a JSON file with pretty formatting."""
    with open(output_file, 'w') as file:
        json.dump(data, file, indent=4)
    print(f"Data successfully saved to {output_file}")

def print_json(data):
    """Print the data as a formatted JSON string."""
    json_string = json.dumps(data, indent=4)
    print("JSON content:")
    print(json_string)

def load_from_json(input_file):
    """Load data from a JSON file."""
    try:
        with open(input_file, 'r') as file:
            data = json.load(file)
        return data
    except FileNotFoundError:
        print(f"Error: File '{input_file}' not found.")
        return None
    except json.JSONDecodeError:
        print(f"Error: File '{input_file}' contains invalid JSON.")
        return None

def main():
    # Create sample data
    data = create_sample_data()
    
    # Save data to JSON file
    output_file = 'sample_data.json'
    save_to_json(data, output_file)
    
    # Print the JSON content
    print_json(data)
    
    # Demonstrate loading from JSON file
    print("\nLoading data from JSON file...")
    loaded_data = load_from_json(output_file)
    if loaded_data:
        print("Successfully loaded data from JSON file.")

if __name__ == '__main__':
    main()