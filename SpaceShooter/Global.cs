﻿using System;
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
        public static Canvas SpaceCanvas { get; set; }
        public static Key LastButton { get; set; }
        public static List<int> Lanes { get; set; }
        public static Random rnd = new Random();
        public static int fieldSize;
        public static int asteroidTimer = 0;

        static Global()
        {
            Lanes = new List<int>();
        }
    }
}
