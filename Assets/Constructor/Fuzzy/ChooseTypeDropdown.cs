using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Constructor.Fuzzy
{
    class ChooseTypeDropdown : MonoBehaviour
    {
        [SerializeField] private Canvas[] canvases;
        private Dropdown thisDropdown;

        void Awake()
        {
            thisDropdown = GetComponent<Dropdown>();
            thisDropdown.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        }

        public void ValueChangeCheck()
        {
            for(int i = 0; i < canvases.Length; i++)
            {
                canvases[i].gameObject.SetActive(i == thisDropdown.value);
            }
        }
    }
}
