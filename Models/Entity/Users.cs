using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankingProyect.Entities
{
	public class Users
	{
		[Key]
		public int IdUser { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }
	}
}
