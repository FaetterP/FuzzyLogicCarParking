using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Constructor.Buttons
{
    class PrinterValue : MonoBehaviour
    {
        [SerializeField] private string nameOfField;
        [SerializeField] private Text textOnScreen;
        private Slider thisSlider;

        void Awake()
        {
            thisSlider = GetComponent<Slider>();
            thisSlider.onValueChanged.AddListener(delegate { textOnScreen.text = nameOfField + thisSlider.value; });
            textOnScreen.text = nameOfField + thisSlider.value;
        }
    }
}
