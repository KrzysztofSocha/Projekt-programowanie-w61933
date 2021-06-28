using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Programowanie_w61933
{
    class ScorePlayer
    {
        public string word;
        public string playerName;
        public int countError;
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
        public ScorePlayer(string record)
        {
            string [] columnsRecord= record.Split(' ');
            this.word = columnsRecord[3];
            this.playerName = columnsRecord[1];
            this.countError = Convert.ToInt32(columnsRecord[5]);
        }

    }
}
