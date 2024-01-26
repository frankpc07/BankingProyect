using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingProyect.Data;
using BankingProyect.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Security.Application;

namespace BankingProyect.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Create(Clients clients)
		{
			int IdCl = 0;
			if (clients.FirstName != null && clients.LastName != null)
			{
				clients.FirstName = Sanitizer.GetSafeHtmlFragment(clients.FirstName);
				clients.LastName = Sanitizer.GetSafeHtmlFragment(clients.LastName);
			}

			using (DbContextBSystem dbContext = new DbContextBSystem())
			{
				dbContext.Clients.Add(clients);
				dbContext.SaveChanges();
				IdCl = clients.IdClient;
			}

			return View("../Account/");
		}
    }
}