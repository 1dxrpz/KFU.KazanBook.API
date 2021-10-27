using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace KFU.KazanBook.BAL
{
	public abstract class EntityController : Controller
	{
		public NpgsqlCommand command;
		public NpgsqlConnection connection = new NpgsqlConnection("User ID=postgres; Server=localhost; port=5432; Database=kazanbook; Password=123456; Pooling=true;");

		private Parser _parser = new Parser();

		private string db;
		public SQLValue SQLValue;

		public void Method(SQLValue value)
		{
			SQLValue = value;
		}

		[HttpDelete]
		[HttpGet]
		[HttpPost]
		public void ExecuteQuery()
		{



		}
	}
}
