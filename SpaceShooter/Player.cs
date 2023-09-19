using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SpaceShooter
{
    internal class Player : Ship
    {
        //internal void SetMovingDirection()
        //{
        //    switch (Global.LastButton)
        //    {
        //        case Key.Left:
        //            X_Vector = -10;
        //            Y_Vector = 0;
        //            break;
        //        case Key.A:
        //            X_Vector = -10;
        //            Y_Vector = 0;
        //            break;
        //        case Key.Right:
        //            X_Vector = 10;
        //            Y_Vector = 0;
        //            break;
        //        case Key.D:
        //            X_Vector = 10;
        //            Y_Vector = 0;
        //            break;
        //        case Key.Down:
        //            X_Vector = 0;
        //            Y_Vector = 10;
        //            break;
        //        case Key.S:
        //            X_Vector = 0;
        //            Y_Vector = 10;
        //            break;
        //        case Key.Up:
        //            X_Vector = 0;
        //            Y_Vector = -10;
        //            break;
        //        case Key.W:
        //            X_Vector = 0;
        //            Y_Vector = -10;
        //            break;
    //}
        //    }// Spielersteuerung
    internal void SetMovingDirection()
        {
            //Links-Unten
            if ((Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left)) && (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down)))
            {
                X_Vector = -10 * Math.Cos(315);
                Y_Vector = 10 * Math.Sin(315);
            }
            // Links-Oben
            else if ((Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left)) && (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up)))
            {
                X_Vector = -10 * Math.Cos(45);
                Y_Vector = -10 * Math.Sin(45);
            }
            // Rechts-Unten
            else if ((Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right)) && (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down)))
            {
                X_Vector = 10 * Math.Cos(315);
                Y_Vector = 10 * Math.Sin(315);
            }
            // Rechts-Oben
            else if ((Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right)) && (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up)))
            {
                X_Vector = 10 * Math.Cos(45);
                Y_Vector = -10 * Math.Sin(45);
            }
            // Links
            else if (Keyboard.IsKeyDown(Key.A) || Keyboard.IsKeyDown(Key.Left))
            {
                X_Vector = -10;
                Y_Vector = 0;
            }
            // Rechts
            else if (Keyboard.IsKeyDown(Key.D) || Keyboard.IsKeyDown(Key.Right))
            {
                X_Vector = 10;
                Y_Vector = 0;
            }
            // Unten
            else if (Keyboard.IsKeyDown(Key.S) || Keyboard.IsKeyDown(Key.Down))
            {
                X_Vector = 0;
                Y_Vector = 10;
            }
            // Oben
            else if (Keyboard.IsKeyDown(Key.W) || Keyboard.IsKeyDown(Key.Up))
            {
                X_Vector = 0;
                Y_Vector = -10;
            }
        }
        internal void Design()
        {
            PointCollection myPointCollection = new PointCollection();

            Shape.Fill = Brushes.Yellow;

            Point Point0 = new Point(0,0);
            Point Point1 = new Point(50,10);
            Point Point2 = new Point(0,20);
            Point Point3 = new Point(10,10);

            myPointCollection.Add(Point0);
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);

            Shape.Points = myPointCollection;
        }
        internal void BorderCollision()
        {
            if (X_Position <= 0 && X_Vector < 0)
            {
                X_Vector = 0;
            }
            if (X_Position >= Global.SpaceCanvas.ActualWidth - 50 && X_Vector > 0)
            {
                X_Vector = 0;
            }
            if (Y_Position <= 0 && Y_Vector < 0)
            {
                Y_Vector = 0;
            }
            if (Y_Position >= Global.SpaceCanvas.ActualHeight - 30 && Y_Vector > 0)
            {
                Y_Vector = 0;
            }
        }
        internal Player()
        {
            Alive = true;
        }
    }
}
