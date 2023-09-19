﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace SpaceShooter
{
    internal class SpaceObjekt
    {
        private Polygon _shape = new Polygon();
        protected Polygon Shape { get { return _shape; } set { _shape = value; } }
        internal double X_Position { get; set; }
        internal double Y_Position { get; set; }
        internal int X_Vector { get; set; }
        internal int Y_Vector { get; set; }
        internal bool Alive { get; set; }

        internal void Move()
        {
            X_Position = X_Position + X_Vector;
            Y_Position = Y_Position + Y_Vector;
        }
        internal void Show()
        {
            if (Alive)
            {
                Canvas.SetLeft(_shape, X_Position);
                Canvas.SetTop(_shape, Y_Position);
                Global.SpaceCanvas.Children.Add(_shape);
            }
        }
        internal void RemoveFromCanvas()
        {
            Global.SpaceCanvas.Children.Remove(_shape);
        }
    }
}
