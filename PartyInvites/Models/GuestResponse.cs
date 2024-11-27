using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
	public class GuestResponse
	{
		[Required(ErrorMessage = "Please enter your name")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Please enter your email address")]
		[RegularExpression(".+\\@.+\\..+",
			ErrorMessage = "Please enter a valid email address")]
		// Пожалуйста, введите свой адрес электронной 

		public string Email { get; set; }
		[Required(ErrorMessage = "Please enter your phone number")]
		public string Phone { get; set; }
		[Required(ErrorMessage = "Please specify whether you'll attend")]
		// Пожалуйста, укажите, примете ли участие
		public bool? WillAttend { get; set; }
	}
}

