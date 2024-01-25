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

		public int IdAccount { get; set; }
		public int  IdCurrency { get; set; }
		public int IdOperation { get; set; }

	}
}
