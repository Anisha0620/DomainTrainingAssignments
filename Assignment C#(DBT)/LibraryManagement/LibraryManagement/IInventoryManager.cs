using System;

namespace LibraryManagementSystem.Interfaces
{
	public interface IInventoryManager
	{
		void AddBook(string bookTitle);
		void RemoveBook(string bookTitle);
	}
}


