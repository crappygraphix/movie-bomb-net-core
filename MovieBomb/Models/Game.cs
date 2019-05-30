using System;
using System.ComponentModel.DataAnnotations;

namespace MovieBomb.Models
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Round
    {
        public int ID { get; set; }
    }
}
