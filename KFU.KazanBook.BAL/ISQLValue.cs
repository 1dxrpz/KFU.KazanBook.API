using System;
using System.Collections.Generic;
using System.Text;

namespace KFU.KazanBook.BAL
{
	public interface ISQLValue
	{
		public string Db { get; }
		public string Post { get; }
		public string Delete { get; }
		public string GetId { get; }
		public List<String> GetFilter { get; }
	}
}
