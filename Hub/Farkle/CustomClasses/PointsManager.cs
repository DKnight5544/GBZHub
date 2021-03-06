﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Hub.Farkle.CustomClasses
{
    public static class PointsManager
    {
        private static SortedDictionary<int, int> PointsDictionary = new SortedDictionary<int, int>
        {
            {1, 100},
            {5, 50},
            {11, 200},
            {51, 150},
            {55, 100},
            {111, 1000},
            {222, 200},
            {333, 300},
            {444, 400},
            {511, 250},
            {551, 200},
            {555, 500},
            {666, 600},
            {1111, 2000},
            {2221, 300},
            {2222, 400},
            {3331, 400},
            {3333, 600},
            {4441, 500},
            {4444, 800},
            {5111, 1050},
            {5222, 250},
            {5333, 350},
            {5444, 450},
            {5511, 300},
            {5551, 600},
            {5555, 1000},
            {6661, 700},
            {6666, 1200},
            {11111, 3000},
            {22211, 400},
            {22221, 500},
            {22222, 600},
            {33311, 500},
            {33331, 700},
            {33333, 900},
            {44411, 600},
            {44441, 900},
            {44444, 1200},
            {51111, 2050},
            {52221, 350},
            {52222, 450},
            {54441, 550},
            {54444, 850},
            {55111, 1100},
            {55222, 300},
            {55333, 400},
            {55444, 500},
            {55511, 700},
            {55551, 1100},
            {55555, 1500},
            {66611, 800},
            {66651, 750},
            {66655, 700},
            {66661, 1300},
            {66665, 1250},
            {66666, 1800},
            {111111, 4000},
            {221111, 750},
            {222111, 1200},
            {222211, 750},
            {222221, 450},
            {222222, 800},
            {331111, 750},
            {332211, 750},
            {332222, 750},
            {333111, 1300},
            {333222, 750},
            {333311, 800},
            {333322, 750},
            {333331, 1000},
            {333333, 1200},
            {441111, 750},
            {442211, 750},
            {442222, 750},
            {443311, 750},
            {443322, 750},
            {443333, 750},
            {444111, 1400},
            {444222, 600},
            {444333, 700},
            {444411, 1000},
            {444422, 750},
            {444433, 750},
            {444441, 1300},
            {444444, 1600},
            {511111, 3050},
            {522211, 450},
            {522221, 550},
            {522222, 650},
            {533311, 550},
            {533331, 750},
            {533333, 950},
            {544411, 650},
            {544444, 1250},
            {551111, 2100},
            {552211, 750},
            {552221, 400},
            {552222, 750},
            {553311, 750},
            {553322, 750},
            {553331, 500},
            {553333, 750},
            {554411, 750},
            {554422, 750},
            {554433, 750},
            {554444, 900},
            {555111, 1500},
            {555222, 700},
            {555333, 800},
            {555444, 900},
            {555511, 1200},
            {555522, 750},
            {555533, 750},
            {555544, 750},
            {555551, 1600},
            {555555, 2000},
            {654321, 1500},
            {661111, 750},
            {662211, 750},
            {662222, 750},
            {663311, 750},
            {663322, 750},
            {663333, 750},
            {664411, 750},
            {664422, 750},
            {664433, 750},
            {664444, 750},
            {665511, 750},
            {665522, 750},
            {665533, 750},
            {665544, 750},
            {665555, 750},
            {666111, 1600},
            {666222, 800},
            {666333, 900},
            {666444, 1000},
            {666511, 850},
            {666551, 800},
            {666555, 1100},
            {666611, 1400},
            {666622, 750},
            {666633, 750},
            {666644, 750},
            {666651, 1350},
            {666655, 1300},
            {666661, 1900},
            {666665, 1850},
            {666666, 2400}
        };

        public static int FetchPoints(int key)
        {
            string strKey = key.ToString();
            return FetchPoints(strKey);
        }

        public static int FetchPoints(string key)
        {
            if (key == "") return 0;
            key = String.Concat(key.OrderByDescending(c => c));
            int intKey = int.Parse(key);
            if (PointsDictionary.Keys.Contains(intKey)) return PointsDictionary[intKey];
            else return 0;
        }

    }
}