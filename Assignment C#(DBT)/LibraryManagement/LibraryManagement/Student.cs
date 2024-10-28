using System;
using System.Collections.Generic;
using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem.Users
{
	public class Student : IUser, IBorrower
	{
		public string UserId { get; private set; }
		public string Name { get; private set; }

		public Student(string userId, string name)
		{
			UserId = userId;
			Name = name;
		}

		public void BorrowBook(string bookTitle)
		{
			Console.WriteLine($"{Name} (Student) borrowed the book '{bookTitle}'.");
		}
	}
}
