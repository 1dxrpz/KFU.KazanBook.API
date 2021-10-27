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
	public enum HTTPMethod
	{
		POST,
		GET,
		DEL,
		PUT
	}
	public class BooksController : QueryExecutor
	{
		
		List<Book> Books = new List<Book>();

		[HttpPost]
		public IActionResult Index([FromBody] BookViewModel model)
		{
			Method(new BookSQL());
			Post($"'{Guid.NewGuid()}', '{model.title}', '{model.authorId}', '{model.year}', {model.numberPages}, '{model.country}'");
			return Ok("Posted");
		}
		public IActionResult Index()
		{
			Method(new BookSQL());
			
			//Books.Clear();
			//if (HttpContext.Request.Method == HttpMethod.Get.Method)
			//{
			//	if (id != null)
			//	{
			//		return Ok(id);
			//	}
			//}
			//if (HttpContext.Request.Method == HttpMethod.Delete.Method)
			//{
			//	if (id != null)
			//	{
			//		DelBookById(id);
			//	}
			//}
			//if (HttpContext.Request.Method == HttpMethod.Post.Method)
			//{
			//	PostBook(model);
			//	return Ok(model);
			//}

			
			
			return Ok("");
		}
		
		//public void DelBookById(string id)
		//{
		//	sql = $"DELETE FROM \"Books\" WHERE \"authorId\"='{id}'";
		//	command = new NpgsqlCommand(sql, connection);
		//	command.ExecuteNonQuery();
		//}
		//public void PostBook(BookViewModel model)
		//{
		//	try
		//	{
		//		sql = $"INSERT INTO \"Books\" (\"Id\", \"title\", \"authorId\", \"year\", \"numberPages\", \"country\") VALUES ('{new Guid()}', '{model.title}', '{model.authorId}', '{model.year}', {model.numberPages}, '{model.country}');";
		//		command = new NpgsqlCommand(sql, connection);
		//		command.ExecuteNonQuery();
		//	}
		//	catch (Exception ex)
		//	{
		//		throw ex;
		//	}
		//}
		//public Book GetBookById(string id)
		//{
		//	sql = $"SELECT * FROM \"Books\" WHERE \"authorId\" = '{id}'";
		//	command = new NpgsqlCommand(sql, connection);
		//	using (var reader = command.ExecuteReader())
		//	{
		//		while (reader.Read())
		//		{
		//			Books.Add(new Book()
		//			{
		//				Id = reader.GetFieldValue<Guid>(0),
		//				title = reader.GetFieldValue<string>(1),
		//				authorId = reader.GetFieldValue<Guid>(2),
		//				numberPages = reader.GetFieldValue<int>(3),
		//				country = reader.GetFieldValue<string>(4),
		//				year = new DateTime(Int32.Parse(reader.GetFieldValue<string>(5)), 1, 1)
		//			});
		//		}
		//	}
		//	return Books[0];
		//}
	}
}
