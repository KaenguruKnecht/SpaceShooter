using System;
using System.Windows;
using System.Windows.Media;

namespace SpaceShooter
{
    internal class PewPew : SpaceObjekt
    {
        internal void Design()
        {
            PointCollection myPointCollection = new PointCollection();
            Shape.Fill = Brushes.Yellow;

            for (int i = 0; i < 20; i++)
            {
                double variedRadius = 5;
                double angle = 2 * Math.PI * i / 20; // Winkelberechnung
                double x = variedRadius * Math.Cos(angle);
                double y = variedRadius * Math.Sin(angle);
                myPointCollection.Add(new Point(x, y));
            }
            Shape.Points = myPointCollection;
        }
        internal void BorderCollision()
        {
            if (X_Position >= Global.SpaceCanvas.ActualWidth)
            {
                Alive = false;
            }
        }
        internal PewPew()
        {
            Alive = true;
            X_Position = Global.CurrentShipLocation_X + 45;
            Y_Position = Global.CurrentShipLocation_Y + 10;
            X_Vector = 15;
        }
    }
}
