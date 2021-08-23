using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Constructor.Fuzzy
{
    class NextButton : MonoBehaviour
    {
        void OnMouseDown()
        {
            SceneManager.LoadScene(1);
        }
    }
}
