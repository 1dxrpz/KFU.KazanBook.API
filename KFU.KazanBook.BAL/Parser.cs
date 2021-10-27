using KFU.KazanBook.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KFU.KazanBook.BAL
{
	public class Parser
	{
		public Book Parse(BookViewModel model)
		{
			return new Book()
			{
				Id = new Guid(),
				authorId = new Guid(model.authorId),
				country = model.country,
				numberPages = model.numberPages,
				title = model.title,
				year = new DateTime(Int32.Parse(model.year), 1, 1)
			};
		}
		public Author Parse(AuthorViewModel model)
		{
			return null;
		}
	}
}
