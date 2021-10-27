using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KFU.KazanBook.DAL.Models
{
	public class Book
	{
		public Guid Id { get; set; }
		public Guid authorId { get; set; }
		public string title { get; set; }
		public DateTime year { get; set; }
		public int numberPages { get; set; }
		public string country { get; set; }
	}
	public class BookViewModel : BaseViewModel
	{
		public string Id { get; set; }
		public string authorId { get; set; }
		public string title { get; set; }
		public string year { get; set; }
		public int numberPages { get; set; }
		public string country { get; set; }
	}
	
}
