using System;
using System.Collections.Generic;
using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem.Users
{
	public class Librarian : IUser, IInventoryManager
	{
		public string UserId { get; private set; }
		public string Name { get; private set; }

		public Librarian(string userId, string name)
		{
			UserId = userId;
			Name = name;
		}

		public void AddBook(string bookTitle)
		{
			Console.WriteLine($"{Name} (Librarian) added the book '{bookTitle}' to the inventory.");
		}

		public void RemoveBook(string bookTitle)
		{
			Console.WriteLine($"{Name} (Librarian) removed the book '{bookTitle}' from the inventory.");
		}
	}
}
