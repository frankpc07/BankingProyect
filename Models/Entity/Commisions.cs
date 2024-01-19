using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankingProyect.Entities
{
	public class Commisions
	{
		[Key]
		public int IdCommision { get; set; }
		public decimal Commision { get; set; }
	}
}
