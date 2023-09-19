using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SpaceShooter
{
    static class Global
    {
        internal static Canvas SpaceCanvas { get; set; }
        internal static Key LastButton { get; set; }
        internal static List<int> Lanes { get; set; }
        internal static Random Rnd = new Random();
        internal static int FieldSize;
        internal static int AsteroidTimer = 0;
        internal static int PowerUpTimer = 0;
        internal static int PewPewTimer = 0;
        internal static double CurrentShipLocation_X;
        internal static double CurrentShipLocation_Y;
        internal static double variedRadius = FieldSize / 2;

        static Global()
        {
            Lanes = new List<int>();
        }
    }
}
