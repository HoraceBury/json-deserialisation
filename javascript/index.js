// Serialized JSON string from the above example
const serializedJSON = "{\"total\":4,\"skip\":0,\"limit\":100,\"items\":[{\"fields\":{\"productName\":\"Whisk Beater\",\"price\":22}},{\"fields\":{\"productName\":\"SoSo Wall Clock\",\"price\":120}},{\"fields\":{\"productName\":\"Hudson Wall Cup\",\"price\":11}}]}";

// Deserialize JSON into a JavaScript object
const deserializedJSON = JSON.parse(serializedJSON);

// Use the deserialized JSON data
console.log('Total number of products: '+ deserializedJSON.total);
console.log('Number of product items: '+ deserializedJSON.items.length);
console.log('First product name: '+ deserializedJSON.items[0].fields.productName);
