using System;
using LibraryManagementSystem.Interfaces;

namespace LibraryManagementSystem
{
	public class LibraryService
	{
		public void BorrowBook(IBorrower borrower, string bookTitle)
		{
			borrower.BorrowBook(bookTitle);
		}

		public void ReserveBook(IReserver reserver, string bookTitle)
		{
			reserver.ReserveBook(bookTitle);
		}

		public void AddBookToInventory(IInventoryManager manager, string bookTitle)
		{
			manager.AddBook(bookTitle);
		}

		public void RemoveBookFromInventory(IInventoryManager manager, string bookTitle)
		{
			manager.RemoveBook(bookTitle);
		}
	}
}
