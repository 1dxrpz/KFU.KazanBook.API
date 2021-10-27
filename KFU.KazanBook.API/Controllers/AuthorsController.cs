using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KFU.KazanBook.API.Controllers
{
	public class AuthorsController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}
