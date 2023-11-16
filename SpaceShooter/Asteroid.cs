﻿using System;
using System.Windows.Media;
using System.Windows;
using System.Collections.Generic;

namespace SpaceShooter
{
    internal class Asteroid : SpaceObjekt
    {
        internal static int variedRadius;
        internal static List<Asteroid> _asteroids = new List<Asteroid>();
        internal override void Design()
        {
            PointCollection myPointCollection = new PointCollection();

            Shape.Fill = Brushes.LightGray;

            for (int i= 0; i < 20; i++)
            {
                double angle = 2 * Math.PI * i / 20; // Winkelberechnung
                double x = variedRadius * Math.Cos(angle);
                double y = variedRadius * Math.Sin(angle);
                myPointCollection.Add(new Point(x, y));
            }
            Shape.Points = myPointCollection;
        }
        internal void BorderCollision()
        {
            if (X_Position <= 100)
            {
                Alive = false;
            }
        }
        internal void AsteroidPewPewCollision()
        {
            // Objektkollisionsabfragen
            if (_asteroids.Count > 0 && Ship._pewpews.Count > 0)
            {
                for (int i = 0; i < _asteroids.Count; i++)
                {
                    // Hitbox Asteroid
                    var EllipseAsteroid = new EllipseGeometry();
                    EllipseAsteroid.RadiusX = Global.LaneSize / 2;
                    EllipseAsteroid.RadiusY = Global.LaneSize / 2;
                    EllipseAsteroid.Center = new Point(_asteroids[i].X_Position, _asteroids[i].Y_Position);
                    var ellipse1Geom = EllipseAsteroid;
                    for (int j = 0; j < Ship._pewpews.Count; j++)
                    {
                        // Hitbox Schuss
                        var EllipsePewPew = new EllipseGeometry();
                        EllipsePewPew.Center = new Point(Ship._pewpews[j].X_Position, Ship._pewpews[j].Y_Position);
                        EllipsePewPew.RadiusX = 5;
                        EllipsePewPew.RadiusY = 5;
                        var ellipse2Geom = EllipsePewPew;

                        var hit = ellipse2Geom.FillContainsWithDetail(ellipse1Geom);

                        // Treffer Abfrage
                        if (hit == IntersectionDetail.Intersects)
                        {
                            _asteroids[i].Alive = false;
                            _asteroids[i].RemoveFromCanvas();
                            _asteroids.RemoveAt(i);

                            Ship._pewpews[j].Alive = false;
                            Ship._pewpews[j].RemoveFromCanvas();
                            Ship._pewpews.RemoveAt(j);

                            // hit = IntersectionDetail.Empty;                    DIES IST EIN FEHLER
                        }
                    }
                }
            }
        }
        internal void AsteroidSpawnTimer()
        {
            if (Global.AsteroidTimer == 0)
            {
                _asteroids.Add(new Asteroid());
                _asteroids[_asteroids.Count - 1].Design();
                Global.AsteroidTimer = 30;
            }// Wann ein neuer Asteroid gespawnt wird
            else
            {
                Global.AsteroidTimer--;
            }
        }
        internal void forEveryAsteroid()
        {
             foreach (Asteroid item in _asteroids)
             {
                item.BorderCollision();
                item.RemoveFromCanvas();
                item.Move();
                item.Show();
             }
        }// Entfernen, Bewegen, Designen und Anzeigen aller Asteroiden
        internal Asteroid()
        {
            Alive = true;
            int Lane = Global.Rnd.Next(0, 8);
            variedRadius = Global.LaneSize / 2;
            X_Vector = Global.Rnd.Next(-10, -5);
            X_Position = Global.SpaceCanvas.ActualWidth;
            Y_Position = Global.Lanes[Lane];
        }

    }
}
