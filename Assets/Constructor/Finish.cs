using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Constructor
{
    class Finish : MonoBehaviour
    {
        public double GetDistance(Vector2 car)
        {
            Vector2 me = transform.localPosition;
            return Math.Sqrt(Math.Pow(me.x - car.x, 2) + Math.Pow(me.y - car.y, 2));
        }
    }
}
