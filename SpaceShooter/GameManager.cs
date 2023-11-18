using System;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Media;
using System.Runtime.CompilerServices;

namespace SpaceShooter
{
    internal static class GameManager
    {
        static DispatcherTimer _timer = new DispatcherTimer();
        static Player _testShip = new Player();
        static Asteroid _testAsteroid = new Asteroid();
        static PewPew _testPewPew = new PewPew();
        static PowerUp _testPowerUp = new PowerUp();


        internal static void Initialize()
        {
            Global.LaneSize = Convert.ToInt32(Global.SpaceCanvas.ActualHeight / 8);
            for (int i = 0; i < 8; i++)
            {
                Global.Lanes.Add(Global.LaneSize * (i + 1));
            }

            // Timer erstellen und starten
            _timer.Tick += OnTick;
            _timer.Interval = TimeSpan.FromSeconds(0.03);
            _timer.Start();

            // Spielerschiff erstellen
            _testShip.Design();
            _testAsteroid.Design();
            _testPowerUp.Design();
            _testPewPew.Design();
        }

        internal static void OnTick(object sender, EventArgs e)
        {
            if (Global.Lives == 0)
            {
                Application.Current.Shutdown();
            }
            ShootCooldown();
            _testAsteroid.AsteroidSpawnTimer();
            _testPowerUp.PowerUpSpawnTimer();

            _testShip.RemoveFromCanvas();
            _testShip.SetMovingDirection();
            _testShip.BorderCollision();
            _testShip.PlayerCollision();
            _testShip.Move();
            _testShip.Show();

            _testAsteroid.AsteroidPewPewCollision();
            JedesItem();
        }
        internal static void JedesItem()
        {
            for (int i = 0; i < Asteroid._asteroids.Count; i++)
            {
                Asteroid._asteroids[i].RemoveFromCanvas();
                if (Asteroid._asteroids[i].BorderCollision(i) == false)
                {
                    Asteroid._asteroids[i].Move();
                    Asteroid._asteroids[i].Show();
                }
                else
                {
                    i--;
                }
            }
            for (int i = 0; i < PowerUp._powerUps.Count; i++)
            {
                PowerUp._powerUps[i].RemoveFromCanvas();
                if (PowerUp._powerUps[i].BorderCollision(i) == false)
                {
                    PowerUp._powerUps[i].Move();
                    PowerUp._powerUps[i].Show();
                }
                else
                {
                    i--;
                }
            }
            for (int i = 0; i < Ship._pewpews.Count; i++)
            {
                Ship._pewpews[i].RemoveFromCanvas();
                if (Ship._pewpews[i].BorderCollision(i) == false )
                {
                    Ship._pewpews[i].Move();
                    Ship._pewpews[i].Show();
                }
                else
                {
                    i--;
                }
            }
        }
        private static void ShootCooldown()
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
        }
    }
}
