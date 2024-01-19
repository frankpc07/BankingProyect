using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankingProyect.Entities
{
	public class Currencys
	{
		[Key]
		public int IdCurrency { get; set; }
		public string Currency { get; set; }
	}
}
