using System;
using System;
using System.Text.RegularExpressions;

public class Validator
{
	public bool IsValidEmail(string email)
	{
		if (string.IsNullOrEmpty(email))
			return false;

		var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
		return Regex.IsMatch(email, emailPattern);
	}

	public bool IsValidPhoneNumber(string phoneNumber)
	{
		if (string.IsNullOrEmpty(phoneNumber))
			return false;

		var phonePattern = @"^\+?[1-9]\d{1,14}$";
		return Regex.IsMatch(phoneNumber, phonePattern);
	}

	public bool IsValidDateOfBirth(DateTime dateOfBirth)
	{
		return dateOfBirth < DateTime.Now.AddYears(-18); 
	}
}

