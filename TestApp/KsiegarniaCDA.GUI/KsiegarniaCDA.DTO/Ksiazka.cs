namespace KsiegarniaCDA.DTO
{
	using System;

	public class Ksiazka
	{
		public int Id { get; set; }
		public string Tytul { get; set; }
		public int IdAutora { get; set; }
		public int IdGatunku { get; set; }
		public DateTime? RokWydania { get; set; }
		public string Wydawnictwo { get; set; }
		public string Opis { get; set; }
	}
}
