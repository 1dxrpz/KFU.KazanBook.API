using System;
using System.Collections.Generic;
using System.Text;

namespace KFU.KazanBook.BAL
{
	public class AuthorSQL : ISQLValue
	{
		public string Post => "\"Id\", \"surname\", \"lastname\", \"firstname\", \"birthDate\", \"deathDate\"";
		public string Db => "Authors";

		public string Delete => "Id";

		public string GetId => "Id";

		public List<string> GetFilter => new List<string>() { "birthDate", "firstname" };
	}
}
