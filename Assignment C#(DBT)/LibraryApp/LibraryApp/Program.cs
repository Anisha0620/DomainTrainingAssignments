using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
	public static void Main()
	{
		List<Author> authors = new List<Author>
		{
			new Author { Id = 1, Name = "Anisha" },
			new Author { Id = 2, Name = "Godlina" }
		};

		List<Book> books = new List<Book>
		{
			new Book { Id = 1, Title = "New Year Resolution" },
			new Book { Id = 2, Title = "First Trip to Chennai" }
		};

		var libraryData = new LibraryData { Authors = authors, Books = books };

		var jsonSerializer = new CustomJsonSerializer();
		var xmlSerializer = new CustomXmlSerializer();

		var jsonData = jsonSerializer.Serialize(libraryData);
		File.WriteAllText("library.json", jsonData);
		Console.WriteLine("Custom JSON Data:");
		Console.WriteLine(jsonData);

		var xmlData = xmlSerializer.Serialize(libraryData);
		File.WriteAllText("library.xml", xmlData);
		Console.WriteLine("\nCustom XML Data:");
		Console.WriteLine(xmlData);
	}
}

