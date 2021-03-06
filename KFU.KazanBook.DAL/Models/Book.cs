using System;
using System.Collections.Generic;
using System.Text;

namespace KFU.KazanBook.DAL.Models
{
	public class Book : IBaseModel
	{
		public Guid Id { get; set; }
		public Guid authorId { get; set; }
		public string title { get; set; }
		public string year { get; set; }
		public int numberPages { get; set; }
		public string country { get; set; }
	}
}
