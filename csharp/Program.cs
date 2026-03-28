using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonTest
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public bool IsSubscribed { get; set; }
        public List<string> Roles { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var user = new User
            {
                Name = "John Doe",
                Age = 30,
                Email = "john.doe@example.com",
                IsSubscribed = true,
                Roles = new List<string> { "Admin", "User" }
            };

            // Serialization
            string jsonString = JsonConvert.SerializeObject(user, Formatting.Indented);
            Console.WriteLine("Serialized JSON:");
            Console.WriteLine(jsonString);

            // Deserialization
            var parsedUser = JsonConvert.DeserializeObject<User>(jsonString);
            Console.WriteLine("\nDeserialized Object:");
            Console.WriteLine($"Name: {parsedUser.Name}, Age: {parsedUser.Age}");
        }
    }
}
