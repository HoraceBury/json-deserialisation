import json
from datetime import datetime

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

# Deserialize JSON with a hook
def date_hook(obj):
    if "birthday" in obj:
        obj["birthday"] = datetime.fromisoformat(
            obj["birthday"]
        )
    return obj

json_content = '{"birthday": "2026-06-27"}'

# Deserialize with hook
deserialized_json = json.loads(json_content, object_hook=date_hook)

print(deserialized_json["birthday"].strftime("%Y-%m-%d"))

# Serialize to JSON with a serializer hook
def serializer(obj):
    if isinstance(obj, datetime):
        return obj.strftime("%d/%m/%Y")  # custom format
    raise TypeError("Type not serializable")

data = {"birthday": datetime.now()}

# Serializing with a dedicated class
serialized_json = json.dumps(data, default=serializer)
print(serialized_json)

class DateEncoder(json.JSONEncoder):
    def default(self, obj):
        if isinstance(obj, datetime):
            return obj.strftime("%Y-%m-%d")
        return super().default(obj)

serialized_json = json.dumps({"birthday": datetime.now()}, cls=DateEncoder)

print(serialized_json)
