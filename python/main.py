import json

# Serialized JSON string from the above example
json_content = "{\"total\":4,\"skip\":0,\"limit\":100,\"items\":[{\"fields\":{\"productName\":\"Whisk Beater\",\"price\":22}},{\"fields\":{\"productName\":\"SoSo Wall Clock\",\"price\":120}},{\"fields\":{\"productName\":\"Hudson Wall Cup\",\"price\":11}}]}"

# deserialize JSON into a Python object (dict)
product_data = json.loads(json_content)

# Use the deserialized JSON
print("Total number of products: " + str(product_data["total"]))
print("Number of product items: " + str(len(product_data["items"])))
print("First product name: " + product_data["items"][0]["fields"]["productName"])

# product information held as a Python object
json_string = json.dumps(product_data)

# dump the json to the console
print(json_string)
