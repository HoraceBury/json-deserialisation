using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// The Root class is the type to be passed as the Generic parameter, informing the deserializer which class type to use when producing the output object
public class Root
{
    [JsonProperty("total")]
    public int Total { get; set; }

    [JsonProperty("skip")]
    public int Skip { get; set; }

    [JsonProperty("limit")]
    public int Limit { get; set; }

    [JsonProperty("items")]
    public List<Item> Items { get; set; }
}

public class Sys
{
    [JsonProperty("type")]
    public string Type { get; set; }
}

public class Item
{
    [JsonProperty("fields")]
    public Fields Fields { get; set; }
}

public class Fields
{
    [JsonProperty("productName")]
    public string ProductName { get; set; }

    [JsonProperty("price")]
    public int Price { get; set; }
}

// Attribute class to convert dates
public class DateConverter : JsonConverter<DateTime>
{
    public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var value = reader.Value?.ToString();

        if (!string.IsNullOrEmpty(value))
        {
            return DateTime.Parse(value, null, System.Globalization.DateTimeStyles.RoundtripKind);
        }

        return default;
    }

    public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString("yyyy-MM-dd"));
    }
}

// Using the attribute class to convert a date property
public class Model
{
    [JsonConverter(typeof(DateConverter))]
    [JsonProperty(Required = Required.Always)]
    public DateTime Birthday { get; set; }
}

public class Program
{
	public static void Main()
	{
		// Serialized JSON stringfrom the above example
		var serializedJSON = "{\"total\":4,\"skip\":0,\"limit\":100,\"items\":[{\"fields\":{\"productName\":\"Whisk Beater\",\"price\":22}},{\"fields\":{\"productName\":\"SoSo Wall Clock\",\"price\":120}},{\"fields\":{\"productName\":\"Hudson Wall Cup\",\"price\":11}}]}";

		// Deserialize JSON into a C# object
		var deserializedJSON = JsonConvert.DeserializeObject<Root>(serializedJSON);

		// Use the deserialized JSON
		Console.WriteLine($"Total number of products: {deserializedJSON.Total}");
		Console.WriteLine($"Number of product items: {deserializedJSON.Items.Count}");
		Console.WriteLine($"First product name: {deserializedJSON.Items[0].Fields.ProductName}");

		// Serialize the deserialized object back into a JSON string
		string reSerializedJSON = JsonConvert.SerializeObject(deserializedJSON);

		// Output the re-serialized JSON string
		Console.WriteLine("\nRe-serialized JSON:");
		Console.WriteLine(reSerializedJSON);
	}
}
