import json

data = {
    "name": "John Doe",
    "age": 30,
    "email": "john.doe@example.com",
    "isSubscribed": True,
    "roles": ["Admin", "User"]
}

# Serialization
json_string = json.dumps(data, indent=4)
print("Serialized JSON:")
print(json_string)

# Deserialization
parsed_data = json.loads(json_string)
print("\nDeserialized Dictionary:")
print(parsed_data)
print(f"\nName: {parsed_data['name']}, Age: {parsed_data['age']}")
