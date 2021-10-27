using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace KFU.KazanBook.BAL
{
	public class QueryExecutor : EntityController
	{
		private string sql;
		[HttpPost]
		public void Post(string postValues)
		{
			connection.Open();
			sql = $"INSERT INTO \"{SQLValue.Db}\" ({SQLValue.Post}) VALUES ({postValues});";
			command = new NpgsqlCommand(sql, connection);
			command.ExecuteNonQuery();
			connection.Close();
		}
	}
}
