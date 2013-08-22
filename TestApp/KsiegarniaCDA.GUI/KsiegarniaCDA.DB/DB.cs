namespace KsiegarniaCDA.DB
{
	using System;
	using System.Collections.Generic;
	using KsiegarniaCDA.DTO;

	public static class DB
	{
		#region Properties

		public static List<Ksiazka> Ksiazki { get; private set; }

		public static List<Autor> Autorzy { get; private set; }

		public static List<Gatunek> Gatunki { get; private set; }

		#endregion

		#region Constructors
		
		static DB()
		{
			InitializeDB();
		}

		#endregion

		#region Private methods

		private static void InitializeDB()
		{
			Autorzy = new List<Autor>()
			{
				new Autor() { Id = 1, Imie = "Stanisław", Nazwisko = "Lem", DataUrodzenia = new DateTime(1921, 9, 12) },
				new Autor() { Id = 2, Imie = "Andrzej", Nazwisko = "Sapkowski", DataUrodzenia = new DateTime(1948, 6, 21) },
				new Autor() { Id = 3, Imie = "John", Nazwisko = "Scalzi", DataUrodzenia = new DateTime(1969, 5, 10) },
				new Autor() { Id = 4, Imie = "J.R.R.", Nazwisko = "Tolkien", DataUrodzenia = new DateTime(1892, 1, 3) },
				new Autor() { Id = 5, Imie = "Agatha", Nazwisko = "Christie", DataUrodzenia = new DateTime(1890, 9, 12) },
			};

			Gatunki = new List<Gatunek>()
			{
				new Gatunek() { Id = 1, Nazwa = "Fantastyka naukowa", Opis = "Gatunek literacki lub filmowy, a także gry komputerowe o fabule osnutej na przewidywanych osiągnięciach nauki i techniki oraz ukazującej ich wpływ na życie jednostki lub społeczeństwa."},
				new Gatunek() { Id = 2, Nazwa = "Fantasy", Opis = "Gatunek literacki lub filmowy używający magicznych i innych nadprzyrodzonych form, motywów, jako pierwszorzędnego składnika fabuły, myśli przewodniej, czasu, miejsca akcji, postaci i okoliczności zdarzeń."},
				new Gatunek() { Id = 3, Nazwa = "Powieść kryminalna", Opis = "Odmiana powieści charakteryzująca się fabułą zorganizowaną wokół zbrodni, okoliczności dojścia do niej, dochodzenia oraz ujawnienia osoby sprawcy."},
				new Gatunek() { Id = 4, Nazwa = "Powieść historyczna", Opis = "Odmiana powieści XIX w., w której świat przedstawiony umieszczony jest w minionym czasie i odległej przestrzeni." },
			};

			Ksiazki = new List<Ksiazka>()
			{
			    new Ksiazka() { Id = 1, IdAutora = 1, IdGatunku = 1, Tytul = "Dzienniki gwiazdowe", RokWydania = new DateTime(2008, 1, 1), Wydawnictwo = "Agora", Opis = "Kosmiczny wędrowiec Ijon Tichy przemierza międzyplanetarne przestrzenie w poszukiwaniu nowych przygód i doświadczeń. Poznając obce pozaziemskie cywilizacje, styka się z problemami, w których z łatwością dostrzegamy odbicie wynaturzeń naszej ziemskiej cywilizacji." },
				new Ksiazka() { Id = 2, IdAutora = 2, IdGatunku = 2, Tytul = "Krew Elfów", RokWydania = new DateTime(1994, 1, 1), Wydawnictwo = "superNOWA", Opis = "Pierwsza z pięciu części sagi o wiedźminie"},
				new Ksiazka() { Id = 3, IdAutora = 2, IdGatunku = 2, Tytul = "Czas pogardy", RokWydania = new DateTime(1995, 1, 1), Wydawnictwo = "superNOWA", Opis = "Druga z pięciu części sagi o wiedźminie"},
				new Ksiazka() { Id = 4, IdAutora = 3, IdGatunku = 1, Tytul = "Wojna starego człowieka", RokWydania = new DateTime(2008, 1, 1), Wydawnictwo = "ISA", Opis = "W dniu swoich siedemdziesiątych piątych urodzin John Perry zrobił dwie rzeczy. Najpierw odwiedził grób swojej żony. A potem wstąpił do armii.\nLudzkość w końcu znalazła drogę do międzygwiezdnej przestrzeni – to dobra wiadomość. Zła wiadomość jest taka, że w kosmosie jest niewiele nadających się do zamieszkania planet – za to aż roi się tam od obcych, którzy chcą o nie walczyć. Wychodzi na to, że wszechświat jest dla człowieka wrogim miejscem."},
				new Ksiazka() { Id = 5, IdAutora = 4, IdGatunku = 2, Tytul = "Silmarillion", RokWydania = new DateTime(2007, 1, 1), Wydawnictwo = "Amber", Opis = "Silmarillion to zbiór opowieści o Dawnych Dniach, czyli o Pierwszej Erze Świata, poprzedzającej epokę, w której rozgrywa się akcja Władcy Pierścieni. Legendy i mity sięgają zamierzchłych czasów, gdy pierwszy Władca Ciemności, Morgoth, przebywał w Śródziemiu, a Elfy Wysokiego Rodu toczyły z nim wojnę, by odzyskać Silmarile, trzy świetliste klejnoty, w których przetrwało światło Dwóch Drzew Valinoru."},
				new Ksiazka() { Id = 6, IdAutora = 5, IdGatunku = 3, Tytul = "Dziesięciu Murzynków", RokWydania = new DateTime(1999, 1, 1), Wydawnictwo = "Prószyński i S-ka", Opis = "eden z najbardziej znanych kryminałów mistrzyni tego gatunku. Tajemniczy \"ktoś\" zaprasza na weekend na słynną Wyspę Murzynków dziesięć zupełnie różnych osób, zapowiadając wypoczynek i masę atrakcji. W przygotowanych dla siebie pokojach znajdują tekst dziecięcego wierszyka o dziesięciu Murzynkach, które po kolei znikały. Nie wiedzą, że ich czeka to samo..."},
				new Ksiazka() { Id = 7, IdAutora = 2, IdGatunku = 4, Tytul = "Narrenturm", RokWydania = new DateTime(2002, 1, 1), Wydawnictwo = "superNOWA", Opis = "Tematem powieści są przygody Reinmara z Bielawy, zwanego Reynevanem. Akcja Narrenturm rozgrywa się na Śląsku w roku 1425. Tłem dla powieści są wojny husyckie."},
			};
		}

		#endregion
	}
}