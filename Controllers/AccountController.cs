using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using BankingProyect.Data;
using Microsoft.AspNetCore.Mvc;

namespace BankingProyect.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
			dynamic mymodel = new ExpandoObject();

			using (DbContextBSystem dbContext = new DbContextBSystem())
			{
				mymodel.Client = dbContext.Clients.Where(x => x.IdUser == 1);
			}

			using (DbContextBSystem dbContext = new DbContextBSystem())
			{
				mymodel.Accounts = dbContext.Acounts.Where(x => x.IdClient == 1);
			}

			
			return View(mymodel);
        }
    }
}