using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankingProyect.Models.Entity
{
	public class Currencys
	{
		[Key]
		public int IdCurrency { get; set; }
		public string Currency { get; set; }

		public ICollection<Journal> Journal { get; set; }

	}
}
