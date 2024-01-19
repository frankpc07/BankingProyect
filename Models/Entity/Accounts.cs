using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankingProyect.Entities
{
	public class Accounts
	{	[Key]
		public int IdAccount { get; set; }

		[Required]
		public string Account { get; set; }

		public decimal Balance { get; set; }

		public ICollection<Users> IdUser { get; set; }

	}
}
