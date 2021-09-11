using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Constructor.Fuzzy
{
    class TriangleSlider : MonoBehaviour
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
            Settings.FuzzyType = FuzzyType.Triangle;
            Settings.TriangleParam = thisSlider.value;
            foreach (var line in lines)
            {
                line.positionCount = 3;
                line.SetPosition(0, new Vector2(-thisSlider.value * 2, 0));
                line.SetPosition(1, new Vector2(0, 300));
                line.SetPosition(2, new Vector2(thisSlider.value * 2, 0));
            }
        }

    }
}
