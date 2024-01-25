using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankingProyect.Models.Entity
{
	public class Users
	{
		[Key]
		public int IdUser { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		public string Password { get; set; }

		public ICollection<Clients> Clients { get; set; }
	}
}
