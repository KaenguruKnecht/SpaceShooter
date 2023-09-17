using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace SpaceShooter
{
    internal static class GameManager
    {
        static DispatcherTimer? _timer { get; set; }
        static Player _testShip = new Player();
        // static Asteroid _asteroid = new Asteroid();
        static List<Asteroid> Astroids = new List<Asteroid>();

        public static void Initialize()
        {
            Global.fieldSize = Convert.ToInt32(Global.SpaceCanvas.ActualHeight / 8);
            for (int i = 0; i < 8; i++)
            {
                Global.Lanes.Add(Global.fieldSize * (i + 1));
            }
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            _timer.Tick += OnTick;
            _timer.Start();

            _testShip = new Player();
            _testShip.Design();

        }

        public static void OnTick(object sender, EventArgs e)
        {
            _testShip.RemoveFromCanvas();
            _testShip.SetMovingDirection();
            _testShip.Move();
            _testShip.Show();

            if (Global.asteroidTimer == 0)
            {
                Astroids.Add(new Asteroid());
                Global.asteroidTimer = 30;
            }
            else
            {
                Global.asteroidTimer--;
            }
            //for (int i = Astroids.Count; i == 0; i--)
            //{
            //    if (Astroids[i].Alive)
            //    {
            //        Astroids[i].Design();
            //        Astroids[i].Show();
            //        Astroids[i].Move();
            //    }
            //    else
            //    {
            //        Astroids[i].RemoveFromCanvas();
            //    }
            //}
            foreach (Asteroid item in Astroids)
            {
                item.RemoveFromCanvas();
                if (item.Alive)
                {
                    item.Move();
                    item.Show();
                    item.Design();
                }
            }
        }
    }
}
