using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parprog
{
    class TolvKamper
    {
        private Match[] _matches;

        public TolvKamper(string betsText)
        {
            var bets = betsText.Split(',');
            _matches = new Match[12];
            for (var i = 0; i < 12; i++)
            {
                _matches[i] = new Match(bets[i]);
            }
        }

        public void AddGoal(int MatchNo, bool IsHomeTeam)
        {
            var SelectedIntex = MatchNo - 1;
            var SelectedMatch = _matches[SelectedIntex];
            SelectedMatch.AddGoal(IsHomeTeam);
        }

        public void ShowAllScores()
        {
            for (var index = 0; index < _matches.Length; index++)
            {
                var match = _matches[index];
                var MatchNo = index + 1;
                var IsBetCorrect = match.IsBetCorrect();
                var IsBetCorrectText = IsBetCorrect ? "riktig" : "feil";
                Console.WriteLine($"Kamp {MatchNo}: {match.GetScore()} - {IsBetCorrectText}");
            }
        }

        public void ShowCorrectCount()
        {
            var correctCount = 0;
            foreach (var match in _matches)
            {
                if (match.IsBetCorrect()) correctCount++;

            }
            Console.WriteLine($"Du har {correctCount} rette.");

        }

    }
}
