using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankingProyect.Models.Entity
{
	public class Commisions
	{
		[Key]
		public int IdCommision { get; set; }
		public decimal Commision { get; set; }
		
		public ICollection<Operations> Operations { get; set; }
	}
}
