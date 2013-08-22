// -----------------------------------------------------------------------
// <copyright file="BooksSearchSearchCriteria.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace KsiegarniaCDA.DTO
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public class BooksSearchSearchCriteria
	{
		public int? IdAutora { get; set; }
		public int? IdGatunku { get; set; }
		public string Tytul { get; set; }
		public string Opis { get; set; }
		public int? RokWydania { get; set; }
		public string Wydawnictwo { get; set; }
	}
}
