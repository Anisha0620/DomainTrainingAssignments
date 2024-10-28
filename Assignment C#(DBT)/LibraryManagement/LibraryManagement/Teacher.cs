using System;
using System.Collections.Generic;
using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem.Users
{
	public class Teacher : IUser, IBorrower, IReserver
	{
		public string UserId { get; private set; }
		public string Name { get; private set; }

		public Teacher(string userId, string name)
		{
			UserId = userId;
			Name = name;
		}

		public void BorrowBook(string bookTitle)
		{
			Console.WriteLine($"{Name} (Teacher) borrowed the book '{bookTitle}'.");
		}

		public void ReserveBook(string bookTitle)
		{
			Console.WriteLine($"{Name} (Teacher) reserved the book '{bookTitle}'.");
		}
	}
}
