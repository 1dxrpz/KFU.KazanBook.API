using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KFU.KazanBook.API.Models
{
	public class Book
	{
		public Guid Id { get; set; }
		public Guid AuthorId { get; set; }
		public string Name { get; set; }
	}
}
