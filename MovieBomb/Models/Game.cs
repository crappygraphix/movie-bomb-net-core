using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieBomb.Models
{
    public class Game
    {
        public int ID { get; set; }
        public ICollection<Player> Players { get; set; }
        public ICollection<Round> Rounds { get; set; }
    }

    public enum RoundState
    {
        Start, Answer, Lies, Defend, End
    }

    public class Round
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public int PlayerID { get; set; }
        public RoundState RoundState { get; set; }

        public Player Player { get; set; }
        public ICollection<Turn> Turns { get; set; }
    }

    public class Turn
    {
        public int ID { get; set; }
        public int RoundID { get; set; }
        public Player Player { get; set; }
    }
}
