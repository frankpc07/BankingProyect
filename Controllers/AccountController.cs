using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using BankingProyect.Data;
using BankingProyect.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BankingProyect.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
			List<InfoAccount> inf = new List<InfoAccount>();

			using (DbContextBSystem dbContext = new DbContextBSystem())
			{
				var model = (
					from acc in dbContext.Acounts
					join cl in dbContext.Clients on acc.IdClient equals cl.IdClient
					where (cl.IdClient == 1)
					select new InfoAccount
					{
						IdClient = cl.IdClient,
						FirstName = cl.FirstName,
						LastName = cl.LastName,
						Account = acc.Account,
						Balance = acc.Balance
					}
					).ToList(); ;

				inf = model;
			}

			
			return View(inf);
        }
    }
}