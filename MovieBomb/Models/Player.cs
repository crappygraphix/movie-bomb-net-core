using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieBomb.Models
{
    public enum Bomb
    {
        B, BO, BOM, BOMB
    }
    public class Player
    {
        public int ID { get; set; }
        public int GameID { get; set; }
        public string Name { get; set; }
        public Bomb Bomb { get; set; }
    }
}
