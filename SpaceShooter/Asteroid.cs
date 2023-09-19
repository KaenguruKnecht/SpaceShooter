using System;
using System.Windows.Media;
using System.Windows;
using System.Collections.Generic;

namespace SpaceShooter
{
    internal class Asteroid : SpaceObjekt
    {
        double variedRadius = 0;
        internal void Design()
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

        internal Asteroid() 
        {
            int Lane = Global.rnd.Next(0, 8);
            X_Vector = Global.rnd.Next(-40, -5);
            Alive = true;
            variedRadius = Global.fieldSize / 2;
            X_Position = Global.SpaceCanvas.ActualWidth;
            Y_Position = Global.Lanes[Lane];
        }
    }
}
