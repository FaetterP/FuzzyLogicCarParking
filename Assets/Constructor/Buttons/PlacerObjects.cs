using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Constructor.Buttons
{
    class PlacerObjects : MonoBehaviour
    {
        [SerializeField] private Wall wall;
        [SerializeField] private Start start;
        [SerializeField] private Finish finish;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector2 mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                switch (Settings.SelectedSpawnedObject)
                {
                    case SpawnedObject.Finish:
                        Destroy(FindObjectOfType<Finish>().gameObject);
                        CreateObject(finish, mousePos);
                        break;
                    case SpawnedObject.Start:
                        Destroy(FindObjectOfType<Start>().gameObject);
                        CreateObject(start, mousePos);
                        break;
                    case SpawnedObject.Wall:
                        CreateObject(wall, mousePos);
                        break;
                }
            }
        }

        private void CreateObject(MonoBehaviour toCreate, Vector2 click)
        {
            MonoBehaviour go = Instantiate(toCreate, transform);
            go.transform.position = click;
        }
    }
}
