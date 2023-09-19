using System;
using System.Windows.Media;
using System.Windows;
using System.Collections.Generic;

namespace SpaceShooter
{
    internal class Asteroid : SpaceObjekt
    {
        internal static List<Asteroid> Asteroids = new List<Asteroid>();
        internal void Design()
        {
            PointCollection myPointCollection = new PointCollection();

            Shape.Fill = Brushes.LightGray;

            for (int i= 0; i < 20; i++)
            {
                double angle = 2 * Math.PI * i / 20; // Winkelberechnung
                double x = Global.variedRadius * Math.Cos(angle);
                double y = Global.variedRadius * Math.Sin(angle);
                myPointCollection.Add(new Point(x, y));
            }
            Shape.Points = myPointCollection;
        }
        internal void BorderCollision()
        {
            if (X_Position <= 0)
            {
                Alive = false;
            }
        }
        //internal void ObjektCollision()
        //{
        //    foreach (Asteroid item in Asteroids)
        //    {
        //        if 
        //    }
        //}
        internal Asteroid()
        {
            int Lane = Global.Rnd.Next(0, 8);
            X_Vector = Global.Rnd.Next(-40, -5);
            Alive = true;
            X_Position = Global.SpaceCanvas.ActualWidth;
            Y_Position = Global.Lanes[Lane];
        }

    }
}
