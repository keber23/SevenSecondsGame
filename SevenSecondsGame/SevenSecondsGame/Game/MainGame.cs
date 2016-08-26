using SevenSecondsGame.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenSecondsGame.Game
{
    public class MainGame
    {
        QuestionService service = new QuestionService();

        List<Player> players;

        int current = 0;

        public MainGame()
        {

        }
        
        public void StartGame(string f1, string f2, string f3, string f4)
        {
            players = new List<Player>();

            if (!string.IsNullOrEmpty(f1))
                players.Add(new Player() { Name = f1 } );

            if (!string.IsNullOrEmpty(f2))
                players.Add(new Player() { Name = f2 });
            
            if (!string.IsNullOrEmpty(f3))
                players.Add(new Player() { Name = f3 });

            if (!string.IsNullOrEmpty(f4))
                players.Add(new Player() { Name = f4 });

        }

        public string GetCurrentPlayer()
        {
            return players[current].Name;
        }

        public List<string> GetPlayersScores()
        {
            var result = new List<string>();

            if (players != null)
            {
                foreach (var player in players.OrderByDescending(p => p.Score))
                {
                    result.Add(player.Name + ": " + player.Score);
                }
            }

            return result;
        }

        internal bool CheckWinner()
        {
            //check if current user is winner
            return players[current].Score >= 7;                
        }

        public string GetQuestion()
        {
            return service.GetNextQuestion();
        }

        internal void AddPointsToCurrentUser()
        {
            players[current].Score++;
        }

        public void NextPlayer()
        {
            current++;

            if (current >= players.Count)
                current = 0;
        }

    }
}
