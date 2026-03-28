// Serialized JSON string from the above example
const serializedJSON = "{\"total\":4,\"skip\":0,\"limit\":100,\"items\":[{\"fields\":{\"productName\":\"Whisk Beater\",\"price\":22}},{\"fields\":{\"productName\":\"SoSo Wall Clock\",\"price\":120}},{\"fields\":{\"productName\":\"Hudson Wall Cup\",\"price\":11}}]}";

// Deserialize JSON into a JavaScript object
const deserializedJSON = JSON.parse(serializedJSON);

// Use the deserialized JSON data
console.log('Total number of products: '+ deserializedJSON.total);
console.log('Number of product items: '+ deserializedJSON.items.length);
console.log('First product name: '+ deserializedJSON.items[0].fields.productName);

// Handling dates
const json = "{\"birthday\": \"2017-06-27\"}";

const data = JSON.parse(json, (key, value) => {
  if (key === 'birthday' && typeof value === 'string') {
    return new Date(value);
  }
  return value;
});

// Simple helper to format dates using strings like "yyyy-MM-dd"
const formatDate = (date, format) => {
    const map = {
        'yyyy': date.getFullYear(),
        'MM': String(date.getMonth() + 1).padStart(2, '0'),
        'dd': String(date.getDate()).padStart(2, '0')
    };
    return format.replace(/yyyy|MM|dd/g, matched => map[matched]);
};

console.log(formatDate(data.birthday, 'yyyy-MM-dd'));

// Using a replacer to format date
const obj = { birthday: new Date() };

const jsonOutput = JSON.stringify(obj, (key, value) => {
  if (key === 'birthday') {
    return obj.birthday.toLocaleDateString('en-GB');
  }
  return value;
});

console.log(jsonOutput);

// Error handling and validation with a reviver
const serializedJSON2 = "{\"birthday\": \"2017-06-27\"}";

const deserializedJSON2 = JSON.parse(serializedJSON2, (key, value) => {
  if (key === 'birthday' && typeof value === 'string') {
    const date = new Date(value);

    if (isNaN(date.getTime())) {
      throw new Error('Invalid birthday: not a valid date');
    }

    return date;
  }
  return value;
});

console.log(deserializedJSON2.birthday.toISOString());
