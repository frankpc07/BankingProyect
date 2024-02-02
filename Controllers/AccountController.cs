using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using BankingProyect.Data;
using BankingProyect.Models.Entity;
using BankingProyect.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingProyect.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index(int Id)
        {
			List<InfoAccount> inf = new List<InfoAccount>();

			InfoAccount infoAcc = new InfoAccount();

			using (DbContextBSystem dbContext = new DbContextBSystem())
			{
				var Account = dbContext.Acounts.Where(x => x.IdClient == Id);

				if(Account.Count() > 0)
				{
					infoAcc = (
					from acc in dbContext.Acounts
					join cl in dbContext.Clients on acc.IdClient equals cl.IdClient
					where (cl.IdClient == Id)
					select new InfoAccount
					{
						IdClient = cl.IdClient,
						FirstName = cl.FirstName,
						LastName = cl.LastName,
						Account = acc.Account,
						Balance = acc.Balance
					}
					).Single();
				}
				else
				{
					var Client = dbContext.Clients.Where(x => x.IdClient == Id).Single();

					infoAcc.FirstName = Client.FirstName;
					infoAcc.LastName = Client.LastName;
					infoAcc.IdClient = Client.IdClient;
				
				}
				
			}

			
			return View(infoAcc);
        }

		public IActionResult NewAccount(int id, Accounts accounts)
		{
			if(HttpMethods.IsPost(Request.Method))
			{
				
				using (DbContextBSystem dbContext = new DbContextBSystem())
				{
					dbContext.Acounts.Add(accounts);
					dbContext.SaveChanges();
					return RedirectToAction("Index/" + id);

				}

			}
			else
			{
				ViewBag.IdClient = id;
			}

			return View();
		}
    }
}