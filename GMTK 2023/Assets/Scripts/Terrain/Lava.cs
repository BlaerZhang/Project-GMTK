using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Terrain
{
    [RequireComponent(typeof(BoxCollider2D))][RequireComponent(typeof(SavedElement))]
    public class Lava : BaseTerrain
    {
        protected override void Init()
        {
            base.Init();
            gameObject.tag = "Lava";
            
            BoxCollider2D col = GetComponent<BoxCollider2D>();
            col.size = new Vector2(0.9f, 0.9f);
            
            GetComponent<SavedElement>().type = SavedElement.Type.Terrain;
        }
    }
}