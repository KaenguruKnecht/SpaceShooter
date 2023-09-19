using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SpaceShooter
{
    internal class PewPew : SpaceObjekt
    {
        internal void Design()
        {
            PointCollection myPointCollection = new PointCollection();

            Shape.Fill = Brushes.LightGray;

            for (int i = 0; i < 20; i++)
            {
                double variedRadius = 0;
                double angle = 2 * Math.PI * i / 20; // Winkelberechnung
                double x = variedRadius * Math.Cos(angle);
                double y = variedRadius * Math.Sin(angle);
                myPointCollection.Add(new Point(x, y));
            }
            Shape.Points = myPointCollection;
        }
        internal PewPew()
        {
            Alive = true;
            X_Position = 
        }
    }
}
