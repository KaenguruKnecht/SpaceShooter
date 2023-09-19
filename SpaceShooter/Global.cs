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
        internal static Random rnd = new Random();
        internal static int fieldSize;
        internal static int asteroidTimer = 0;
        internal static int powerUpTimer = 0;

        static Global()
        {
            Lanes = new List<int>();
        }
    }
}
