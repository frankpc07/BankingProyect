using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingProyect.Models.Entity
{
	public class Clients
	{
		[Key]
		public int IdClient { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public int IdUser { get; set; }

		public ICollection<Accounts> Accounts { get; set; }
	}
}
