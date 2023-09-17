using System;
using System.Windows.Media;
using System.Windows;
using System.Collections.Generic;

namespace SpaceShooter
{
    internal class Asteroid : SpaceObjekt
    {
        public void Design()
        {
            PointCollection myPointCollection = new PointCollection();

            Shape.Fill = Brushes.LightGray;

            for (int i= 0; i < 20; i++)
            {
                double angle = 2 * Math.PI * i / 20; // Winkelberechnung
                double variedRadius = 25;
                double x = variedRadius * Math.Cos(angle);
                double y = variedRadius * Math.Sin(angle);

                myPointCollection.Add(new Point(x, y));
            }
            Shape.Points = myPointCollection;
        }
        public Asteroid() 
        {
            Alive = true;
            X_Postion = Global.SpaceCanvas.ActualWidth;
            Y_Postion = 200;
            X_Vector = -5;
        }
    }
}
