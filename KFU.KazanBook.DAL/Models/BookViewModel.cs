using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KFU.KazanBook.DAL.Models
{
	public class BookViewModel
	{
		public Guid Id { get; set; }
		public Guid authorId { get; set; }
		public string title { get; set; }
		public DateTime year { get; set; }
		public int numberPages { get; set; }
		public string country { get; set; }
	}
}
