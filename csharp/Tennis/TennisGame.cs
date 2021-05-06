 class TennisGame : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {

            return m_score1 == m_score2 ? GetScoreEqualCases() : (m_score1 >= 4 || m_score2 >= 4) ? ScoreEqualGreaterFour() : ElseScoreCases();
        }

        #region private methods

        private string GetScoreEqualCases()
        {
            switch (m_score1)
            {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                default:
                    return "Deuce";
            }
        }

        private string ScoreEqualGreaterFour()
        {
            var minusResult = m_score1 - m_score2;

            return minusResult == 1 ? "Advantage player1" : minusResult == -1 ? "Advantage player2" : minusResult >= 2 ? "Win for player1" : "Win for player2";
            
        }

        private string ElseScoreCases()
        {
            int tempScore;
            var score = "";

            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = m_score1;
                else { score += "-"; tempScore = m_score2; }
                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }

            return score;
        }

        #endregion

    }
}

