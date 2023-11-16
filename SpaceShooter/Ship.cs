using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpaceShooter
{
    internal class Ship : SpaceObjekt
    {
        internal static List<PewPew> _pewpews = new List<PewPew>();
        internal override void Design()
        {

        }
        internal void forEveryPewPew()
        {
            foreach (PewPew item in _pewpews)
            {
                item.BorderCollision();
                item.RemoveFromCanvas();
                item.Move();
                item.Show();
            }
        }// Entfernen, Bewegen, Designen und Anzeigen aller
        //internal void forEveryPewPew()
        //{
        //    if (_pewpews.Count > 0)
        //    {
        //        for (int i = _pewpews.Count - 1; i == -1; i--)
        //        {
        //            _pewpews[i].RemoveFromCanvas();
        //            _pewpews[i].BorderCollision();
        //            if (_pewpews[i].Alive == false)
        //            {
        //                _pewpews.RemoveAt(i);
        //            }
        //            else
        //            {
        //                _pewpews[i].Move();
        //                _pewpews[i].Design();
        //                _pewpews[i].Show();
        //            }
        //        }
        //    }
        //}// Entfernen, Bewegen, Designen und Anzeigen aller
        internal Ship() 
        {
            
        }
    }
}
