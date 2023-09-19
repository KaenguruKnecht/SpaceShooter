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
        static Asteroid asteroid;
        static List<PowerUp> PowerUps = new List<PowerUp>();
        static List<PewPew> PewPews = new List<PewPew>();
        static EllipseGeometry myEllipseGeometry = new EllipseGeometry();

        internal static void Initialize()
        {
            Global.FieldSize = Convert.ToInt32(Global.SpaceCanvas.ActualHeight / 8);
            for (int i = 0; i < 8; i++)
            {
                Global.Lanes.Add(Global.FieldSize * (i + 1));
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
                PewPews.Add(new PewPew());
                Global.PewPewTimer = 1;
            }
            else if (Global.PewPewTimer != 0)
            {
                Global.PewPewTimer--;
            }
            if (Global.AsteroidTimer == 0)
            {
                Asteroid.Asteroids.Add(new Asteroid());
                Global.AsteroidTimer = 30;
            }// Wann ein neuer Asteroid gespawnt wird
            else
            {
                Global.AsteroidTimer--;
            }
            if (Global.PowerUpTimer == 0)
            {
                PowerUps.Add(new PowerUp());
                Global.PowerUpTimer = 30;
            }// Wann ein neues Power Up gespawnt wird
            else
            {
                Global.PowerUpTimer--;
            }

            // Objektkollisionsabfragen

            foreach (Asteroid item in Asteroid.Asteroids)
            {
                // Hitbox Asteroid
                myEllipseGeometry.Center = new Point(item.X_Position, item.Y_Position);
                myEllipseGeometry.RadiusX = Global.variedRadius;
                myEllipseGeometry.RadiusY = Global.variedRadius;
                var ellipse1Geom = myEllipseGeometry;
                foreach (PewPew item2 in PewPews)
                {
                    // Hitbox Schuss
                    myEllipseGeometry.Center = new Point(item2.X_Position, item2.Y_Position);
                    myEllipseGeometry.RadiusX = 5;
                    myEllipseGeometry.RadiusY = 5;
                    var ellipse2Geom = myEllipseGeometry;

                    var detail = ellipse1Geom.FillContainsWithDetail(ellipse2Geom);

                    if (detail == IntersectionDetail.Empty)
                    {
                        item.Alive = false;
                        item2.Alive = false;
                        detail = IntersectionDetail.Empty;
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
                item.Design();
                item.Show();
            }// Entfernen, Bewegen, Designen und Anzeigen aller Asteroiden
            foreach (PowerUp item in PowerUps)
            {
                item.BorderCollision();
                item.RemoveFromCanvas();
                item.Move();
                item.Design();
                item.Show();
            }// Entfernen, Bewegen, Designen und Anzeigen aller Power Ups
            foreach (PewPew item in PewPews)
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
