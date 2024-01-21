using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankingProyect.Models.Entity
{
	public class Journal
	{
		[Key]
		public int IdJournal { get; set; }
		public float Amount { get; set; }
		public float TotalCommision { get; set; }
		public DateTime DateAmount { get; set; }

		public ICollection<Accounts> IdAcount { get; set; }
		public ICollection<Currencys> IdCurrency { get; set; }
		public ICollection<Operations> IdOperation { get; set; }

	}
}
