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
        static Asteroid _testAsteroid = new Asteroid();


        public static void Initialize()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            _timer.Tick += OnTick;
            _timer.Start();

            _testShip = new Player();
            _testShip.Design();
            _testAsteroid = new Asteroid();
            _testAsteroid.Design();
        }

        public static void OnTick(object sender, EventArgs e)
        {
            _testShip.RemoveFromCanvas();
            _testShip.SetMovingDirection();
            _testShip.Move();
            _testShip.Show();
            _testAsteroid.RemoveFromCanvas();
            _testAsteroid.Show();

        }

    }
}
