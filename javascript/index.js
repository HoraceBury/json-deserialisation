const data = {
    name: "John Doe",
    age: 30,
    email: "john.doe@example.com",
    isSubscribed: true,
    roles: ["Admin", "User"]
};

// Serialization
const jsonString = JSON.stringify(data, null, 2);
console.log("Serialized JSON:");
console.log(jsonString);

// Deserialization
const parsedData = JSON.parse(jsonString);
console.log("\nDeserialized Object:");
console.log(parsedData);
console.log(`\nName: ${parsedData.name}, Age: ${parsedData.age}`);
