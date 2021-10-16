using KFU.KazanBook.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KFU.KazanBook.API.Controllers
{
	public class BookController : Controller
	{
		NpgsqlCommand command;
		NpgsqlConnection connection = new NpgsqlConnection();
		NpgsqlDataReader dataReader;

		List<Book> Books = new List<Book>();

		// GET: BookController
		public ActionResult Index()
		{
			connection.ConnectionString = "User ID=postgres; Server=localhost; port=5432; Database=kazanbook; Password=123456; Pooling=true;";
			connection.Open();
			var sql = "SELECT * FROM \"Books\"";
			command = new NpgsqlCommand(sql, connection);
			//dataReader = command.ExecuteReader();

			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					Books.Add(new Book() {
						Id = reader.GetFieldValue<Guid>(0),
						Name = reader.GetFieldValue<string>(1)
					});
				}
			}
			connection.Close();
			return Ok(Books);
		}
		[HttpGet]
		public ActionResult GetAll()
		{
			
			return Ok("f");
		}

		[HttpPost]
		public ActionResult Insert()
		{
			connection.ConnectionString = "User ID=postgres; Server=localhost; port=5432; Database=kazanbook; Password=123456; Pooling=true;";
			connection.Open();
			var sql = $"INSERT INTO public.\"Books\"(\"Id\", \"AuthorId\", \"Name\") VALUES ({new Guid(1)}, 0, 'Test');";
			command = new NpgsqlCommand(sql, connection);
			//dataReader = command.ExecuteReader();

			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					Books.Add(new Book()
					{
						Id = reader.GetFieldValue<Guid>(0),
						Name = reader.GetFieldValue<string>(1)
					});
				}
			}
			connection.Close();
			return Ok("succ");
		}

		// GET: BookController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: BookController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: BookController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: BookController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: BookController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: BookController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: BookController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
