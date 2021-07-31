using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Constructor.Buttons
{
    class ChangerSpawnedObject : MonoBehaviour
    {
        [SerializeField] private SpawnedObject spawnedObject;
        void OnMouseDown()
        {
            Settings.SelectedSpawnedObject = spawnedObject;
        }
    }
}
