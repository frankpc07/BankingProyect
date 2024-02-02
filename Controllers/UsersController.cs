using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankingProyect.Data;
using BankingProyect.Models.Entity;
using Microsoft.Security.Application;
using Microsoft.AspNetCore.Mvc;
using BankingProyect.Utils;
using Microsoft.Extensions.Configuration;

namespace BankingProyect.Controllers
{
    public class UsersController : Controller
    {
		IConfiguration _configuration;
		public UsersController(IConfiguration configuration)
		{
			_configuration = configuration;

		}
        public IActionResult Index()
        {
            return View();
        }

		

		public IActionResult Login(Users user)
		{
			int IdUser = 0;
			int IdClient = 0;

			if (user.Username != null && user.Password != null)
			{
				user.Username = Sanitizer.GetSafeHtmlFragment(user.Username);
				user.Password = Sanitizer.GetSafeHtmlFragment(user.Password);
			}
						
			using (DbContextBSystem dbContext = new DbContextBSystem())
			{

				string password = Convert.ToBase64String(Cryptographic.EncryptStringToByte(user.Password, _configuration["CryptoKey"], new byte[int.Parse(_configuration["IV"])]));

				var User = dbContext.Users.Where(x => x.Username.Contains(user.Username)).Where(x => x.Password.Contains(password));
				
				if (User.Count() > 0)
				{
					IdUser = User.Select(y => y.IdUser).FirstOrDefault();

					var client = dbContext.Clients.Where(y => y.IdUser == IdUser );

					foreach (var item in client)
					{
						IdClient = item.IdClient;
					}
				}
				else
				{
					Save(user);
				}
					

			}
			if (IdClient > 0)
			{
				return RedirectToAction("Index", "Account", new { Id = IdClient });
			}
			else
			{
				ViewBag.IdUser = IdUser;
				return View("../Clients/Index");
			}

		}
		public void Save(Users user)
		{
			if (user.Username != null && user.Password != null)
			{
				user.Username = Sanitizer.GetSafeHtmlFragment(user.Username);
				user.Password = Sanitizer.GetSafeHtmlFragment(user.Password);
			}

			user.Password = Convert.ToBase64String(Cryptographic.EncryptStringToByte(user.Password, _configuration["CryptoKey"], new byte[int.Parse(_configuration["IV"])]));
				
			using (DbContextBSystem dbContext = new DbContextBSystem())
			{
				dbContext.Users.Add(user);
				dbContext.SaveChanges();
				ViewBag.save = true;
			}

			Redirect("Index");
			
		}
	}
}