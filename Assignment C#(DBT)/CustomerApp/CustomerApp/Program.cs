using System;

public class Program
{
	public static void Main(string[] args)
	{
		var customer = new Customer
		{
			Name = "Anisha",
			Email = "anishakabeer@gmail.com",
			PhoneNumber = "9234567890",
			DateOfBirth = new DateTime(2002, 6, 20) 
		};
		var validator = new Validator();

		bool isEmailValid = validator.IsValidEmail(customer.Email);
		Console.WriteLine($"Email Valid: {isEmailValid}");

		bool isPhoneValid = validator.IsValidPhoneNumber(customer.PhoneNumber);
		Console.WriteLine($"Phone Number Valid: {isPhoneValid}");

		bool isDobValid = validator.IsValidDateOfBirth(customer.DateOfBirth);
		Console.WriteLine($"Date of Birth Valid: {isDobValid}");
	}
}
