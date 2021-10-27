using System;
using System.Collections.Generic;
using System.Text;

namespace KFU.KazanBook.BAL
{
	public class BookSQL : SQLValue
	{
		public string Post => "\"Id\", \"title\", \"authorId\", \"year\", \"numberPages\", \"country\"";
		public string Db => "Books";
	}
}
