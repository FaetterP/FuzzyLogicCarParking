using Assets.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Constructor
{
    class Wall : MonoBehaviour
    {
        void Awake()
        {
            Rigidbody2D rb = gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0;

            BoxCollider2D coll = gameObject.AddComponent<BoxCollider2D>();
            coll.isTrigger = true;
        }
    }
}
