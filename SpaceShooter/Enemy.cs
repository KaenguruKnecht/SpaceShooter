using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace SpaceShooter
{
    internal class Enemy : Ship
    {
        internal new void Design()
        {
            PointCollection myPointCollection = new PointCollection();

            Shape.Fill = Brushes.Red;

            Point Point0 = new Point(0, 0);
            Point Point1 = new Point(-50, -10);
            Point Point2 = new Point(-0, -20);
            Point Point3 = new Point(-10, -10);

            myPointCollection.Add(Point0);
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);

            Shape.Points = myPointCollection;
        }
        internal Enemy() { }
    }
}
