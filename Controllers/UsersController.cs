using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingProyect.Data;
using BankingProyect.Models.Entity;
using Microsoft.Security.Application;
using Microsoft.AspNetCore.Mvc;

namespace BankingProyect.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

		public void Save(Users user)
		{
			if (user.Username != null && user.Password != null)
			{
				user.Username = Sanitizer.GetSafeHtmlFragment(user.Username);
				user.Password = Sanitizer.GetSafeHtmlFragment(user.Password);
			}
				
			using (DbContextBSystem dbContext = new DbContextBSystem())
			{
				dbContext.Users.Add(user);
				dbContext.SaveChanges();

			}
		}
	}
}