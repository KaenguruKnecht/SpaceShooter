using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SpaceShooter
{
    static class Global
    {
        //internal static List<EllipseGeometry> myEllipseGeometry;
        internal static Canvas SpaceCanvas { get; set; }
        internal static Key LastButton { get; set; }
        internal static List<int> Lanes { get; set; }
        internal static Random Rnd = new Random();
        internal static int Lives = 3;
        internal static int Score = 0;
        internal static int LaneSize = 0;
        internal static int AsteroidTimer = 30;
        internal static int PowerUpTimer = 30;
        internal static int PewPewTimer = 20;
        internal static double CurrentShipLocation_X;
        internal static double CurrentShipLocation_Y;
        internal static TextBlock TextBlockLeben;
        internal static TextBlock TextBlockScore;

        static Global()
        {
            Lanes = new List<int>();
        }
    }
}
