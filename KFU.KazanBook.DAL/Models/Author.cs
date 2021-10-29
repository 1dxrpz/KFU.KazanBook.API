using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KFU.KazanBook.DAL.Models
{
	public class Author : IBaseModel
	{
		public Guid Id { get; set; }
		public string surname { get; set; }
		public string firstname { get; set; }
		public string lastname { get; set; }
		public string birthDate { get; set; }
		public string deathDate { get; set; }
	}
}
