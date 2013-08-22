namespace KsiegarniaCDA.DTO
{
	using System;

	public class Autor
	{
		public int Id { get; set; }
		public string Imie { get; set; }
		public string Nazwisko { get; set; }
		public DateTime? DataUrodzenia { get; set; }
	}
}