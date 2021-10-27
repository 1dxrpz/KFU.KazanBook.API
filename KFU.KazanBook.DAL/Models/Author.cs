using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KFU.KazanBook.DAL.Models
{
	public class Author
	{
		public Guid Id { get; set; }
		public string SurName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime DateOfDeath { get; set; }
	}
	public class AuthorViewModel : BaseViewModel
	{
		public Guid Id { get; set; }
		public string SurName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime DateOfDeath { get; set; }
	}
}
