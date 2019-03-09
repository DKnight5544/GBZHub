using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hub.Farkle.CustomClasses
{
    public class Move
    {
        public int Turn;
        public string Dice;
        public string Response;
        public int NewPoints;
        public int PointsInPlay;
        public int BankedPoints;
        public bool IsFarkle;
        public bool IsIllegal;
    }
}