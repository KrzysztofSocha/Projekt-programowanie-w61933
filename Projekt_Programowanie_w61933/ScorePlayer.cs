using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Programowanie_w61933
{
    /// <summary>
    /// Klasa odpowiedzialna za pobieranie i zapisywanie statystyk wygran do pliku txt
    /// </summary>
    class ScorePlayer
    {
        public string word;
        public string playerName;
        public int countError;
        /// <summary>
        /// Konstruktor, który tworzy rekord w pliku z wynikami wygranych
        /// </summary>
        /// <param name="word">Parametr potrzebny do zapamiętania słowa użytego w rozgrywce</param>
        /// <param name="playerName">Parametr potrzbny do przekazania nazwy gracza do pliku</param>
        /// <param name="countError">Parametr potrzebny przekazania ilości błędów do pliku</param>
        public ScorePlayer(string word, string playerName, int countError)
        {
            this.word = word;
            this.playerName = playerName;
            this.countError = countError;
            StreamWriter sw;
            sw = new StreamWriter("ScorePlayer.txt", true);
            sw.WriteLine("PlayerName: " + this.playerName + " Word: " + this.word + " CountError: " + this.countError);
            sw.Close();
        }
        /// <summary>
        /// Konstruktor, który na podstwie linijki z tekstu wyciąga potrzebne dane do dalszych operacji
        /// </summary>
        /// <param name="record">Zawiera linijkę z pliku tekstowego</param>
        public ScorePlayer(string record)
        {
            string [] columnsRecord= record.Split(' ');
            this.word = columnsRecord[3];
            this.playerName = columnsRecord[1];
            this.countError = Convert.ToInt32(columnsRecord[5]);
        }

    }
}
