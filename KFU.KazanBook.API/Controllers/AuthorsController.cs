using KFU.KazanBook.BAL;
using KFU.KazanBook.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KFU.KazanBook.API.Controllers
{
	public class AuthorsController : QueryExecutor
	{
		[HttpPost]
		public IActionResult Index([FromBody] Author model)
		{
			Model(new AuthorSQL());
			Post($"'3fa85f64-5717-4562-b3fc-2c963f66afa6', '{model.surname}', '{model.lastname}', '{model.firstname}', '{model.birthDate}', '{model.deathDate}'");
			return Ok("Posted");
		}
		[HttpGet]
		[HttpDelete]
		public IActionResult Index(string id, string age, string name)
		{
			Model(new AuthorSQL());
			if (age == null && name == null && id != null)
			{
				if (Request.Method == HttpMethods.Delete)
					Delete(id);
				if (Request.Method == HttpMethods.Get)
					return Ok(Get<Author>(id));
			}
			if (age != null && name != null && id == null)
				return Ok(GetFilter<Author>(age, name));
			return Ok("default");
		}
	}
}
