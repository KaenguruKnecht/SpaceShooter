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
        // static List<Asteroid> Asteroids = new List<Asteroid>();
        static EllipseGeometry myEllipseGeometry = new EllipseGeometry();

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
        }

        internal static void OnTick(object sender, EventArgs e)
        {
            // Spawn Timer
            if (Keyboard.IsKeyDown(Key.Space) && Global.PewPewTimer == 0)
            {
                Global.CurrentShipLocation_X = _testShip.X_Position;
                Global.CurrentShipLocation_Y = _testShip.Y_Position;
                PewPew.PewPews.Add(new PewPew());
                PewPew.PewPews[PewPew.PewPews.Count - 1].Design();
                Global.PewPewTimer = 1;
            }
            else if (Global.PewPewTimer != 0)
            {
                Global.PewPewTimer--;
            }
            if (Global.AsteroidTimer == 0)
            {
                Asteroid.Asteroids.Add(new Asteroid());
                Asteroid.Asteroids[Asteroid.Asteroids.Count - 1].Design();
                Global.AsteroidTimer = 30;
            }// Wann ein neuer Asteroid gespawnt wird
            else
            {
                Global.AsteroidTimer--;
            }
            if (Global.PowerUpTimer == 0)
            {
                PowerUp.PowerUps.Add(new PowerUp());
                PowerUp.PowerUps[PowerUp.PowerUps.Count - 1].Design();
                Global.PowerUpTimer = 30;
            }// Wann ein neues Power Up gespawnt wird
            else
            {
                Global.PowerUpTimer--;
            }

            // Objektkollisionsabfragen
            if (Asteroid.Asteroids.Count > 0 && PewPew.PewPews.Count > 0)
            {
                for (int i = 0; i < Asteroid.Asteroids.Count; i++)
                {
                    // Hitbox Asteroid
                
                    myEllipseGeometry.RadiusX = Global.LaneSize / 2;
                    myEllipseGeometry.RadiusY = Global.LaneSize / 2;
                    myEllipseGeometry.Center = new Point(Asteroid.Asteroids[i].X_Position, Asteroid.Asteroids[i].Y_Position);
                    var ellipse1Geom = myEllipseGeometry;
                    for (int j = 0; j < PewPew.PewPews.Count; j++)
                    {
                        // Hitbox Schuss
                        myEllipseGeometry.Center = new Point(PewPew.PewPews[j].X_Position, PewPew.PewPews[j].Y_Position);
                        myEllipseGeometry.RadiusX = 5;
                        myEllipseGeometry.RadiusY = 5;
                        var ellipse2Geom = myEllipseGeometry;

                        var hit = ellipse2Geom.FillContainsWithDetail(ellipse1Geom);

                        // Treffer Abfrage
                        if (hit != IntersectionDetail.Empty)
                        {
                            Asteroid.Asteroids[i].Alive = false;
                            PewPew.PewPews[j].Alive = false;
                            hit = IntersectionDetail.Empty;
                        }
                    }
                }
            }

            // Spielerschiff
            _testShip.RemoveFromCanvas();
            _testShip.SetMovingDirection();
            _testShip.BorderCollision();
            _testShip.Move();
            _testShip.Show();

            // Listen von Objekten
            foreach (Asteroid item in Asteroid.Asteroids)
            {
                item.BorderCollision();
                item.RemoveFromCanvas();
                item.Move();
                item.Show();
            }// Entfernen, Bewegen, Designen und Anzeigen aller Asteroiden
            foreach (PowerUp item in PowerUp.PowerUps)
            {
                item.BorderCollision();
                item.RemoveFromCanvas();
                item.Move();
                item.Show();
            }// Entfernen, Bewegen, Designen und Anzeigen aller Power Ups
            foreach (PewPew item in PewPew.PewPews)
            {
                item.BorderCollision();
                item.RemoveFromCanvas();
                item.Move();
                item.Design();
                item.Show();
            }// Entfernen, Bewegen, Designen und Anzeigen aller Power Ups
        }
    }
}
