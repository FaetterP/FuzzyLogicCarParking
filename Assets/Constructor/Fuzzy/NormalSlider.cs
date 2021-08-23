using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Constructor.Fuzzy
{
    class NormalSlider : MonoBehaviour
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
            Settings.FuzzyType = FuzzyType.Normal;
            Settings.NormalParam = thisSlider.value;
            foreach (var line in lines)
            {
                line.positionCount = 0;
            }
        }

    }
}
