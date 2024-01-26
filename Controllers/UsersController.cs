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

			if (user.Username != null && user.Password != null)
			{
				user.Username = Sanitizer.GetSafeHtmlFragment(user.Username);
				user.Password = Sanitizer.GetSafeHtmlFragment(user.Password);
			}

			string view = string.Empty;

			

			using (DbContextBSystem dbContext = new DbContextBSystem())
			{

				string password = Convert.ToBase64String(Cryptographic.EncryptStringToByte(user.Password, _configuration["CryptoKey"], new byte[int.Parse(_configuration["IV"])]));

				var myUser = dbContext.Users.Where(x => x.Username.Contains(user.Username)).Where(x => x.Password.Contains(password)).ToList();
				
				if (myUser.Count >= 0)
					view = "../Clients/Index";
				else
					view = "index";


				ViewBag.IdUser = (
									from us in myUser
									select new
									{
										us.IdUser
									}

								).First().IdUser;
			}

			return View(view);

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