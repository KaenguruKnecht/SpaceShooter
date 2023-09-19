﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SpaceShooter
{
    internal class PowerUp : SpaceObjekt
    {
        internal void Design()
        {
            PointCollection myPointCollection = new PointCollection();

            Shape.Fill = Brushes.Red;

            Point Point0 = new Point(0, 0);
            Point Point1 = new Point(50, 10);
            Point Point2 = new Point(0, 20);
            Point Point3 = new Point(10, 10);

            myPointCollection.Add(Point0);
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);

            Shape.Points = myPointCollection;
        }
        internal PowerUp() 
        {
            int Lane = Global.rnd.Next(0, 8);
            X_Vector = Global.rnd.Next(-40, -5);
            Alive = true;
            X_Position = Global.SpaceCanvas.ActualWidth;
            Y_Position = Global.Lanes[Lane];
        }
    }
}
