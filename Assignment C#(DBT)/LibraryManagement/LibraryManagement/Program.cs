using System;
using LibraryManagementSystem.Users;

namespace LibraryManagementSystem
{
	class Program
	{
		static void Main()
		{
			LibraryService libraryService = new LibraryService();

			Student student = new Student("01", "Anisha");
			Teacher teacher = new Teacher("02", "Sumathi");
			Librarian librarian = new Librarian("03", "Godlina");

			// Student can only borrow books
			libraryService.BorrowBook(student, "Fairy Tales");

			// Teacher can borrow and reserve books
			libraryService.BorrowBook(teacher, "Fairy Tales");
			libraryService.ReserveBook(teacher, "Harry Potter");

			// Librarian can manage inventory
			libraryService.AddBookToInventory(librarian, "Repunzil");
			libraryService.RemoveBookFromInventory(librarian, "Magic Wonderland");

			Console.ReadLine();
		}
	}
}
