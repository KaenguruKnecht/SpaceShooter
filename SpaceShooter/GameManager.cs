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


        public static void Initialize()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += OnTick;
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 2000);
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
        }

    }
}
