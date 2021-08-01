using Assets.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Constructor.Buttons
{
    class StartGAButton : MonoBehaviour
    {
        [SerializeField] private PopulationController controller;
        void OnMouseDown()
        {
            Vector2 startCoords = FindObjectOfType<Start>().transform.localPosition;
            Settings.start_x = startCoords.x;
            Settings.start_y = startCoords.y;

            controller.enabled = true;
        }
    }
}
