﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BankingProyect.Models.Entity
{
	public class Operations
	{
		[Key]
		public int IdOperation { get; set; }
		public string Operation { get; set; }
		public int IdCommision { get; set; }

		public ICollection<Journal> Journal { get; set; }

	}
}
