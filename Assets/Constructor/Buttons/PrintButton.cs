using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Constructor.Buttons
{
    class PrintButton : MonoBehaviour
    {
        [SerializeField] Printer printer;
        [SerializeField] Slider sizeX, sizeY, cellX, cellY;
        [SerializeField] Canvas canvasToAct, canvasToDeact;
        void OnMouseDown()
        {
            Settings.SizeX = (int)sizeX.value;
            Settings.SizeY = (int)sizeY.value;
            Settings.CellX = (int)cellX.value;
            Settings.CellY = (int)cellY.value;
            printer.PrintField();

            canvasToAct.gameObject.SetActive(true);
            canvasToDeact.gameObject.SetActive(false);
        }
    }
}
