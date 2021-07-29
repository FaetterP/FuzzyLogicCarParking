using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class Printer : MonoBehaviour
    {
        private LineRenderer frame;

        void Awake()
        {
            frame = GetComponent<LineRenderer>();
            frame.positionCount = 5;
            frame.SetPosition(0, new Vector2(-Settings.SizeX / 2, -Settings.SizeY/2));
            frame.SetPosition(1, new Vector2(Settings.SizeX / 2, -Settings.SizeY/2));
            frame.SetPosition(2, new Vector2(Settings.SizeX/2, Settings.SizeY/2));
            frame.SetPosition(3, new Vector2(-Settings.SizeX / 2, Settings.SizeY/2));
            frame.SetPosition(4, new Vector2(-Settings.SizeX / 2, -Settings.SizeY/2));
        }
    }
}
