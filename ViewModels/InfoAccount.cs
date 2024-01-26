using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingProyect.ViewModels
{
	public class InfoAccount
	{
		public int IdClient { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Account { get; set; }
		public decimal Balance { get; set; }
	}
}
