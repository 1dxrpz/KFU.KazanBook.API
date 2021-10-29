using Npgsql;
using KFU.KazanBook.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text;
using KFU.KazanBook.BAL;
using System.Net.Http;

namespace KFU.KazanBook.API.Controllers
{
	public class BooksController : QueryExecutor
	{
		[HttpPost]
		public IActionResult Index([FromBody] Book model)
		{
			Model(new BookSQL());
			Post($"'{Guid.NewGuid()}', '{model.title}', '{model.authorId}', '{model.year}', {model.numberPages}, '{model.country}'");
			return Ok("Posted");
		}
		[HttpGet]
		[HttpDelete]
		public IActionResult Index(string id, string year, string title)
		{
			Model(new BookSQL());
			if (year == null && title == null && id != null)
			{
				if (Request.Method == HttpMethods.Delete)
					Delete(id);
				if (Request.Method == HttpMethods.Get)
					return Ok(Get<Book>(id));
			}
			if (year != null && title != null && id == null)
				return Ok(GetFilter<Book>(year, title));
			return Ok("default");
		}

	}
}