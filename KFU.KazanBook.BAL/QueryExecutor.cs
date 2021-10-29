using KFU.KazanBook.DAL.Models;
using Npgsql;
using System;
using System.Collections.Generic;

namespace KFU.KazanBook.BAL
{
	public class QueryExecutor : EntityController
	{
		private List<BookViewModel> _books = new List<BookViewModel>();
		private string _sql;
		public void Post(string postValues)
		{
			_sql = $"INSERT INTO \"{SQLValue.Db}\" ({SQLValue.Post}) VALUES ({postValues});";
			ExecuteSQL();
		}
		public void Delete(string id)
		{
			_sql = $"DELETE FROM \"{SQLValue.Db}\" WHERE \"{SQLValue.Delete}\"='{id}';";
			ExecuteSQL();
		}
		public T Get<T>(string id) where T : IBaseModel, new()
		{
			IBaseModel result = new T();
			connection.Open();
			_sql = $"SELECT * FROM \"{SQLValue.Db}\" WHERE \"{SQLValue.GetId}\" = '{id}'";
			command = new NpgsqlCommand(_sql, connection);
			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					if (SQLValue is BookSQL)
					{
						result = new Book()
						{
							Id = reader.GetFieldValue<Guid>(0),
							title = reader.GetFieldValue<string>(1),
							authorId = reader.GetFieldValue<Guid>(2),
							numberPages = reader.GetFieldValue<int>(3),
							country = reader.GetFieldValue<string>(4),
							year = reader.GetFieldValue<string>(5)
						};
					}
					if (SQLValue is AuthorSQL)
					{
						result = new Author()
						{
							Id = reader.GetFieldValue<Guid>(0),
							surname = reader.GetFieldValue<string>(1),
							lastname = reader.GetFieldValue<string>(2),
							firstname = reader.GetFieldValue<string>(3),
							birthDate = reader.GetFieldValue<string>(4),
							deathDate = reader.GetFieldValue<string>(5)
						};
					}
				}
			}
			connection.Close();
			return (T)result;
		}

		public IBaseModel GetFilter<T>(params string[] filters) where T : IBaseModel, new()
		{
			List<IBaseModel> result = new List<IBaseModel>();
			string sqlTemp = "";
			for (int i = 0; i < filters.Length; i++)
			{
				sqlTemp += $"\"{SQLValue.GetFilter[i]}\" = '{filters[i]}'";
				if (i != filters.Length - 1)
					sqlTemp += " AND ";
			}
			connection.Open();
			_sql = $"SELECT * FROM \"{SQLValue.Db}\" WHERE {sqlTemp};";
			command = new NpgsqlCommand(_sql, connection);
			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					if (SQLValue is BookSQL)
					{
						result.Add(new Book()
						{
							Id = reader.GetFieldValue<Guid>(0),
							title = reader.GetFieldValue<string>(1),
							authorId = reader.GetFieldValue<Guid>(2),
							numberPages = reader.GetFieldValue<int>(3),
							country = reader.GetFieldValue<string>(4),
							year = reader.GetFieldValue<string>(5)
						});
					}
					if (SQLValue is AuthorSQL)
					{
						result.Add(new Author()
						{
							Id = reader.GetFieldValue<Guid>(0),
							surname = reader.GetFieldValue<string>(1),
							lastname = reader.GetFieldValue<string>(2),
							firstname = reader.GetFieldValue<string>(3),
							birthDate = reader.GetFieldValue<string>(4),
							deathDate = reader.GetFieldValue<string>(5)
						});
					}
				}
			}
			connection.Close();
			return result[0];
		}
		public void Put()
		{

		}
		private void ExecuteSQL()
		{
			connection.Open();
			command = new NpgsqlCommand(_sql, connection);
			command.ExecuteNonQuery();
			connection.Close();
		}
	}
}
