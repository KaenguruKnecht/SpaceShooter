using System;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;

namespace SpaceShooter
{
    internal static class GameManager
    {
        static DispatcherTimer? _timer { get; set; }
        static Player _testShip = new Player();


        internal static void Initialize()
        {
            Global.LaneSize = Convert.ToInt32(Global.SpaceCanvas.ActualHeight / 8);
            for (int i = 0; i < 8; i++)
            {
                Global.Lanes.Add(Global.LaneSize * (i + 1));
            }

            // Timer erstellen und starten
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            _timer.Tick += OnTick;
            _timer.Start();

            // Spielerschiff erstellen
            _testShip = new Player();
            _testShip.Design();
            Asteroid._asteroids.Add(new Asteroid());
            PowerUp._powerUps.Add(new PowerUp());
        }

        internal static void OnTick(object sender, EventArgs e)
        {
            // Spawn Timer
            if (Keyboard.IsKeyDown(Key.Space) && Global.PewPewTimer == 0)
            {
                _testShip.PlayerShoot();
            }
            else if (Global.PewPewTimer != 0)
            {
                Global.PewPewTimer--;
            }
            Asteroid._asteroids[0].AsteroidSpawnTimer();
            Asteroid._asteroids[0].AsteroidPewPewCollision();

            // Spielerschiff
            _testShip.RemoveFromCanvas();
            _testShip.SetMovingDirection();
            _testShip.BorderCollision();
            _testShip.Move();
            _testShip.Show();

            // Listen von Objekten
            PowerUp._powerUps[0].forEveryPowerUp();
            Asteroid._asteroids[0].forEveryAsteroid();
            _testShip.forEveryPewPew();
        }
    }
}
