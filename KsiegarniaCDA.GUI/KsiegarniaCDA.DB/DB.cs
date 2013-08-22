using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KsiegarniaCDA.DTO;

namespace KsiegarniaCDA.DB
{
    public static class DB
    {
        #region Properties

        public static List<Ksiazka> Ksiazki { get; set; }
        public static List<Autor> Autorzy { get; set; }
        public static List<Gatunek> Gatunki { get; set; }

        #endregion



        #region Construktors

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
				new Autor() { id = 1, imie = "Stanisław", nazwisko = "Lem", dataUrodzenia = new DateTime(1921, 9, 12) },
				new Autor() { id = 2, imie = "Andrzej", nazwisko = "Sapkowski", dataUrodzenia = new DateTime(1948, 6, 21) },
				new Autor() { id = 3, imie = "John", nazwisko = "Scalzi", dataUrodzenia = new DateTime(1969, 5, 10) },
				new Autor() { id = 4, imie = "J.R.R.", nazwisko = "Tolkien", dataUrodzenia = new DateTime(1892, 1, 3) },
				new Autor() { id = 5, imie = "Agatha", nazwisko = "Christie", dataUrodzenia = new DateTime(1890, 9, 12) },
			};

            Gatunki = new List<Gatunek>()
			{
				new Gatunek() { id = 1, nazwa = "Fantastyka naukowa", opis = "Gatunek literacki lub filmowy, a także gry komputerowe o fabule osnutej na przewidywanych osiągnięciach nauki i techniki oraz ukazującej ich wpływ na życie jednostki lub społeczeństwa."},
				new Gatunek() { id = 2, nazwa = "Fantasy", opis = "Gatunek literacki lub filmowy używający magicznych i innych nadprzyrodzonych form, motywów, jako pierwszorzędnego składnika fabuły, myśli przewodniej, czasu, miejsca akcji, postaci i okoliczności zdarzeń."},
				new Gatunek() { id = 3, nazwa = "Powieść kryminalna", opis = "Odmiana powieści charakteryzująca się fabułą zorganizowaną wokół zbrodni, okoliczności dojścia do niej, dochodzenia oraz ujawnienia osoby sprawcy."},
				new Gatunek() { id = 4, nazwa = "Powieść historyczna", opis = "Odmiana powieści XIX w., w której świat przedstawiony umieszczony jest w minionym czasie i odległej przestrzeni." },
			};

            Ksiazki = new List<Ksiazka>()
			{
			    new Ksiazka() { id = 1, idAutora = 1, idGatunku = 1, tytul = "Dzienniki gwiazdowe", rokWydania = new DateTime(2008, 1, 1), wydawnictwo = "Agora", opis = "Kosmiczny wędrowiec Ijon Tichy przemierza międzyplanetarne przestrzenie w poszukiwaniu nowych przygód i doświadczeń. Poznając obce pozaziemskie cywilizacje, styka się z problemami, w których z łatwością dostrzegamy odbicie wynaturzeń naszej ziemskiej cywilizacji." },
				new Ksiazka() { id = 2, idAutora = 2, idGatunku = 2, tytul = "Krew Elfów", rokWydania = new DateTime(1994, 1, 1), wydawnictwo = "superNOWA", opis = "Pierwsza z pięciu części sagi o wiedźminie"},
				new Ksiazka() { id = 3, idAutora = 2, idGatunku = 2, tytul = "Czas pogardy", rokWydania = new DateTime(1995, 1, 1), wydawnictwo = "superNOWA", opis = "Druga z pięciu części sagi o wiedźminie"},
				new Ksiazka() { id = 4, idAutora = 3, idGatunku = 1, tytul = "Wojna starego człowieka", rokWydania = new DateTime(2008, 1, 1), wydawnictwo = "ISA", opis = "W dniu swoich siedemdziesiątych piątych urodzin John Perry zrobił dwie rzeczy. Najpierw odwiedził grób swojej żony. A potem wstąpił do armii.\nLudzkość w końcu znalazła drogę do międzygwiezdnej przestrzeni – to dobra wiadomość. Zła wiadomość jest taka, że w kosmosie jest niewiele nadających się do zamieszkania planet – za to aż roi się tam od obcych, którzy chcą o nie walczyć. Wychodzi na to, że wszechświat jest dla człowieka wrogim miejscem."},
				new Ksiazka() { id = 5, idAutora = 4, idGatunku = 2, tytul = "Silmarillion", rokWydania = new DateTime(2007, 1, 1), wydawnictwo = "Amber", opis = "Silmarillion to zbiór opowieści o Dawnych Dniach, czyli o Pierwszej Erze Świata, poprzedzającej epokę, w której rozgrywa się akcja Władcy Pierścieni. Legendy i mity sięgają zamierzchłych czasów, gdy pierwszy Władca Ciemności, Morgoth, przebywał w Śródziemiu, a Elfy Wysokiego Rodu toczyły z nim wojnę, by odzyskać Silmarile, trzy świetliste klejnoty, w których przetrwało światło Dwóch Drzew Valinoru."},
				new Ksiazka() { id = 6, idAutora = 5, idGatunku = 3, tytul = "Dziesięciu Murzynków", rokWydania = new DateTime(1999, 1, 1), wydawnictwo = "Prószyński i S-ka", opis = "eden z najbardziej znanych kryminałów mistrzyni tego gatunku. Tajemniczy \"ktoś\" zaprasza na weekend na słynną Wyspę Murzynków dziesięć zupełnie różnych osób, zapowiadając wypoczynek i masę atrakcji. W przygotowanych dla siebie pokojach znajdują tekst dziecięcego wierszyka o dziesięciu Murzynkach, które po kolei znikały. Nie wiedzą, że ich czeka to samo..."},
				new Ksiazka() { id = 7, idAutora = 2, idGatunku = 4, tytul = "Narrenturm", rokWydania = new DateTime(2002, 1, 1), wydawnictwo = "superNOWA", opis = "Tematem powieści są przygody Reinmara z Bielawy, zwanego Reynevanem. Akcja Narrenturm rozgrywa się na Śląsku w roku 1425. Tłem dla powieści są wojny husyckie."},
			};

        }

        #endregion



    }
}
