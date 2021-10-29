using System;
using System.Collections.Generic;
using System.Text;

namespace KFU.KazanBook.BAL
{
	public class BookSQL : ISQLValue
	{
		public string Post => "\"Id\", \"title\", \"authorId\", \"year\", \"numberPages\", \"country\"";
		public string Db => "Books";

		public string Delete => "authorId";

		public string GetId => "authorId";

		public List<string> GetFilter => new List<string>() { "year", "title" };
	}
}
