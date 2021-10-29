using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace KFU.KazanBook.BAL
{
	public abstract class EntityController : Controller
	{
		public NpgsqlCommand command;
		public NpgsqlConnection connection = new NpgsqlConnection("User ID=postgres; Server=localhost; port=5432; Database=kazanbook; Password=123456; Pooling=true;");
		public ISQLValue SQLValue;
		public void Model(ISQLValue value)
		{
			SQLValue = value;
		}
	}
}
