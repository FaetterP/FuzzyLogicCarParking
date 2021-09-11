using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Constructor.Fuzzy
{
    class TrapezoidSlider2 : MonoBehaviour
    {
        private Slider thisSlider;
        [SerializeField] private LineRenderer[] lines;

        void Awake()
        {
            thisSlider = GetComponent<Slider>();
            thisSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        }

        public void ValueChangeCheck()
        {
            Settings.FuzzyType = FuzzyType.Trapezoid;
            Settings.TrapezoidParam2 = thisSlider.value;
            foreach (var line in lines)
            {
                line.positionCount = 4;
                line.SetPosition(0, new Vector2(-thisSlider.value * 2, 0));
                line.SetPosition(3, new Vector2(thisSlider.value * 2, 0));
            }
        }

    }
}
