using System;
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
        internal static List<PowerUp> PowerUps = new List<PowerUp>();
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
        internal void BorderCollision()
        {
            if (X_Position <= 0)
            {
                Alive = false;
            }
        }
        internal PowerUp() 
        {
            int Lane = Global.Rnd.Next(0, 8);
            X_Vector = Global.Rnd.Next(-40, -5);
            Alive = true;
            X_Position = Global.SpaceCanvas.ActualWidth;
            Y_Position = Global.Lanes[Lane];
        }
    }
}
